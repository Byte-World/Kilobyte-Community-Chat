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
            this.KeyDown += Form1_KeyDown;
        }

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

        public class tools
        {
            static public Color setColor = Color.Black;
            public penTool pen = new penTool(setColor);
            public moveTool move = new moveTool();
            public regCursor cursor = new regCursor();

            public void changeCurrentSet(string nonSelect)
            {
                pen.selected = false;
                move.selected = false;
                cursor.selected = false;

                if (nonSelect == "pen")
                {
                    pen.selected = true;
                }
                else
                {
                    if (nonSelect == "move")
                    {
                        move.selected = true;
                    }
                    else
                    {
                        if (nonSelect == "cursor")
                        {
                            cursor.selected = true;
                        }
                    }
                }
            }
        }

        public class toolType
        {
            public bool selected;
        }

        public class penTool : toolType
        {
            Color penColor;

            public penTool(Color setPenColor)
            {
                penColor = setPenColor;
            }
        }

        public class moveTool : toolType
        {
            //int mode = 1;
        }

        public class regCursor : toolType
        {

        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cord cursor = new cord(e.X, e.Y);

            string text = "x = " + cursor.X + ", y = " + cursor.Y;
            label1.Text = text;
            int selectedIn = comboBox1.SelectedIndex;
            int brushSize;

            if (picBoxClick == true && selectedIn < 11 && fileExists && allTools.pen.selected == true)
            {
                selectedIn = comboBox1.SelectedIndex;
                brushSize = sizes[selectedIn];
                if (aDown == true)
                {
                    brushSize = brushSize * 2;
                }
                drawCurrentMarkerSpotCir(cursor, brushSize);
            }

            if (picMsUp == true)
            {
                picBoxClick = false;
            }
            else
            {
                if (firstMark == false && selectedIn < 11 && fileExists && allTools.pen.selected == true)
                {
                    selectedIn = comboBox1.SelectedIndex;
                    brushSize = sizes[selectedIn];
                    System.Drawing.Pen customSizeBl = new System.Drawing.Pen(Color.Black, brushSize);
                    graphics = pictureBox1.CreateGraphics();
                    graphics.DrawLine(customSizeBl, prevCord.X, prevCord.Y, cursor.X, cursor.Y);
                }
                else
                {
                    firstMark = false;
                }
            }
            prevCord.X = cursor.X;
            prevCord.Y = cursor.Y;
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
        public bool aDown = false;
        public bool fileExists = false;
        static public tools allTools = new tools();

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();
            graphics.FillRectangle(whiteSol, 0, 0, 2000, 2000);
            fileExists = true;
        }

        public void trackSelection(cord clickedCord)
        {
            Bitmap currentPic = new Bitmap(pictureBox1.Image);
            Color clickedColor = currentPic.GetPixel(clickedCord.X, clickedCord.Y);
        }


        public void drawCurrentMarkerSpotCir(cord curPos, int sizePX)
        {
            int radius = sizePX / 2;
            graphics = pictureBox1.CreateGraphics();
            //graphics.FillEllipse(blackSol, curPos.X, curPos.Y, sizePX, sizePX);
            graphics.FillEllipse(blackSol, curPos.X - radius, curPos.Y - radius, sizePX, sizePX);
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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            radioButton1.Checked = true;
            for (int i = 0; i < sizes.Length; i++)
            {
                sizes[i] = i + 1;
            }

            comboBox1.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                string currentSet;
                int x = i + 1;
                currentSet = x.ToString();

                comboBox1.Items.Add(currentSet);
            }

            comboBox1.SelectedIndex = 0;
        }

        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            picMsUp = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                aDown = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                aDown = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            allTools.changeCurrentSet("pen");
            label3.Text = "Pen";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            allTools.changeCurrentSet("move");
            label3.Text = "Move";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            allTools.changeCurrentSet("cursor");
            label3.Text = "Cursor";
        }
    }
}
