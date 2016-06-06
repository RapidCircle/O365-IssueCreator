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
            this.grpSharePoint = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.grpSharePoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSharePoint
            // 
            this.grpSharePoint.Controls.Add(this.buttonConnect);
            this.grpSharePoint.Controls.Add(this.label3);
            this.grpSharePoint.Controls.Add(this.textPassword);
            this.grpSharePoint.Controls.Add(this.label2);
            this.grpSharePoint.Controls.Add(this.textUsername);
            this.grpSharePoint.Location = new System.Drawing.Point(12, 12);
            this.grpSharePoint.Name = "grpSharePoint";
            this.grpSharePoint.Size = new System.Drawing.Size(919, 142);
            this.grpSharePoint.TabIndex = 0;
            this.grpSharePoint.TabStop = false;
            this.grpSharePoint.Text = "SharePoint Details";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(679, 41);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(182, 69);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password:";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(136, 79);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(516, 31);
            this.textPassword.TabIndex = 4;
            this.textPassword.Text = "E$Emental";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(136, 41);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(516, 31);
            this.textUsername.TabIndex = 2;
            this.textUsername.Text = "daniel.mcpherson@rapidcircle.com";
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 180);
            this.Controls.Add(this.grpSharePoint);
            this.Name = "Connect";
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpSharePoint.ResumeLayout(false);
            this.grpSharePoint.PerformLayout();
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
    }
}

