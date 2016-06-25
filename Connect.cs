using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IssueCreator
{
    public partial class Connect : System.Windows.Forms.Form
    {
        private const string NewProfileLabel = "New...";
        public SecureString password;
        public ClientContext cc;
        public Web uploadWeb;
        public Site uploadSite;
        public List issuesList;
        private ListCollection lists;
        public bool connected = false;
        public Configuration configuration;
        public SharePointProfile activeProfile;
        public string profiles;
        public string lastUsedProfile;
        private List<SharePointProfile> sharePointProfiles = new List<SharePointProfile>();

        public Connect()
        {
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            char[] splitter = { '#' };
            string[] profilesList = profiles.Split(splitter,StringSplitOptions.RemoveEmptyEntries);
            SharePointProfile newProfile = new SharePointProfile();
            newProfile.Name = NewProfileLabel;
            sharePointProfiles.Add(newProfile);

            SharePointProfile selected = null;
            foreach (string profile in profilesList)
            {
                SharePointProfile spp = new SharePointProfile(profile);
                if (spp.Name == lastUsedProfile) selected = spp;
                sharePointProfiles.Add(spp);
            }

            comboProfiles.DataSource = sharePointProfiles;
            comboProfiles.DisplayMember = "Name";

            if (string.IsNullOrEmpty(lastUsedProfile) || selected == null)
                comboProfiles.SelectedItem = NewProfileLabel;
            else
                comboProfiles.SelectedItem = selected;

            ProfileFormState();
        }

        private bool ConnectToSharePointSite()
        {
            password = new SecureString();
            foreach (char character in textPassword.Text)
            {
                password.AppendChar(character);
            }

            try
            {
                cc = new ClientContext(textSite.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Site URL is incorrect, you need to adjust this in the config file.");
                return false;
            }

            uploadWeb = cc.Web;
            uploadSite = cc.Site;
            cc.Credentials = new SharePointOnlineCredentials(textUsername.Text, password);
            cc.Load(uploadWeb);
            cc.Load(uploadSite);
            try
            {
                cc.ExecuteQuery();
            }
            catch (IdcrlException badPassword)
            {
                errorProvider1.SetError(textPassword, "Invalid Password or Username");
                if (comboProfiles.Text == NewProfileLabel)
                    errorProvider1.SetError(textUsername, "Invalid Password or Username");
                return false;
            }
            catch(ClientRequestException badUrl)
            {
                errorProvider1.SetError(textSite, "There is no SharePoint site at this URL");
                return false;
            }

            connected = true;
            return true;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            bool success = ConnectToSharePointSite();
            if (!success) return;

            lists = uploadWeb.Lists;
            cc.Load(lists, ls => ls.Include(l => l.BaseTemplate),
                           ls => ls.Include(l => l.Title));

            try
            {
                cc.ExecuteQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occurred.");
            }

            foreach (List list in lists)
            {
                if (list.BaseTemplate == (int)ListTemplateType.IssueTracking)
                    comboIssueList.Items.Add(list.Title);
            }

            grpIssuesList.Enabled = true;
            grpSharePoint.Enabled = false;
            buttonOK.Enabled = true;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textFolder.Text = folderBrowserDialog1.SelectedPath;

                SharePointFormState();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ProfileFormState()
        {
            SharePointProfile selected = (SharePointProfile)comboProfiles.SelectedValue;
            if (selected.Name == NewProfileLabel)
            {
                grpIssuesList.Enabled = false;
                textProfileName.Enabled = true;
                textProfileName.Text = "";
                textUsername.Enabled = true;
                textUsername.Text = "";
                textPassword.Text = "";
                textSite.Enabled = true;
                textSite.Text = "";
                comboIssueList.Items.Clear();
                comboIssueList.Text = "";
                textFolder.Text = "";
                textProfileName.Visible = true;
                labelName.Visible = true;
                buttonConnect.Visible = true;
            }
            else
            {
                textUsername.Text = selected.Username;
                textFolder.Text = selected.Path;
                textSite.Text = selected.SiteUrl;
                comboIssueList.Text = selected.IssueList;
                textUsername.Enabled = false;
                textSite.Enabled = false;
                grpIssuesList.Enabled = false;
                textProfileName.Visible = false;
                labelName.Visible = false;
                buttonConnect.Visible = false;
            }

        }

        private void SharePointFormState()
        {
            if (comboProfiles.Text == NewProfileLabel)
            {
                if (string.IsNullOrEmpty(textPassword.Text) || string.IsNullOrEmpty(textUsername.Text)
                    || string.IsNullOrEmpty(textSite.Text))
                {
                    buttonConnect.Enabled = false;
                }
                else
                {
                    buttonConnect.Enabled = true;
                }

                if (string.IsNullOrEmpty(textPassword.Text) || string.IsNullOrEmpty(textUsername.Text) 
                    || string.IsNullOrEmpty(textSite.Text) || string.IsNullOrEmpty(textFolder.Text) 
                    || string.IsNullOrEmpty(comboIssueList.Text))
                    buttonOK.Enabled = false;
                else
                    buttonOK.Enabled = true;
            }
            else
            {
                if (string.IsNullOrEmpty(textPassword.Text) || string.IsNullOrEmpty(textUsername.Text))
                    buttonOK.Enabled = false;
                else
                    buttonOK.Enabled = true;
            }
        }

        private void textUsername_Leave(object sender, EventArgs e)
        {
            SharePointFormState();
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            SharePointFormState();
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            SharePointFormState();
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {
            SharePointFormState();
        }

        private void comboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfileFormState();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            bool success = ConnectToSharePointSite();
            if (success) SetVariablesAndCloseForm();
        }

        private void SetVariablesAndCloseForm()
        {
            issuesList = uploadWeb.Lists.GetByTitle(comboIssueList.Text);
            cc.Load(issuesList, i => i.DefaultViewUrl);
            cc.ExecuteQuery();

            SharePointProfile spp = new SharePointProfile();

            if (comboProfiles.Text == NewProfileLabel)
            {
                spp.Name = textProfileName.Text;
                profiles = profiles + "#" + spp.ToString();
            }
            else
                spp.Name = comboProfiles.Text;


            spp.SiteUrl = textSite.Text;
            spp.IssueList = comboIssueList.Text;
            spp.Path = textFolder.Text;
            spp.Username = textUsername.Text;

            activeProfile = spp;
            lastUsedProfile = spp.Name;

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void comboIssueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SharePointFormState();
        }

        private void textFolder_TextChanged(object sender, EventArgs e)
        {
            SharePointFormState();
        }

        private void textPassword_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.SetError(textPassword, "");
            errorProvider1.SetError(textUsername, "");
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(textPassword.Text)) return;

                if (comboProfiles.Text == NewProfileLabel)
                    buttonConnect.PerformClick();
                else
                    buttonOK.PerformClick();
            }
        }

        private void textUsername_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider1.SetError(textUsername, "");
            errorProvider1.SetError(textPassword, "");
        }
    }

    public class SharePointProfile
    {
        public string Name { get; set; }
        public string SiteUrl { get; set; }
        public string Username { get; set; }
        public string Path { get; set; }
        public string IssueList { get; set; }

        public SharePointProfile(string profile)
        {
            string[] profileDetails = profile.Split(';');
            Name = profileDetails[0];
            SiteUrl = profileDetails[1];
            Username = profileDetails[2];
            Path = profileDetails[3];
            IssueList = profileDetails[4];
        }

        public SharePointProfile()
        { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name + ";");
            sb.Append(SiteUrl + ";");
            sb.Append(Username + ";");
            sb.Append(Path + ";");
            sb.Append(IssueList);
            return sb.ToString();
        }
    }
}
