using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.SharePoint.Client;
using Squirrel;
using Microsoft.SharePoint.Client.WebParts;
using System.Reflection;

namespace IssueCreator
{
    public partial class Issue : System.Windows.Forms.Form
    {
        private bool connected;
        private Connect connect;
        private string path;
        private string[] extensions = new[] { ".jpg", ".jpeg", ".bmp", ".png" };

        private int maxImages;
        private bool deleteOnUpload;
        private bool WatchFolder;
        static bool ShowTheWelcomeWizard;

        public Issue()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void Issue_Load(object sender, EventArgs e)
        {
            notifyIconSQI.Visible = true;

            maxImages = int.Parse(ConfigurationManager.AppSettings["MaxImages"]);
            deleteOnUpload = bool.Parse(ConfigurationManager.AppSettings["DeleteOnUpload"]);
            WatchFolder = bool.Parse(ConfigurationManager.AppSettings["WatchFolder"]);
            checkDelete.Checked = deleteOnUpload;

            if (!connected)
            {
                connect = new Connect();
                connect.ShowDialog();
            }

            linkIssuesList.Tag = ConfigurationManager.AppSettings["Site"] + "/lists/issues";
            linkSite.Tag = ConfigurationManager.AppSettings["Site"];
            linkScreenshots.Tag = ConfigurationManager.AppSettings["Path"];

            PopulateDropdownFromField(comboCategory, "Category");
            PopulateDropdownFromField(comboPriority, "Priority");
            PopulateDropdownFromField(comboStatus, "Status");
            comboAssigned.DisplayMember = "Display";
            PopulateUsersInAssignedTo(comboAssigned);

            path = ConfigurationManager.AppSettings["Path"];
            FileSystemWatcher FileSystemWatcher = new FileSystemWatcher();
            FileSystemWatcher.Path = path;
            FileSystemWatcher.IncludeSubdirectories = false;
            FileSystemWatcher.NotifyFilter = NotifyFilters.FileName;
            FileSystemWatcher.SynchronizingObject = this;    
            FileSystemWatcher.Filter = "*.*";
            FileSystemWatcher.Created += FileSystemWatcher_Created;
            FileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            FileSystemWatcher.Changed += FileSystemWatcher_Changed;
            FileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            FileSystemWatcher.EnableRaisingEvents = true;

            RefreshPictures();

            //Check if the custom issues web part is deployed.
            Microsoft.SharePoint.Client.File issuesDisplayForm = connect.issuesList.RootFolder.Files.GetByUrl("DispForm.aspx");
            LimitedWebPartManager limitedWebPartManager = issuesDisplayForm.GetLimitedWebPartManager(PersonalizationScope.Shared);
            connect.cc.Load(limitedWebPartManager,
                                    wpm => wpm.WebParts,
                                    wpm => wpm.WebParts.Include(wp => wp.WebPart.Title));
            connect.cc.ExecuteQuery();

            foreach (WebPartDefinition wp in limitedWebPartManager.WebParts)
            {
                if (wp.WebPart.Title == "IssuesCreator")
                {
                    linkConfigureIssueForm.Visible = false;
                    break;
                }
                else
                    linkConfigureIssueForm.Visible = true;
            }
            UpdateApp();
        }

        protected override void OnClosed(EventArgs e)
        {
            connect.configuration.Save();
            base.OnClosed(e);
        }

        private void PopulateDropdownFromField(ComboBox dropDown, string fieldTitle)
        {
            connect.cc.Load(connect.issuesList.Fields);
            connect.cc.ExecuteQuery();
            foreach(Field field in connect.issuesList.Fields)
            {
                if (field.InternalName.ToLower() == fieldTitle.ToLower())
                {
                    FieldChoice fc = field as FieldChoice;
                    foreach (string choice in fc.Choices)
                    {
                        dropDown.Items.Add(choice);
                    }
                    return;
                }
            }
        }

        private void PopulateUsersInAssignedTo(ComboBox dropDown)
        {
            var siteUsers = from user in connect.uploadWeb.SiteUsers
                            where user.PrincipalType == Microsoft.SharePoint.Client.Utilities.PrincipalType.User
                            select user;
            var usersResult = connect.cc.LoadQuery(siteUsers);
            connect.cc.ExecuteQuery();

            foreach (var user in usersResult)
            {
                AssignedTo at = new AssignedTo();
                at.Email = user.Email;
                at.ID = user.Id;
                at.Name = user.Title;
                comboAssigned.Items.Add(at);
            }
        }

        private void FileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            if (!extensions.Any(e.Name.Contains))
                return;

            RefreshPictures();
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (!extensions.Any(e.Name.Contains))
                return;

            RefreshPictures();
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (!extensions.Any(e.Name.Contains))
                return;

            RefreshPictures();
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!extensions.Any(e.Name.Contains))
                return;

            RefreshPictures();

