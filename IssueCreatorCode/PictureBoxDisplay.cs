using System;
using System.Windows.Forms;

namespace IssueCreator
{
    public partial class PictureBoxDisplay : UserControl
    {
        private string name;
        public event EventHandler Enlarge;

        public string ImageLocation
        {
            get { return pictureMain.ImageLocation; }
            set { pictureMain.ImageLocation = value; }
        }

        public bool Checked
        {
            get { return checkBoxMain.Checked; }
            set { checkBoxMain.Checked = value; }
        }

        public string Filename
        {
            get { return name;}

            set
            {
                name = value;
                lblMain.Text = value;
            }
        }

        public PictureBoxDisplay()
        {
            InitializeComponent();
        }

        private void pictureMain_Click(object sender, EventArgs e)
        {
            if (Enlarge != null)
            {
                Enlarge(this, e);
            }
        }
    }
}
