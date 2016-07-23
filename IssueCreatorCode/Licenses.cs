using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IssueCreator
{
    public partial class frmLicenses : Form
    {
        public frmLicenses()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBoxLicenses.SelectedItem.ToString())
            {
                case "Rapid Issue":
                    richTextBoxLicense.Text = File.ReadAllText("licenses\\RapidIssue.txt");
                    break;
                case "ModelText":
                    richTextBoxLicense.Text = File.ReadAllText("licenses\\ModelText.txt");
                    break;
                default:
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLicenses_Load(object sender, EventArgs e)
        {
            listBoxLicenses.SelectedIndex = 0;
        }
    }
}
