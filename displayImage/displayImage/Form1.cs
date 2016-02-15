using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace displayImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += Form1_MouseMove;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox2.MouseMove += pictureBox2_MouseMove;
        }

        void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int cursorX = e.X;
            int cursorY = e.Y;
            string text = "x = " + cursorX + ", y = " + cursorY;
            label2.Text = text;
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int cursorX = e.X;
            int cursorY = e.Y;
            string text = "x = " + cursorX + ", y = " + cursorY;
            label2.Text = text;
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int cursorX = e.X;
            int cursorY = e.Y;
            string text = "x = " + cursorX + ", y = " + cursorY;
            label2.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog upload = new OpenFileDialog();

            upload.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (upload.ShowDialog() == DialogResult.OK)
            {
                pictureBoxPic = new Bitmap(upload.FileName);
                pictureBox1.Image = new Bitmap(upload.FileName);
                label1.Text = upload.FileName;
                imageSet = true;
            }
        }

        public Boolean imageSet = false;
        public Bitmap pictureBoxPic;

        public Bitmap cropImagePiece(Rectangle r, Bitmap imageToCrop)
        {
            Bitmap cropImg = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(cropImg);
            g.DrawImage(imageToCrop, -r.X, -r.Y);
            return cropImg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle cropRect = new Rectangle(161, 73, 80, 80);
            Bitmap croppedPiece = cropImagePiece(cropRect, pictureBoxPic);
            pictureBox2.Image = croppedPiece;
        }
    }
}
