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
        public string path;
        public string site;
        public string username;
        public SecureString password = new SecureString();
        public ClientContext cc;
        public Web uploadWeb;
        public Site uploadSite;
        public List issuesList;
        public bool connected = false;
        private Configuration configuration;


        public Connect()
        {
            InitializeComponent();
            configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textUsername.Text = ConfigurationManager.AppSettings["Username"];
            textFolder.Text = ConfigurationManager.AppSettings["Path"];
            linkIssuesList.Tag = ConfigurationManager.AppSettings["Site"] + "/lists/issues";
            linkSite.Tag = ConfigurationManager.AppSettings["Site"];
            FormState();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textPassword.Text) && !string.IsNullOrEmpty(textUsername.Text) && !string.IsNullOrEmpty(textFolder.Text))
            {
                username = textUsername.Text;
                string site = ConfigurationManager.AppSettings["Site"];

                foreach (char character in textPassword.Text)
                {
                    password.AppendChar(character);
                }

                try
                {
                    cc = new ClientContext(site);
                }
                catch (Exception)
                {
                    MessageBox.Show("Site URL is incorrect, you need to adjust this in the config file.");
                    return;
                }

                uploadWeb = cc.Web;
                uploadSite = cc.Site;
                issuesList = uploadWeb.Lists.GetByTitle("Issues");

                cc.Credentials = new SharePointOnlineCredentials(username, password);
                cc.Load(uploadWeb);
                cc.Load(uploadSite);
                cc.Load(issuesList);

                try
                {
                    cc.ExecuteQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occurred.");
                }

                buttonConnect.Text = "Connected";
                grpSharePoint.Enabled = false;
                connected = true;

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else
                throw new NullReferenceException();

            configuration.AppSettings.Settings["Username"].Value = textUsername.Text;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textFolder.Text = folderBrowserDialog1.SelectedPath;

                configuration.AppSettings.Settings["Path"].Value = folderBrowserDialog1.SelectedPath;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
                FormState();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormState()
        {
            if (string.IsNullOrEmpty(textPassword.Text) || string.IsNullOrEmpty(textUsername.Text) || string.IsNullOrEmpty(textFolder.Text))
                buttonConnect.Enabled = false;
            else
                buttonConnect.Enabled = true;
        }

        private void textUsername_Leave(object sender, EventArgs e)
        {
            FormState();
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            FormState();
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            FormState();
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {
            FormState();
        }

        private void linkIssuesList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkIssuesList.Tag.ToString());
        }

        private void linkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkSite.Tag.ToString());
        }
    }
}
