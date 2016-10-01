using System;
using System.Windows.Forms;

namespace IssueCreator
{
    public partial class pictureboxEnlarge : Form
    {
        public string picturePath;
        
        public pictureboxEnlarge()
        {
            InitializeComponent();
        }

        private void EnlargePicture_Load(object sender, EventArgs e)
        {
            pictureLarge.ImageLocation = picturePath;
        }

        private void pictureLarge_Click(object sender, EventArgs e)
        {

        }
    }
}
