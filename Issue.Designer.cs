namespace IssueCreator
{
    partial class Issue
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Issue));
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textComment = new System.Windows.Forms.TextBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbeDescription = new RichTextBoxExtended.RichTextBoxExtended();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.notifyIconSQI = new System.Windows.Forms.NotifyIcon(this.components);
            this.flowPictureLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1096, 1132);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(186, 61);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textComment);
            this.groupBox1.Controls.Add(this.comboCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rtbeDescription);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboPriority);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(53, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1421, 753);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Issue Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 529);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Comments:";
            // 
            // textComment
            // 
            this.textComment.Location = new System.Drawing.Point(177, 526);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.Size = new System.Drawing.Size(1169, 166);
            this.textComment.TabIndex = 11;
            // 
            // comboCategory
            // 
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Items.AddRange(new object[] {
            "(1) Category1",
            "(2) Category2",
            "(3) Category3"});
            this.comboCategory.Location = new System.Drawing.Point(177, 486);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(427, 33);
            this.comboCategory.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 490);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Category:";
            // 
            // rtbeDescription
            // 
            this.rtbeDescription.AcceptsTab = false;
            this.rtbeDescription.AutoWordSelection = true;
            this.rtbeDescription.DetectURLs = true;
            this.rtbeDescription.Location = new System.Drawing.Point(177, 216);
            this.rtbeDescription.Name = "rtbeDescription";
            this.rtbeDescription.ReadOnly = false;
            // 
            // 
            // 
            this.rtbeDescription.RichTextBox.AutoWordSelection = true;
            this.rtbeDescription.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbeDescription.RichTextBox.Location = new System.Drawing.Point(0, 26);
            this.rtbeDescription.RichTextBox.Name = "rtb1";
            this.rtbeDescription.RichTextBox.Size = new System.Drawing.Size(1169, 237);
            this.rtbeDescription.RichTextBox.TabIndex = 1;
            this.rtbeDescription.ShowBold = true;
            this.rtbeDescription.ShowCenterJustify = true;
            this.rtbeDescription.ShowColors = true;
            this.rtbeDescription.ShowCopy = true;
            this.rtbeDescription.ShowCut = true;
            this.rtbeDescription.ShowFont = true;
            this.rtbeDescription.ShowFontSize = true;
            this.rtbeDescription.ShowItalic = true;
            this.rtbeDescription.ShowLeftJustify = true;
            this.rtbeDescription.ShowOpen = true;
            this.rtbeDescription.ShowPaste = true;
            this.rtbeDescription.ShowRedo = true;
            this.rtbeDescription.ShowRightJustify = true;
            this.rtbeDescription.ShowSave = true;
            this.rtbeDescription.ShowStamp = true;
            this.rtbeDescription.ShowStrikeout = true;
            this.rtbeDescription.ShowToolBarText = false;
            this.rtbeDescription.ShowUnderline = true;
            this.rtbeDescription.ShowUndo = true;
            this.rtbeDescription.Size = new System.Drawing.Size(1169, 263);
            this.rtbeDescription.StampAction = RichTextBoxExtended.StampActions.EditedBy;
            this.rtbeDescription.StampColor = System.Drawing.Color.Blue;
            this.rtbeDescription.TabIndex = 8;
            // 
            // 
            // 
            this.rtbeDescription.Toolbar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.rtbeDescription.Toolbar.ButtonSize = new System.Drawing.Size(16, 16);
            this.rtbeDescription.Toolbar.Divider = false;
            this.rtbeDescription.Toolbar.DropDownArrows = true;
            this.rtbeDescription.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.rtbeDescription.Toolbar.Name = "tb1";
            this.rtbeDescription.Toolbar.ShowToolTips = true;
            this.rtbeDescription.Toolbar.Size = new System.Drawing.Size(1169, 26);
            this.rtbeDescription.Toolbar.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description:";
            // 
            // comboPriority
            // 
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Items.AddRange(new object[] {
            "(1) High",
            "(2) Normal",
            "(3) Low"});
            this.comboPriority.Location = new System.Drawing.Point(178, 160);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(425, 33);
            this.comboPriority.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Priority:";
            // 
            // comboStatus
            // 
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Active",
            "Resolved",
            "Closed"});
            this.comboStatus.Location = new System.Drawing.Point(178, 120);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(426, 33);
            this.comboStatus.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(177, 38);
            this.textTitle.MaxLength = 255;
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(1169, 31);
            this.textTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1288, 1132);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(186, 61);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // notifyIconSQI
            // 
            this.notifyIconSQI.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconSQI.Icon")));
            this.notifyIconSQI.Text = "SharePoint QuickIssue";
            this.notifyIconSQI.Visible = true;
            this.notifyIconSQI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSQI_MouseDoubleClick);
            // 
            // flowPictureLayout
            // 
            this.flowPictureLayout.AutoScroll = true;
            this.flowPictureLayout.Location = new System.Drawing.Point(99, 12);
            this.flowPictureLayout.Name = "flowPictureLayout";
            this.flowPictureLayout.Size = new System.Drawing.Size(1300, 300);
            this.flowPictureLayout.TabIndex = 3;
            // 
            // Issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1495, 1223);
            this.Controls.Add(this.flowPictureLayout);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSave);
            this.Name = "Issue";
            this.ShowInTaskbar = false;
            this.Text = "Issue";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.Issue_Activated);
            this.Load += new System.EventHandler(this.Issue_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label label1;
        private RichTextBoxExtended.RichTextBoxExtended rtbeDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textComment;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.NotifyIcon notifyIconSQI;
        private System.Windows.Forms.FlowLayoutPanel flowPictureLayout;
    }
}