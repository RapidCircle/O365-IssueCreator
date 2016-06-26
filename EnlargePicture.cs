using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.pictureLarge.ImageLocation = picturePath;
        }

        private void pictureLarge_Click(object sender, EventArgs e)
        {

        }
    }
}
