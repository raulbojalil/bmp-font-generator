using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BMPFontGenerator
{
    public partial class MagnifyingGlassForm : Form
    {
        public MagnifyingGlassForm()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap image)
        {
            pictureBox1.Size = new System.Drawing.Size(image.Width, image.Height);
            pictureBox1.Image = image;
            

        }

        public void SetImageLocation(Point location)
        {
            pictureBox1.Location = location;
            
        }
    }
}
