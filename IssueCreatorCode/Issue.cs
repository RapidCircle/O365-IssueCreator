using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Utilities;
using Microsoft.SharePoint.Client.WebParts;
using Squirrel;
using File = System.IO.File;
using Form = System.Windows.Forms.Form;

namespace IssueCreator
{
    public partial class Issue : Form
    {
        private Configuration _config;
        private Connect _connect;
        private string[] extensions = { ".jpg", ".jpeg", ".bmp", ".png" };
        private SecureString password = new SecureString();
        private string _profiles;
        private string _lastUsedProfile;

        private int _maxImages;
        private bool _deleteOnUpload;
        private bool _watchFolder;

        const string ProjectConfigFileName = "UserConfiguration.config";

        public Issue()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void Issue_Load(object sender, EventArgs e)
        {
            notifyIconSQI.Visible = true;

            DirectoryInfo di = new DirectoryInfo(Assembly.GetEntryAssembly().Location);
            string userConfigPath = di.Parent?.Parent?.FullName + "\\" + ProjectConfigFileName;

            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = userConfigPath;

            if (!File.Exists(userConfigPath))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                sb.AppendLine("<configuration>");
                sb.AppendLine("</configuration>");

                File.WriteAllText(userConfigPath, sb.ToString());
            }

            _config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            if (_config.AppSettings.Settings["Password"] != null)
            {
                foreach (char letter in _config.AppSettings.Settings["Password"].Value)
                    password.AppendChar(letter);
            }

            _lastUsedProfile = _config.AppSettings.Settings["LastUsedProfile"] == null ? "" : _config.AppSettings.Settings["LastUsedProfile"].Value;
            _maxImages = _config.AppSettings.Settings["MaxImages"] == null ? 16 : int.Parse(_config.AppSettings.Settings["MaxImages"].Value);
            _deleteOnUpload = _config.AppSettings.Settings["DeleteOnUpload"] != null && bool.Parse(_config.AppSettings.Settings["DeleteOnUpload"].Value);
            _watchFolder = _config.AppSettings.Settings["WatchFolder"] != null && bool.Parse(_config.AppSettings.Settings["WatchFolder"].Value);
            _profiles = _config.AppSettings.Settings["Profiles"] == null ? "" : _config.AppSettings.Settings["Profiles"].Value;

            checkDelete.Checked = _deleteOnUpload;

            _connect = new Connect();
            _connect.profiles = _profiles;
            _connect.lastUsedProfile = _lastUsedProfile;

            _connect.ShowDialog();

            if (!_connect.connected)
            {
                Close();
                return;
            }

            _profiles = _connect.profiles;
            _lastUsedProfile = _connect.lastUsedProfile;
            Text = @"Rapid Issue: " + _connect.activeProfile.Name;

            AddUpdateConfiguration(_config, "Profiles", _profiles);
            AddUpdateConfiguration(_config, "LastUsedProfile", _lastUsedProfile);
            _config.Save();

            Uri spServer = new Uri(_connect.activeProfile.SiteUrl);
            linkIssuesList.Tag = spServer.Scheme + "://" + spServer.Host + _connect.issuesList.DefaultViewUrl;
            linkSite.Tag = _connect.activeProfile.SiteUrl;
            linkScreenshots.Tag = _connect.activeProfile.Path;

            PopulateDropdownFromField(comboCategory, "Category");
            PopulateDropdownFromField(comboPriority, "Priority");
            PopulateDropdownFromField(comboStatus, "Status");
            comboAssigned.DisplayMember = "Display";
            PopulateUsersInAssignedTo();

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = _connect.activeProfile.Path;
            fileSystemWatcher.IncludeSubdirectories = false;
            fileSystemWatcher.NotifyFilter = NotifyFilters.FileName;
            fileSystemWatcher.SynchronizingObject = this;
            fileSystemWatcher.Filter = "*.*";
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.EnableRaisingEvents = true;

            RefreshPictures();

            SetIssueListCustomisationEnabled();

            UpdateApp();
        }

