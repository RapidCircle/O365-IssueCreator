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

        public Issue()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
        }

        private void Issue_Load(object sender, EventArgs e)
        {
            notifyIconSQI.Visible = true;

            path = ConfigurationManager.AppSettings["Path"];
            maxImages = int.Parse(ConfigurationManager.AppSettings["MaxImages"]);
            deleteOnUpload = bool.Parse(ConfigurationManager.AppSettings["DeleteOnUpload"]);

            if (!connected)
            {
                connect = new Connect();
                connect.ShowDialog();
            }

            FileSystemWatcher FileSystemWatcher = new FileSystemWatcher();
            FileSystemWatcher.Path = path;
            FileSystemWatcher.IncludeSubdirectories = false;
            FileSystemWatcher.NotifyFilter = NotifyFilters.FileName;
            FileSystemWatcher.SynchronizingObject = this;    
            FileSystemWatcher.Filter = "*.*";
            FileSystemWatcher.Created += FileSystemWatcher_Created;
            FileSystemWatcher.EnableRaisingEvents = true;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            //PictureBoxDisplay pbd = new PictureBoxDisplay();
            //pbd.Filename = e.Name;
            //pbd.ImageLocation = e.FullPath;
            //pbd.Checked = true;
            //pbd.Click += new EventHandler(picture_Click);
            //flowPictureLayout.Controls.Add(pbd);

            if (!extensions.Any(e.Name.Contains))
                return;

            RefreshPictures();

            WindowState = FormWindowState.Normal;
            Show();
        }

        private void RefreshPictures()
        {
            flowPictureLayout.Controls.Clear();

            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles()
                     .Where(f => extensions.Contains(f.Extension.ToLower()))
                     .OrderBy(f => f.CreationTimeUtc)
                     //.Skip(1).Take(6)
                     .Take(maxImages)
                     .ToArray();

            foreach (var file in files)
            {
                PictureBoxDisplay pbd = new PictureBoxDisplay();
                pbd.Filename = file.Name;
                pbd.ImageLocation = file.FullName;
                pbd.Click += new EventHandler(picture_Click);
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

                FileInfo fi = new FileInfo(pictures.Value);
                fi.Delete();
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
            RefreshPictures();
        }
    }
}

