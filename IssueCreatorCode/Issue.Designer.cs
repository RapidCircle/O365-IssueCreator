﻿using System.ComponentModel;
using System.Windows.Forms;

namespace IssueCreator
{
    partial class Issue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Issue));
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboAssigned = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textComment = new System.Windows.Forms.TextBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.linkSite = new System.Windows.Forms.LinkLabel();
            this.linkIssuesList = new System.Windows.Forms.LinkLabel();
            this.linkScreenshots = new System.Windows.Forms.LinkLabel();
            this.checkDelete = new System.Windows.Forms.CheckBox();
            this.linkAbout = new System.Windows.Forms.LinkLabel();
            this.linkConfigureIssueForm = new System.Windows.Forms.LinkLabel();
            this.linkUpgrade = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1084, 1071);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(186, 61);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboAssigned);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textComment);
            this.groupBox1.Controls.Add(this.comboCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboPriority);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(42, 454);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1421, 602);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Issue Details";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.AutoWordSelection = true;
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDescription.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxDescription.Size = new System.Drawing.Size(1167, 140);
            this.richTextBoxDescription.TabIndex = 15;
            this.richTextBoxDescription.Text = "";
            this.richTextBoxDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxDescription_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Assigned:";
            // 
            // comboAssigned
            // 
            this.comboAssigned.FormattingEnabled = true;
            this.comboAssigned.Location = new System.Drawing.Point(177, 76);
            this.comboAssigned.Name = "comboAssigned";
            this.comboAssigned.Size = new System.Drawing.Size(713, 33);
            this.comboAssigned.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Comments:";
            // 
            // textComment
            // 
            this.textComment.Location = new System.Drawing.Point(177, 438);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.Size = new System.Drawing.Size(1169, 142);
            this.textComment.TabIndex = 6;
            // 
            // comboCategory
            // 
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(177, 389);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(427, 33);
            this.comboCategory.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Category:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description:";
            // 
            // comboPriority
            // 
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Location = new System.Drawing.Point(178, 172);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(426, 33);
            this.comboPriority.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Priority:";
            // 
            // comboStatus
            // 
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(178, 123);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(426, 33);
            this.comboStatus.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(177, 30);
            this.textTitle.MaxLength = 255;
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(1169, 31);
            this.textTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(1276, 1071);
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
            this.notifyIconSQI.Text = "Rapid Issue for O365";
            this.notifyIconSQI.Visible = true;
            this.notifyIconSQI.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSQI_MouseDoubleClick);
            // 
            // flowPictureLayout
            // 
            this.flowPictureLayout.AutoScroll = true;
            this.flowPictureLayout.Location = new System.Drawing.Point(71, 42);
            this.flowPictureLayout.Name = "flowPictureLayout";
            this.flowPictureLayout.Size = new System.Drawing.Size(1300, 300);
            this.flowPictureLayout.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowPictureLayout);
            this.groupBox2.Location = new System.Drawing.Point(42, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1422, 366);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Screenshots";
            // 
            // linkSite
            // 
            this.linkSite.AutoSize = true;
            this.linkSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSite.Location = new System.Drawing.Point(1222, 24);
            this.linkSite.Name = "linkSite";
            this.linkSite.Size = new System.Drawing.Size(137, 29);
            this.linkSite.TabIndex = 6;
            this.linkSite.TabStop = true;
            this.linkSite.Text = "Project Site";
            this.linkSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSite_LinkClicked);
            // 
            // linkIssuesList
            // 
            this.linkIssuesList.AutoSize = true;
            this.linkIssuesList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkIssuesList.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkIssuesList.Location = new System.Drawing.Point(1067, 24);
            this.linkIssuesList.Name = "linkIssuesList";
            this.linkIssuesList.Size = new System.Drawing.Size(125, 29);
            this.linkIssuesList.TabIndex = 5;
            this.linkIssuesList.TabStop = true;
            this.linkIssuesList.Text = "Issues List";
            this.linkIssuesList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkIssuesList_LinkClicked);
            // 
            // linkScreenshots
            // 
            this.linkScreenshots.AutoSize = true;
            this.linkScreenshots.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkScreenshots.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkScreenshots.Location = new System.Drawing.Point(885, 24);
            this.linkScreenshots.Name = "linkScreenshots";
            this.linkScreenshots.Size = new System.Drawing.Size(147, 29);
            this.linkScreenshots.TabIndex = 7;
            this.linkScreenshots.TabStop = true;
            this.linkScreenshots.Text = "Screenshots";
            this.linkScreenshots.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkScreenshots_LinkClicked);
            // 
            // checkDelete
            // 
            this.checkDelete.AutoSize = true;
            this.checkDelete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkDelete.Location = new System.Drawing.Point(693, 1088);
            this.checkDelete.Name = "checkDelete";
            this.checkDelete.Size = new System.Drawing.Size(361, 29);
            this.checkDelete.TabIndex = 8;
            this.checkDelete.Text = "Delete screenshots after upload?";
            this.checkDelete.UseVisualStyleBackColor = true;
            this.checkDelete.CheckedChanged += new System.EventHandler(this.checkDelete_CheckedChanged);
            // 
            // linkAbout
            // 
            this.linkAbout.AutoSize = true;
            this.linkAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAbout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAbout.Location = new System.Drawing.Point(1388, 24);
            this.linkAbout.Name = "linkAbout";
            this.linkAbout.Size = new System.Drawing.Size(75, 29);
            this.linkAbout.TabIndex = 9;
            this.linkAbout.TabStop = true;
            this.linkAbout.Text = "About";
            this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
            // 
            // linkConfigureIssueForm
            // 
            this.linkConfigureIssueForm.AutoSize = true;
            this.linkConfigureIssueForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkConfigureIssueForm.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkConfigureIssueForm.Location = new System.Drawing.Point(35, 1088);
            this.linkConfigureIssueForm.Name = "linkConfigureIssueForm";
            this.linkConfigureIssueForm.Size = new System.Drawing.Size(475, 29);
            this.linkConfigureIssueForm.TabIndex = 10;
            this.linkConfigureIssueForm.TabStop = true;
            this.linkConfigureIssueForm.Text = "Configure Issue List Screenshot Extensions";
            this.linkConfigureIssueForm.Visible = false;
            this.linkConfigureIssueForm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConfigureIssueForm_LinkClicked);
            // 
            // linkUpgrade
            // 
            this.linkUpgrade.AutoSize = true;
            this.linkUpgrade.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkUpgrade.Location = new System.Drawing.Point(42, 27);
            this.linkUpgrade.Name = "linkUpgrade";
            this.linkUpgrade.Size = new System.Drawing.Size(148, 25);
            this.linkUpgrade.TabIndex = 11;
            this.linkUpgrade.TabStop = true;
            this.linkUpgrade.Text = "Version check";
            this.linkUpgrade.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpgrade_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBoxDescription);
            this.panel1.Location = new System.Drawing.Point(178, 229);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 142);
            this.panel1.TabIndex = 16;
            // 
            // Issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1495, 1144);
            this.Controls.Add(this.linkUpgrade);
            this.Controls.Add(this.linkConfigureIssueForm);
            this.Controls.Add(this.linkAbout);
            this.Controls.Add(this.checkDelete);
            this.Controls.Add(this.linkScreenshots);
            this.Controls.Add(this.linkSite);
            this.Controls.Add(this.linkIssuesList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Issue";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapid Issue";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.Issue_Activated);
            this.Load += new System.EventHandler(this.Issue_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonSave;
        private GroupBox groupBox1;
        private ComboBox comboPriority;
        private Label label3;
        private ComboBox comboStatus;
        private Label label2;
        private TextBox textTitle;
        private Label label1;
        private Label label4;
        private Label label6;
        private TextBox textComment;
        private ComboBox comboCategory;
        private Label label5;
        private Button buttonCancel;
        private NotifyIcon notifyIconSQI;
        private FlowLayoutPanel flowPictureLayout;
        private GroupBox groupBox2;
        private LinkLabel linkSite;
        private LinkLabel linkIssuesList;
        private LinkLabel linkScreenshots;
        private CheckBox checkDelete;
        private Label label7;
        private ComboBox comboAssigned;
        private LinkLabel linkAbout;
        private LinkLabel linkConfigureIssueForm;
        private LinkLabel linkUpgrade;
        private RichTextBox richTextBoxDescription;
        private Panel panel1;
    }
}