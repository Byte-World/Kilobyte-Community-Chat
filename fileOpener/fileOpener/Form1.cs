using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileOpener
{
    public class cord
    {
        public int X;
        public int Y;

        public cord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += Form1_MouseMove;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.Click += pictureBox1_Click;
        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cord cursor = new cord(e.X, e.Y);

            string text = "x = " + cursor.X + ", y = " + cursor.Y;
            label1.Text = text;

            if (picBoxClick == true)
            {
                int selectedIn = comboBox1.SelectedIndex;
                int brushSize = sizes[selectedIn];
                drawCurrentMarkerSpotCir(cursor, brushSize);
            }

            if (picMsUp == true)
            {
                picBoxClick = false;
            }
            else
            {

            }
            
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cord cursor = new cord(e.X, e.Y);

            string text = "x = " + cursor.X + ", y = " + cursor.Y;
            label1.Text = text;
        }

        public System.Drawing.SolidBrush whiteSol = new System.Drawing.SolidBrush(Color.White);
        public System.Drawing.Graphics graphics;
        public System.Drawing.SolidBrush blackSol = new System.Drawing.SolidBrush(Color.Black);
        public bool picBoxClick = false;
        public bool picMsUp = true;
        public int[] sizes = new int[10];
        public bool firstMark = true;
        public cord prevCord = new cord(0, 0);

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();
            graphics.FillRectangle(whiteSol, 0, 0, 2000, 2000);

            for (int i = 0; i < 10; i++)
            {
                string currentSet;
                int x = i + 1;
                currentSet = x.ToString();

                comboBox1.Items.Add(currentSet);
            }
        }

        public void drawCurrentMarkerSpotCir(cord curPos, int sizePX)
        {
            int radius = sizePX / 2;
            graphics = pictureBox1.CreateGraphics();
            graphics.FillEllipse(blackSol, curPos.X + radius, curPos.Y + radius, sizePX, sizePX);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*
            picBoxClick = true;
            picMsUp = false;
            */
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            picBoxClick = true;
            picMsUp = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < sizes.Length; i++)
            {
                sizes[i] = i + 1;
            }
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            picMsUp = true;
        }
    }
}
