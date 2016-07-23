namespace IssueCreator
{
    partial class frmLicenses
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.listBoxLicenses = new System.Windows.Forms.ListBox();
            this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(702, 411);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(141, 44);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // listBoxLicenses
            // 
            this.listBoxLicenses.FormattingEnabled = true;
            this.listBoxLicenses.ItemHeight = 25;
            this.listBoxLicenses.Items.AddRange(new object[] {
            "Rapid Issue",
            "ModelText"});
            this.listBoxLicenses.Location = new System.Drawing.Point(12, 12);
            this.listBoxLicenses.Name = "listBoxLicenses";
            this.listBoxLicenses.Size = new System.Drawing.Size(231, 379);
            this.listBoxLicenses.TabIndex = 1;
            this.listBoxLicenses.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // richTextBoxLicense
            // 
            this.richTextBoxLicense.Location = new System.Drawing.Point(250, 12);
            this.richTextBoxLicense.Name = "richTextBoxLicense";
            this.richTextBoxLicense.ReadOnly = true;
            this.richTextBoxLicense.Size = new System.Drawing.Size(593, 379);
            this.richTextBoxLicense.TabIndex = 2;
            this.richTextBoxLicense.Text = "";
            // 
            // frmLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 478);
            this.Controls.Add(this.richTextBoxLicense);
            this.Controls.Add(this.listBoxLicenses);
            this.Controls.Add(this.buttonOK);
            this.Name = "frmLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Licenses";
            this.Load += new System.EventHandler(this.frmLicenses_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ListBox listBoxLicenses;
        private System.Windows.Forms.RichTextBox richTextBoxLicense;
    }
}