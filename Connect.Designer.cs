namespace IssueCreator
{
    partial class Connect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect));
            this.grpSharePoint = new System.Windows.Forms.GroupBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkSite = new System.Windows.Forms.LinkLabel();
            this.linkIssuesList = new System.Windows.Forms.LinkLabel();
            this.grpSharePoint.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSharePoint
            // 
            this.grpSharePoint.Controls.Add(this.buttonBrowse);
            this.grpSharePoint.Controls.Add(this.label1);
            this.grpSharePoint.Controls.Add(this.textFolder);
            this.grpSharePoint.Controls.Add(this.label3);
            this.grpSharePoint.Controls.Add(this.textPassword);
            this.grpSharePoint.Controls.Add(this.label2);
            this.grpSharePoint.Controls.Add(this.textUsername);
            this.grpSharePoint.Location = new System.Drawing.Point(22, 126);
            this.grpSharePoint.Name = "grpSharePoint";
            this.grpSharePoint.Size = new System.Drawing.Size(735, 199);
            this.grpSharePoint.TabIndex = 0;
            this.grpSharePoint.TabStop = false;
            this.grpSharePoint.Text = "Issue Creator";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(658, 133);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(58, 43);
            this.buttonBrowse.TabIndex = 9;
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Folder:";
            // 
            // textFolder
            // 
            this.textFolder.Location = new System.Drawing.Point(136, 135);
            this.textFolder.Name = "textFolder";
            this.textFolder.ReadOnly = true;
            this.textFolder.Size = new System.Drawing.Size(516, 31);
            this.textFolder.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(136, 88);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(516, 31);
            this.textPassword.TabIndex = 4;
            this.textPassword.TextChanged += new System.EventHandler(this.textPassword_TextChanged);
            this.textPassword.Leave += new System.EventHandler(this.textPassword_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(136, 40);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(516, 31);
            this.textUsername.TabIndex = 2;
            this.textUsername.TextChanged += new System.EventHandler(this.textUsername_TextChanged);
            this.textUsername.Leave += new System.EventHandler(this.textUsername_Leave);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(387, 357);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(182, 66);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(575, 357);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 66);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linkSite);
            this.groupBox2.Controls.Add(this.linkIssuesList);
            this.groupBox2.Location = new System.Drawing.Point(22, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 99);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SharePoint Details";
            // 
            // linkSite
            // 
            this.linkSite.AutoSize = true;
            this.linkSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSite.Location = new System.Drawing.Point(26, 47);
            this.linkSite.Name = "linkSite";
            this.linkSite.Size = new System.Drawing.Size(137, 29);
            this.linkSite.TabIndex = 1;
            this.linkSite.TabStop = true;
            this.linkSite.Text = "Project Site";
            this.linkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSite_LinkClicked);
            // 
            // linkIssuesList
            // 
            this.linkIssuesList.AutoSize = true;
            this.linkIssuesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkIssuesList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkIssuesList.Location = new System.Drawing.Point(203, 47);
            this.linkIssuesList.Name = "linkIssuesList";
            this.linkIssuesList.Size = new System.Drawing.Size(125, 29);
            this.linkIssuesList.TabIndex = 0;
            this.linkIssuesList.TabStop = true;
            this.linkIssuesList.Text = "Issues List";
            this.linkIssuesList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIssuesList_LinkClicked);
            // 
            // Connect
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.grpSharePoint);
            this.Controls.Add(this.buttonConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connect";
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpSharePoint.ResumeLayout(false);
            this.grpSharePoint.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpSharePoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel linkIssuesList;
        private System.Windows.Forms.LinkLabel linkSite;
    }
}

