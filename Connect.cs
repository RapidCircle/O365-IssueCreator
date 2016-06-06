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

        public Connect()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textUsername.Text = ConfigurationManager.AppSettings["Username"];
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textPassword.Text) && !string.IsNullOrEmpty(textUsername.Text))
            {
                username = textUsername.Text;
                string site = ConfigurationManager.AppSettings["Site"];

                foreach (char character in textPassword.Text)
                {
                    password.AppendChar(character);
                }

                cc = new ClientContext(site);
                uploadWeb = cc.Web;
                uploadSite = cc.Site;
                issuesList = uploadWeb.Lists.GetByTitle("Issues");

                cc.Credentials = new SharePointOnlineCredentials(username, password);
                cc.Load(uploadWeb);
                cc.Load(uploadSite);
                cc.Load(issuesList);
                cc.ExecuteQuery();
                buttonConnect.Text = "Connected";
                grpSharePoint.Enabled = false;
                connected = true;

                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else
                throw new NullReferenceException();
        }

    }
}