        private void SetIssueListCustomisationEnabled()
        {
            Microsoft.SharePoint.Client.File issuesDisplayForm = _connect.issuesList.RootFolder.Files.GetByUrl("DispForm.aspx");
            LimitedWebPartManager limitedWebPartManager = issuesDisplayForm.GetLimitedWebPartManager(PersonalizationScope.Shared);
            _connect.cc.Load(limitedWebPartManager,
                                    wpm => wpm.WebParts,
                                    wpm => wpm.WebParts.Include(wp => wp.WebPart.Title));
            _connect.cc.ExecuteQuery();

            foreach (WebPartDefinition wp in limitedWebPartManager.WebParts)
            {
                if (wp.WebPart.Title == "RapidIssueScreenshot")
                {
                    linkConfigureIssueForm.Visible = false;
                    break;
                }
                linkConfigureIssueForm.Visible = true;
            }
        }

        private void AddUpdateConfiguration(Configuration config, string key, string value)
        {
            if (config.AppSettings.Settings[key] != null)
                config.AppSettings.Settings[key].Value = value;
            else
                config.AppSettings.Settings.Add(key, value);
        }

        protected override void OnClosed(EventArgs e)
        {
            _config.Save();
            base.OnClosed(e);
        }

        private void PopulateDropdownFromField(ComboBox dropDown, string fieldTitle)
        {
            _connect.cc.Load(_connect.issuesList.Fields);
            _connect.cc.ExecuteQuery();
            foreach(Field field in _connect.issuesList.Fields)
            {
                if (field.InternalName.ToLower() == fieldTitle.ToLower())
                {
                    FieldChoice fc = field as FieldChoice;
                    if (fc != null)
                        foreach (string choice in fc.Choices)
                        {
                            dropDown.Items.Add(choice);
                        }
                    return;
                }
            }
        }

        private void PopulateUsersInAssignedTo()
        {
            var siteUsers = from user in _connect.uploadWeb.SiteUsers
                            where user.PrincipalType == PrincipalType.User
                            select user;
            var usersResult = _connect.cc.LoadQuery(siteUsers);
            _connect.cc.ExecuteQuery();

            foreach (var user in usersResult)
            {
                AssignedTo at = new AssignedTo();
                at.Email = user.Email;
                at.Id = user.Id;
                at.Name = user.Title;
                comboAssigned.Items.Add(at);
            }
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (!extensions.Any(e.Name.ToLower().Contains))
                return;

            RefreshPictures();
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (!extensions.Any(e.Name.ToLower().Contains))
                return;

            RefreshPictures();
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (!extensions.Any(e.Name.ToLower().Contains))
                return;

            RefreshPictures();
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!extensions.Any(e.Name.ToLower().Contains))
                return;

            RefreshPictures();