            if (WatchFolder)
            {
                WindowState = FormWindowState.Normal;
                Show();
            }
        }

        private void RefreshPictures()
        {
            flowPictureLayout.Controls.Clear();

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles()
                     .Where(f => extensions.Contains(f.Extension.ToLower()))
                     .OrderBy(f => f.CreationTimeUtc)
                     .Reverse()
                     .Take(maxImages)
                     .ToArray();

            int count = 0;
            foreach (var file in files)
            {
                count++;
                PictureBoxDisplay pbd = new PictureBoxDisplay();
                pbd.Filename = file.Name;
                pbd.ImageLocation = file.FullName;
                pbd.Click += new EventHandler(picture_Click);
                if (count == 1) pbd.Checked = true;
                flowPictureLayout.Controls.Add(pbd);
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ListItemCreationInformation lic = new ListItemCreationInformation();

            ListItem li = connect.issuesList.AddItem(lic);
            li["Title"] = textTitle.Text;
            li["Comment"] = rtbeDescription.RichTextBox.Text;
            li["Status"] = comboStatus.Text;
            li["Priority"] = comboPriority.Text;
            li["Category"] = comboCategory.Text;
            li["V3Comments"] = textComment.Text;
            if (!string.IsNullOrEmpty(comboAssigned.SelectedText))
            {
                FieldUserValue uv = new FieldUserValue();
                AssignedTo selected = (AssignedTo)comboAssigned.SelectedItem;
                uv.LookupId = selected.ID;
                li["AssignedTo"] = uv;
            }
            li.Update();
            connect.cc.ExecuteQuery();

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
                aci.ContentStream = new MemoryStream(System.IO.File.ReadAllBytes(pictures.Value));

                Attachment att = li.AttachmentFiles.Add(aci);
                connect.cc.Load(att);
                connect.cc.ExecuteQuery();

                if (deleteOnUpload)
                {
                    FileInfo fi = new FileInfo(pictures.Value);
                    fi.Delete();
                }
            }
        }

        private void ClearForm()
        {
            textTitle.Text = "";
            rtbeDescription.RichTextBox.Text = "";
            comboCategory.Text = "";
            comboPriority.Text = "";
            comboStatus.Text = "";
            textComment.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (textTitle.Text == "" && rtbeDescription.RichTextBox.Text == "" &&
                comboCategory.Text == "" && comboPriority.Text == "" &&  comboStatus.Text == "" &&
                textComment.Text == "")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to discard the issue? If not, click 'No' and minimise the form instead.", "Discard issue?", MessageBoxButtons.YesNo);
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
            ep.picturePath = pic.ImageLocation;
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
            System.Diagnostics.Process.Start(linkIssuesList.Tag.ToString());
        }

        private void linkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkSite.Tag.ToString());
        }

        private void linkScreenshots_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkScreenshots.Tag.ToString());
        }

        private void checkDelete_CheckedChanged(object sender, EventArgs e)
        {
            connect.configuration.AppSettings.Settings["DeleteOnUpload"].Value = checkDelete.Checked.ToString();
        }


        internal async void OnAppUpdate(Version obj)
        {
            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/RapidCircle/O365-IssueCreator"))
            {
                mgr.CreateShortcutForThisExe();
                mgr.CreateUninstallerRegistryEntry();
            }
        }

        internal async void OnInitialInstall(Version obj)
        {
            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/RapidCircle/O365-IssueCreator"))
            {
                mgr.CreateShortcutForThisExe();
                mgr.CreateUninstallerRegistryEntry();
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
            ShowTheWelcomeWizard = true;
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
                        linkUpgrade.Text = "New version released. Upgrading...";
                        linkUpgrade.Enabled = false;
                        linkUpgrade.LinkBehavior = LinkBehavior.NeverUnderline;
                    }
                    else
                    {
                        linkUpgrade.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        linkUpgrade.Enabled = false;
                        linkUpgrade.LinkBehavior = LinkBehavior.NeverUnderline;
                        return;
                    }


                    var release = await mgr.UpdateApp();

                    linkUpgrade.Text = "Upgraded - Click to restart";
                    linkUpgrade.Enabled = true;
                    linkUpgrade.LinkBehavior = LinkBehavior.HoverUnderline;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                    message += ex.InnerException.Message;
                MessageBox.Show(message);
            }
        }


        private class AssignedTo
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public int ID { get; set; }

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
            DialogResult result = MessageBox.Show("This command will replace the default Issue display form with one that can display screenshots next to the issue description. Do you wish to continue?", "Replace default Issue Display form?", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
                return;

            string displayFormSource = System.IO.File.ReadAllText("Issues_DispForm.txt");
            displayFormSource = displayFormSource.Replace("##LISTID##", connect.issuesList.Id.ToString());

            FileCreationInformation displayForm = new FileCreationInformation();
            displayForm.Url = "DispForm.aspx";
            displayForm.Content = Encoding.UTF8.GetBytes(displayFormSource);
            displayForm.Overwrite = true;
            Microsoft.SharePoint.Client.File issuesDisplayForm = connect.issuesList.RootFolder.Files.Add(displayForm);
            connect.cc.ExecuteQuery();

            LimitedWebPartManager limitedWebPartManager = issuesDisplayForm.GetLimitedWebPartManager(PersonalizationScope.Shared);
            connect.cc.Load(limitedWebPartManager.WebParts);
            connect.cc.ExecuteQuery();

            string webPartFileDefinition = System.IO.File.ReadAllText("Attachments.dwp");
            WebPartDefinition webPartImported = limitedWebPartManager.ImportWebPart(webPartFileDefinition);

            WebPartDefinition webPart = limitedWebPartManager.AddWebPart(webPartImported.WebPart, "MainRight", 0);
            connect.cc.Load(webPart, d => d.Id);
            connect.cc.ExecuteQuery();
            MessageBox.Show("Screenshots have been successfully added to your Issues List");
            linkConfigureIssueForm.Visible = false;
        }

        private void linkUpgrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateManager.RestartApp();
        }
    }

}

