using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonochromeConverting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string path = openFileDialog1.FileName;
            Bitmap firstImage = new Bitmap(path);
            Bitmap finalImage = new Bitmap(firstImage.Width,firstImage.Height);
            Graphics g = this.CreateGraphics();

            Color a = Color.Black;
            Color b = Color.White;
            Color average = Color.FromArgb(96,96,96);
            int av = (average.R + average.G + average.B) / 3;
            int x = 0;

            for(int i = 0; i < firstImage.Width; ++i)
            {
                for(int j = 0; j < firstImage.Height; ++j)
                {
                    a = firstImage.GetPixel(i,j);
                    x = (a.R + a.G + a.B) / 3;
                    if (x > av)
                    {
                        b = Color.White;
                    }
                    else
                    {
                        b = Color.Black;
                    }
                    finalImage.SetPixel(i,j,b);
                }
            }
            finalImage.Save("Monochrome.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Finished");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
