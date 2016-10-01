using System.ComponentModel;
using System.Windows.Forms;

namespace IssueCreator
{
    partial class Connect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect));
            this.grpSharePoint = new System.Windows.Forms.GroupBox();
            this.textSite = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.grpIssuesList = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboIssueList = new System.Windows.Forms.ComboBox();
            this.grpProfile = new System.Windows.Forms.GroupBox();
            this.textProfileName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpSharePoint.SuspendLayout();
            this.grpIssuesList.SuspendLayout();
            this.grpProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSharePoint
            // 
            this.grpSharePoint.Controls.Add(this.textSite);
            this.grpSharePoint.Controls.Add(this.label4);
            this.grpSharePoint.Controls.Add(this.buttonConnect);
            this.grpSharePoint.Controls.Add(this.label3);
            this.grpSharePoint.Controls.Add(this.textPassword);
            this.grpSharePoint.Controls.Add(this.label2);
            this.grpSharePoint.Controls.Add(this.textUsername);
            this.grpSharePoint.Location = new System.Drawing.Point(22, 194);
            this.grpSharePoint.Name = "grpSharePoint";
            this.grpSharePoint.Size = new System.Drawing.Size(852, 285);
            this.grpSharePoint.TabIndex = 2;
            this.grpSharePoint.TabStop = false;
            this.grpSharePoint.Text = "Step 2: SharePoint Details";
            // 
            // textSite
            // 
            this.textSite.Location = new System.Drawing.Point(157, 50);
            this.textSite.Name = "textSite";
            this.textSite.Size = new System.Drawing.Size(647, 31);
            this.textSite.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Site:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(255, 197);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(382, 62);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "Retrieve Issues Lists";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(157, 145);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(647, 31);
            this.textPassword.TabIndex = 2;
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
            this.textPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textPassword_KeyUp);
            this.textPassword.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(157, 97);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(647, 31);
            this.textUsername.TabIndex = 1;
            this.textUsername.TextChanged += new System.EventHandler(this.textUsername_TextChanged);
            this.textUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textUsername_KeyUp);
            this.textUsername.Leave += new System.EventHandler(this.textUsername_Leave);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(746, 103);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(58, 43);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Screenshot:";
            // 
            // textFolder
            // 
            this.textFolder.Location = new System.Drawing.Point(157, 105);
            this.textFolder.Name = "textFolder";
            this.textFolder.ReadOnly = true;
            this.textFolder.Size = new System.Drawing.Size(583, 31);
            this.textFolder.TabIndex = 1;
            this.textFolder.TextChanged += new System.EventHandler(this.textFolder_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(692, 686);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 66);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // grpIssuesList
            // 
            this.grpIssuesList.Controls.Add(this.label5);
            this.grpIssuesList.Controls.Add(this.comboIssueList);
            this.grpIssuesList.Controls.Add(this.textFolder);
            this.grpIssuesList.Controls.Add(this.label1);
            this.grpIssuesList.Controls.Add(this.buttonBrowse);
            this.grpIssuesList.Enabled = false;
            this.grpIssuesList.Location = new System.Drawing.Point(22, 495);
            this.grpIssuesList.Name = "grpIssuesList";
            this.grpIssuesList.Size = new System.Drawing.Size(852, 175);
            this.grpIssuesList.TabIndex = 3;
            this.grpIssuesList.TabStop = false;
            this.grpIssuesList.Text = "Step 3: Issue List Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Issue List:";
            // 
            // comboIssueList
            // 
            this.comboIssueList.FormattingEnabled = true;
            this.comboIssueList.Location = new System.Drawing.Point(157, 54);
            this.comboIssueList.Name = "comboIssueList";
            this.comboIssueList.Size = new System.Drawing.Size(583, 33);
            this.comboIssueList.TabIndex = 0;
            this.comboIssueList.SelectedIndexChanged += new System.EventHandler(this.comboIssueList_SelectedIndexChanged);
            // 
            // grpProfile
            // 
            this.grpProfile.Controls.Add(this.textProfileName);
            this.grpProfile.Controls.Add(this.labelName);
            this.grpProfile.Controls.Add(this.comboProfiles);
            this.grpProfile.Location = new System.Drawing.Point(22, 22);
            this.grpProfile.Name = "grpProfile";
            this.grpProfile.Size = new System.Drawing.Size(852, 156);
            this.grpProfile.TabIndex = 1;
            this.grpProfile.TabStop = false;
            this.grpProfile.Text = "Step 1: New or Existing Profile";
            // 
            // textProfileName
            // 
            this.textProfileName.Enabled = false;
            this.textProfileName.Location = new System.Drawing.Point(157, 96);
            this.textProfileName.Name = "textProfileName";
            this.textProfileName.Size = new System.Drawing.Size(647, 31);
            this.textProfileName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(77, 99);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(74, 25);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name:";
            // 
            // comboProfiles
            // 
            this.comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(15, 44);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(789, 33);
            this.comboProfiles.TabIndex = 0;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(504, 686);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(182, 66);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Connect
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(892, 768);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.grpProfile);
            this.Controls.Add(this.grpIssuesList);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.grpSharePoint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapid Issue: Connect";
            this.Load += new System.EventHandler(this.Connect_Load);
            this.grpSharePoint.ResumeLayout(false);
            this.grpSharePoint.PerformLayout();
            this.grpIssuesList.ResumeLayout(false);
            this.grpIssuesList.PerformLayout();
            this.grpProfile.ResumeLayout(false);
            this.grpProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox grpSharePoint;
        private Label label3;
        private TextBox textPassword;
        private Label label2;
        private TextBox textUsername;
        private Button buttonConnect;
        private Button buttonBrowse;
        private Label label1;
        private TextBox textFolder;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonCancel;
        private TextBox textSite;
        private Label label4;
        private GroupBox grpIssuesList;
        private Label label5;
        private ComboBox comboIssueList;
        private GroupBox grpProfile;
        private TextBox textProfileName;
        private Label labelName;
        private ComboBox comboProfiles;
        private Button buttonOK;
        private ErrorProvider errorProvider1;
    }
}