            if (_watchFolder)
            {
                WindowState = FormWindowState.Normal;
                Show();
            }
        }

        private void RefreshPictures()
        {
            Thread.Sleep(400);
            flowPictureLayout.Controls.Clear();

            DirectoryInfo di = new DirectoryInfo(_connect.activeProfile.Path);
            FileInfo[] files = di.GetFiles()
                     .Where(f => extensions.Contains(f.Extension.ToLower()))
                     .OrderBy(f => f.CreationTimeUtc)
                     .Reverse()
                     .Take(_maxImages)
                     .ToArray();

            int count = 0;
            foreach (var file in files)
            {
                count++;
                PictureBoxDisplay pbd = new PictureBoxDisplay();
                pbd.Filename = file.Name;
                pbd.ImageLocation = file.FullName;
                pbd.Enlarge += picture_Click;
                if (count == 1) pbd.Checked = true;
                flowPictureLayout.Controls.Add(pbd);
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textTitle.Text))
            {
                MessageBox.Show(@"Title field cannot be empty.", @"No Title", MessageBoxButtons.OK);
                return;    
            }

            bool atLeastOnePicture = false;
            foreach (PictureBoxDisplay pb in flowPictureLayout.Controls)
            {
                if (pb.Checked)
                {
                    atLeastOnePicture = true;
                    break;
                }
            }

            if(!atLeastOnePicture)
            {
                DialogResult saveWithoutPitcure = MessageBox.Show(@"Title field cannot be empty.", @"Screenshot not selected", MessageBoxButtons.YesNo);
                if (saveWithoutPitcure == DialogResult.No)
                    return;
            }

            ListItemCreationInformation lic = new ListItemCreationInformation();

            ListItem li = _connect.issuesList.AddItem(lic);
            li["Title"] = textTitle.Text;

            //StringWriter sw = new StringWriter();
            //modelEdit.save(sw, XmlHeaderType.None);
            li["Comment"] = richTextBoxDescription.Text;

            li["Status"] = comboStatus.Text;
            li["Priority"] = comboPriority.Text;
            li["Category"] = comboCategory.Text;
            li["V3Comments"] = textComment.Text;
            if (comboAssigned.SelectedItem != null)
            {
                FieldUserValue uv = new FieldUserValue();
                AssignedTo selected = (AssignedTo)comboAssigned.SelectedItem;
                uv.LookupId = selected.Id;
                li["AssignedTo"] = uv;
            }
            li.Update();
            _connect.cc.ExecuteQuery();

            Dictionary<string, string> pictures = new Dictionary<string, string>();
            foreach (PictureBoxDisplay picture in flowPictureLayout.Controls)
            {
                if (picture.Checked)
                    pictures.Add(picture.Filename, picture.ImageLocation);

            }

            CreateAttachments(pictures, li); 

            ClearForm();
            Hide();
        }

        private void CreateAttachments(Dictionary<string, string> pictureTags, ListItem li)
        {

            foreach (KeyValuePair<string,string> pictures in pictureTags)
            {
                AttachmentCreationInformation aci = new AttachmentCreationInformation();
                aci.FileName = pictures.Key;
                aci.ContentStream = new MemoryStream(File.ReadAllBytes(pictures.Value));

                Attachment att = li.AttachmentFiles.Add(aci);
                _connect.cc.Load(att);
                _connect.cc.ExecuteQuery();

                if (_deleteOnUpload)
                {
                    FileInfo fi = new FileInfo(pictures.Value);
                    fi.Delete();
                }
            }
        }

        private void ClearForm()
        {
            textTitle.Text = "";
            richTextBoxDescription.Text = "";
            comboCategory.Text = "";
            comboPriority.Text = "";
            comboStatus.Text = "";
            textComment.Text = "";
            comboAssigned.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (textTitle.Text != "" || richTextBoxDescription.Text != "" ||
                comboCategory.Text != "" || comboPriority.Text != "" ||  comboStatus.Text != "" ||
                textComment.Text != "" || comboAssigned.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show(@"Title field cannot be empty.", @"Discard issue?", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }

            ClearForm();
            Hide();
        }

        private void picture_Click(object sender, EventArgs e)
        {
            PictureBoxDisplay pic = sender as PictureBoxDisplay;

            pictureboxEnlarge ep = new pictureboxEnlarge();
            ep.picturePath = pic?.ImageLocation;
            ep.Show();
        }

        private void notifyIconSQI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
        }

        private void Issue_Activated(object sender, EventArgs e)
        {
            //RefreshPictures();
        }

        private void linkIssuesList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkIssuesList.Tag.ToString());
        }

        private void linkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkSite.Tag.ToString());
        }

        private void linkScreenshots_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkScreenshots.Tag.ToString());
        }

        private void checkDelete_CheckedChanged(object sender, EventArgs e)
        {
            AddUpdateConfiguration(_config, "DeleteOnUpload", checkDelete.Checked.ToString());
            _deleteOnUpload = checkDelete.Checked;
        }


        internal async void OnAppUpdate(Version obj)
        {
            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/RapidCircle/O365-IssueCreator"))
            {
                mgr.CreateShortcutForThisExe();
                await mgr.CreateUninstallerRegistryEntry();
            }
        }

        internal async void OnInitialInstall(Version obj)
        {
            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/RapidCircle/O365-IssueCreator"))
            {
                mgr.CreateShortcutForThisExe();
                await mgr.CreateUninstallerRegistryEntry();
            }
        }

        internal async void OnAppUninstall(Version obj)
        {
            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/RapidCircle/O365-IssueCreator"))
            {
                mgr.RemoveShortcutForThisExe();
            }
        }

        internal void OnFirstRun()
        {

        }

        private async void UpdateApp()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/RapidCircle/O365-IssueCreator"))
                {
                    var upgrade = await mgr.CheckForUpdate();
                    if (upgrade.ReleasesToApply.Any())
                    {
                        linkUpgrade.Text = @"New version released. Upgrading...";
                        linkUpgrade.Enabled = false;
                        linkUpgrade.LinkBehavior = LinkBehavior.NeverUnderline;
                    }
                    else
                    {
                        linkUpgrade.Text = @"Version: " + Assembly.GetExecutingAssembly().GetName().Version;
                        linkUpgrade.Enabled = false;
                        linkUpgrade.LinkBehavior = LinkBehavior.NeverUnderline;
                        return;
                    }


                    await mgr.UpdateApp();

                    linkUpgrade.Text = @"Upgraded - Click to restart";
                    linkUpgrade.Enabled = true;
                    linkUpgrade.LinkBehavior = LinkBehavior.HoverUnderline;
                }
            }
            catch (Exception)
            {
                linkUpgrade.Text = @"Version Check Failed";
                linkUpgrade.Enabled = false;
            }
        }


        private class AssignedTo
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public int Id { get; set; }

            public string Display
            {
                get { return Name + " (" + Email + ")"; }
            }
        }

        private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAboutBox ab = new frmAboutBox();
            ab.ShowDialog();
        }

        private void linkConfigureIssueForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Title field cannot be empty.", @"Replace default Issue Display form?", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            string fileUrl = _connect.issuesList.RootFolder.ServerRelativeUrl + "/DispForm.aspx";
            Microsoft.SharePoint.Client.File issuesDisplayForm = _connect.uploadWeb.GetFileByUrl(fileUrl);
            LimitedWebPartManager limitedWebPartManager = issuesDisplayForm.GetLimitedWebPartManager(PersonalizationScope.Shared);
            _connect.cc.Load(limitedWebPartManager.WebParts);
            _connect.cc.ExecuteQuery();

            string webPartFileDefinition = File.ReadAllText("screenshots.webpart");
            WebPartDefinition webPartImported = limitedWebPartManager.ImportWebPart(webPartFileDefinition);

            WebPartDefinition webPart = limitedWebPartManager.AddWebPart(webPartImported.WebPart, "Main", 0);
            _connect.cc.Load(webPart, d => d.Id);
            _connect.cc.ExecuteQuery();
            linkConfigureIssueForm.Visible = false;
        }

        private void linkUpgrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateManager.RestartApp();
        }

        //#region Description Textbox Code

        ////Description Textbox Requirements
        //private void onToolCommand(Command command)
        //{
        //    if (object.ReferenceEquals(command, CommandInstance.commandInsertHyperlink))
        //    {
        //        //invoke a method to handle the Insert Hyperlink command being pressed
        //        onInsertHyperlink();
        //    }
        //}

        //void onInsertHyperlink()
        //{
        //    //get the document fragment which the user has currently selected using mouse and/or cursor
        //    IWindowSelection windowSelection = modelEdit.windowSelection;
        //    //verify that there's only one selection
        //    if (windowSelection.rangeCount != 1)
        //    {
        //        //this can happen when the user has selected several cell in a table,
        //        //in which case each cell is a separate selection/range
        //        MessageBox.Show("Can't insert a hyperlink when more than one range in the document is selected");
        //        return;
        //    }
        //    using (IDomRange domRange = windowSelection.getRangeAt(0))
        //    {
        //        //verify that only one node is selected
        //        if (!domRange.startContainer.isSameNode(domRange.endContainer))
        //        {
        //            //this can happen for example when the selection spans multiple paragraphs
        //            MessageBox.Show("Can't insert a hyperlink when more than one node in the document is selected");
        //            return;
        //        }
        //        IDomNode container = domRange.startContainer; //already just checked that this is the same as domRange.endContainer
        //        //read existing values from the current selection
        //        string url;
        //        string visibleText;
        //        IDomElement existingHyperlink;
        //        switch (container.nodeType)
        //        {
        //            case DomNodeType.Text:
        //                //selection is a text fragment
        //                visibleText = container.nodeValue.Substring(domRange.startOffset, domRange.endOffset - domRange.startOffset);
        //                IDomNode parentNode = container.parentNode;
        //                if ((parentNode.nodeType == DomNodeType.Element) && (parentNode.nodeName == "a"))
        //                {
        //                    //parent of this text node is a <a> element
        //                    existingHyperlink = parentNode as IDomElement;
        //                    url = existingHyperlink.getAttribute("href");
        //                    visibleText = container.nodeValue;
        //                    if ((existingHyperlink.childNodes.count != 1) || (existingHyperlink.childNodes.itemAt(0).nodeType != DomNodeType.Text))
        //                    {
        //                        //this can happen when an anchor tag wraps more than just a single, simple text node
        //                        //for example when it contains inline elements like <strong>
        //                        MessageBox.Show("Can't edit a complex hyperlink");
        //                        return;
        //                    }
        //                }
        //                else
        //                {
        //                    existingHyperlink = null;
        //                    url = null;
        //                }
        //                break;

        //            default:
        //                //unexpected
        //                MessageBox.Show("Can't insert a hyperlink when more than one node in the document is selected");
        //                return;
        //        }
        //        //display the modal dialog box
        //        using (FormInsertHyperlink formInsertHyperlink = new FormInsertHyperlink())
        //        {
        //            formInsertHyperlink.url = url;
        //            formInsertHyperlink.visibleText = visibleText;
        //            DialogResult dialogResult = formInsertHyperlink.ShowDialog();
        //            if (dialogResult != DialogResult.OK)
        //            {
        //                //user cancelled
        //                return;
        //            }
        //            //get new values from the dialog box
        //            //the FormInsertHyperlink.onEditTextChanged method assures that both strings are non-empty
        //            url = formInsertHyperlink.url;
        //            visibleText = formInsertHyperlink.visibleText;
        //        }
        //        //need to change href, change text, and possibly delete existing text;
        //        //do this within the scope of a single IEditorTransaction instance so
        //        //that if the user does 'undo' then it will undo all these operations at once, instead of one at a time
        //        using (IEditorTransaction editorTransaction = modelEdit.createEditorTransaction())
        //        {
        //            if (existingHyperlink != null)
        //            {
        //                //changing an existing hyperlink ...
        //                //... change the href attribute value
        //                existingHyperlink.setAttribute("href", url);
        //                //... change the text, by removing the old text node and inserting a new text node
        //                IDomText newDomText = modelEdit.domDocument.createTextNode(visibleText);
        //                IDomNode oldDomText = existingHyperlink.childNodes.itemAt(0);
        //                existingHyperlink.removeChild(oldDomText);
        //                existingHyperlink.insertBefore(newDomText, null);
        //            }
        //            else
        //            {
        //                //creating a new hyperlink
        //                IDomElement newHyperlink = modelEdit.domDocument.createElement("a");
        //                IDomText newDomText = modelEdit.domDocument.createTextNode(visibleText);
        //                newHyperlink.insertBefore(newDomText, null);
        //                newHyperlink.setAttribute("href", url);
        //                //remove whatever was previously selected, if anything
        //                if (!domRange.collapsed)
        //                {
        //                    domRange.deleteContents();
        //                }
        //                //insert the new hyperlink
        //                domRange.insertNode(newHyperlink);
        //            }
        //        }
        //    }
        //}


        ////IModelEdit modelEdit
        ////{
        ////    get { return tooledControlDescription.modelEdit; }
        ////}

        //#endregion

        private void richTextBoxDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }

}

