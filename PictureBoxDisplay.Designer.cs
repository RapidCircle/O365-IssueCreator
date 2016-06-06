namespace IssueCreator
{
    partial class PictureBoxDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureMain = new System.Windows.Forms.PictureBox();
            this.checkBoxMain = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureMain
            // 
            this.pictureMain.Location = new System.Drawing.Point(6, 3);
            this.pictureMain.Name = "pictureMain";
            this.pictureMain.Size = new System.Drawing.Size(291, 226);
            this.pictureMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureMain.TabIndex = 0;
            this.pictureMain.TabStop = false;
            this.pictureMain.Click += new System.EventHandler(this.pictureMain_Click);
            // 
            // checkBoxMain
            // 
            this.checkBoxMain.AutoSize = true;
            this.checkBoxMain.Location = new System.Drawing.Point(23, 26);
            this.checkBoxMain.Name = "checkBoxMain";
            this.checkBoxMain.Size = new System.Drawing.Size(28, 27);
            this.checkBoxMain.TabIndex = 1;
            this.checkBoxMain.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMain);
            this.panel1.Controls.Add(this.checkBoxMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 75);
            this.panel1.TabIndex = 2;
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Location = new System.Drawing.Point(93, 26);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(70, 25);
            this.lblMain.TabIndex = 2;
            this.lblMain.Text = "label1";
            // 
            // PictureBoxDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureMain);
            this.Name = "PictureBoxDisplay";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureMain;
        private System.Windows.Forms.CheckBox checkBoxMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMain;
    }
}
