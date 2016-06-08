namespace IssueCreator
{
    partial class pictureboxEnlarge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pictureboxEnlarge));
            this.pictureLarge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureLarge
            // 
            this.pictureLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureLarge.Location = new System.Drawing.Point(-2, 1);
            this.pictureLarge.Name = "pictureLarge";
            this.pictureLarge.Size = new System.Drawing.Size(1143, 962);
            this.pictureLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLarge.TabIndex = 0;
            this.pictureLarge.TabStop = false;
            // 
            // pictureboxEnlarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1138, 963);
            this.Controls.Add(this.pictureLarge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pictureboxEnlarge";
            this.Text = "EnlargePicture";
            this.Load += new System.EventHandler(this.EnlargePicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureLarge;
    }
}