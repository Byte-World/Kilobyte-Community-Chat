using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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

                if (strokeNum == 1)
                {
                    int radius = brushSize / 2;
                    cord centerCord = new cord(cursor.X - radius, cursor.Y - radius);
                    cord[] drawnCordsToAdd = calculateCircle(centerCord, brushSize);

                    for (int i = 0; i < drawnCordsToAdd.Length; i++)
                    {
                        currentStrokeCordsA[currentStrokeANum] = drawnCordsToAdd[i];
                        currentStrokeANum++;
                    }

                    firstGPath.AddEllipse(cursor.X, cursor.Y, brushSize, brushSize);
                }

                if (strokeNum == 2)
                {
                    int radius = brushSize / 2;
                    cord centerCord = new cord(cursor.X - radius, cursor.Y - radius);
                    cord[] drawnCordsToAdd = calculateCircle(centerCord, brushSize);

                    for (int i = 0; i < drawnCordsToAdd.Length; i++)
                    {
                        currentStrokeCordsA[currentStrokeBNum] = drawnCordsToAdd[i];
                        currentStrokeBNum++;
                    }
                }
            }

            if (picMsUp == true)
            {
                picBoxClick = false;
                strokeNum++;
            }
            else
            {
                if (firstMark == false && selectedIn < 11 && fileExists && allTools.pen.selected == true)
                {
                    selectedIn = comboBox1.SelectedIndex;
                    brushSize = sizes[selectedIn];
                    if (aDown == true)
                    {
                        brushSize = brushSize * 2;
                    }
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
        public System.Drawing.SolidBrush blueSol = new System.Drawing.SolidBrush(Color.Blue);
        public System.Drawing.SolidBrush redSol = new System.Drawing.SolidBrush(Color.Red);
        public System.Drawing.SolidBrush magentaSol = new System.Drawing.SolidBrush(Color.Magenta);
        public System.Drawing.Pen blackPen = new System.Drawing.Pen(Color.Black, 1);
        public System.Drawing.Pen whitePen = new System.Drawing.Pen(Color.White, 1);
        public System.Drawing.Pen bluePen = new System.Drawing.Pen(Color.Blue, 1);
        public bool picBoxClick = false;
        public bool picMsUp = true;
        public int[] sizes = new int[10];
        public bool firstMark = true;
        public cord prevCord = new cord(0, 0);
        public bool aDown = false;
        public bool fileExists = false;
        static public tools allTools = new tools();
        public System.Drawing.Drawing2D.GraphicsPath cPath = new System.Drawing.Drawing2D.GraphicsPath();
        public cord[] firstSelectionCords;
        public cord[] secondSelectionCords;
        public int strokeNum = 1;
        public cord[] currentStrokeCordsA;
        public int currentStrokeANum = 0;
        public cord[] currentStrokeCordsB;
        public int currentStrokeBNum = 0;
        GraphicsPath firstGPath = new GraphicsPath();

        

        private void moveCordsLeft(cord[] currentCords, int pixToMove)
        {
            cord[] leftMoveCords = new cord[currentCords.Length];
            System.Drawing.Drawing2D.GraphicsPath erasePath = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath nextPath = new System.Drawing.Drawing2D.GraphicsPath();
            erasePath.StartFigure();
            nextPath.StartFigure();

            for (int i = 0; i < currentCords.Length; i++)
            {
                // x - pixToMove
                cord currentEditCord = new cord(currentCords[i].X, currentCords[i].Y);
                cord nextCord = new cord(currentEditCord.X - pixToMove, currentEditCord.Y);
                leftMoveCords[i].X = nextCord.X;
                leftMoveCords[i].Y = nextCord.Y;
            }

            for (int b = 0; b < currentCords.Length; b++)
            {
                graphics = pictureBox1.CreateGraphics();
                graphics.FillRectangle(whiteSol, currentCords[b].X, currentCords[b].Y, 1, 1);
            }

            for (int c = 0; c < currentCords.Length; c++)
            {
                graphics = pictureBox1.CreateGraphics();
                graphics.FillRectangle(blackSol, leftMoveCords[c].X, leftMoveCords[c].Y, 1, 1);
            }

            nextPath.CloseFigure();
            erasePath.CloseFigure();
        }

        public int[] rectParams = new int[4];
        public bool rectSet = false;

        public void generateRectangle()
        {
            if (fileExists == true)
            {
                GraphicsPath rectangle = new GraphicsPath();

                rectangle.StartFigure();

                Rectangle setRect = new Rectangle(rectParams[0], rectParams[1], rectParams[2], rectParams[3]);
                rectangle.AddRectangle(setRect);

                rectangle.CloseFigure();

                graphics = pictureBox1.CreateGraphics();
                graphics.FillRectangle(blueSol, setRect);
                rectSet = true;
            }
        }

        //Rectangle is blue (blueSol), Polygon is red (redSol), overlap is magenta (magentaSol). Blank is white (whiteSol).

        public void moveRectangle()
        {
            if (rectSet == true) {
                Rectangle prevRect = new Rectangle(rectParams[0], rectParams[1], rectParams[2], rectParams[3]);
                rectParams[0] = rectParams[0] + 5;

                Rectangle currentRect = new Rectangle(rectParams[0], rectParams[1], rectParams[2], rectParams[3]);

                graphics = pictureBox1.CreateGraphics();
                graphics.FillRectangle(whiteSol, prevRect);

                updatePolygon();

                graphics.FillRectangle(blueSol, currentRect);
            }
        }

        public Point[] polyGonArray = new Point[5];
        public void generatePolygon()
        {
            if (fileExists == true)
            {
                graphics = pictureBox1.CreateGraphics();
                //graphics.DrawPolygon();
                graphics.FillPolygon(redSol, polyGonArray);
            }
        }

        public void movePolyGon()
        {
            Point[] prevPoints = new Point[5];

            for (int b = 0; b < prevPoints.Length; b++)
            {
                prevPoints[b].X = polyGonArray[b].X;
                prevPoints[b].Y = polyGonArray[b].Y;
            }

            for (int i = 0; i < polyGonArray.Length; i++)
            {
                polyGonArray[i].X = polyGonArray[i].X - 5;
            }

            graphics = pictureBox1.CreateGraphics();
            graphics.FillPolygon(whiteSol, prevPoints);

            updateRect();
            
            graphics.FillPolygon(redSol, polyGonArray);
        }

        public void checkShapeOverlap()
        {
            GraphicsPath rectPath = new GraphicsPath();
            rectPath.StartFigure();

            Rectangle currentRect = new Rectangle(rectParams[0], rectParams[1], rectParams[2], rectParams[3]);
            rectPath.AddRectangle(currentRect);
            rectPath.CloseFigure();

            Region rectangleRegion = new Region(rectPath);

            GraphicsPath polyPath = new GraphicsPath();
            polyPath.StartFigure();

            polyPath.AddPolygon(polyGonArray);
            polyPath.CloseFigure();

            Region polyRegion = new Region(polyPath);

            rectangleRegion.Intersect(polyRegion);

            graphics = pictureBox1.CreateGraphics();
            graphics.FillRegion(magentaSol, rectangleRegion);
        }

        public void updateRect()
        {
            graphics = pictureBox1.CreateGraphics();
            graphics.FillRectangle(blueSol, rectParams[0], rectParams[1], rectParams[2], rectParams[3]);
        }

        public void updatePolygon()
        {
            graphics = pictureBox1.CreateGraphics();
            graphics.FillPolygon(redSol, polyGonArray);
        }

        public cord[] calculateCircle(cord placeClicked, int size)
        {
            cord[] validTestCords = new cord[size * size];
            int radius = size / 2;
            cord topLeftCord = new cord(placeClicked.X - radius, placeClicked.Y - radius);
            int allowedAmount = 0;

            for (int i = 0; i < size; i++)
            {
                for (int b = 0; b < size; b++)
                {
                    cord currentCord = new cord(topLeftCord.X + i, topLeftCord.Y + b);
                    validTestCords[i * 10 + b].X = currentCord.X;
                    validTestCords[i * 10 + b].Y = currentCord.Y;
                }
            }

            for (int z = 0; 0 < size * size; z++)
            {
                cord testInsideCircle = new cord(validTestCords[z].X, validTestCords[z].Y);
                bool cordInCircle = insideCircle(topLeftCord, radius, testInsideCircle);

                if (cordInCircle == true)
                {
                    allowedAmount++;
                }
                else
                {
                    validTestCords[z] = null;
                }
            }

            cord[] realCords = new cord[allowedAmount];
            int counter = 0;

            for (int h = 0; h < size * size; h++)
            {
                if (validTestCords[h] == null) {
                    validTestCords[h].X = 0;
                    validTestCords[h].Y = 0;
                }
                else
                {
                    realCords[counter].X = validTestCords[h].X;
                    realCords[counter].Y = validTestCords[h].Y;
                }
            }

            return realCords;
        }

        

        private void moveCordsRight(cord[] currentCords, int pixToMove)
        {
            cord[] rightMoveCords = new cord[currentCords.Length];
            System.Drawing.Drawing2D.GraphicsPath erasePath = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath nextPath = new System.Drawing.Drawing2D.GraphicsPath();
            erasePath.StartFigure();
            nextPath.StartFigure();

            for (int i = 0; i < currentCords.Length; i++)
            {
                // x - pixToMove
                cord currentEditCord = new cord(currentCords[i].X, currentCords[i].Y);
                cord nextCord = new cord(currentEditCord.X + pixToMove, currentEditCord.Y);
                rightMoveCords[i].X = nextCord.X;
                rightMoveCords[i].Y = nextCord.Y;
            }

            for (int b = 0; b < currentCords.Length; b++)
            {
                graphics = pictureBox1.CreateGraphics();
                graphics.FillRectangle(whiteSol, currentCords[b].X, currentCords[b].Y, 1, 1);
            }

            for (int c = 0; c < currentCords.Length; c++)
            {
                graphics = pictureBox1.CreateGraphics();
                graphics.FillRectangle(blackSol, rightMoveCords[c].X, rightMoveCords[c].Y, 1, 1);
            }

            nextPath.CloseFigure();
            erasePath.CloseFigure();
        }

        private void addCords(int arrayNo, cord clickedCord, int penSize, cord topLeftCord)
        {
            int runTime = penSize * penSize;
            cord bottomRightCord = new cord(topLeftCord.X + penSize, topLeftCord.Y + penSize);
            cord[] workingCords = new cord[runTime];
            int properPix = 0;

            for (int x = 0; x < penSize; x++)
            {
                for (int y = 0; y < penSize; y++)
                {
                    int currentElement = x * 10 + y;
                    cord setCord = new cord(topLeftCord.X + x, topLeftCord.Y + y);
                    workingCords[currentElement] = setCord;
                }
            }

            for (int i = 0; i < penSize; i++)
            {
                for (int b = 0; b < penSize; b++)
                {
                    cord testCord = new cord(topLeftCord.X + i, topLeftCord.Y + b);
                    bool cordInCircle = insideCircle(topLeftCord, penSize / 2, testCord);
                    int currentElement = i * 10 + b;

                    if (cordInCircle == true)
                    {
                        properPix++;
                    }
                    else
                    {
                        workingCords[currentElement] = null;
                    }
                }
            }
        }

        public bool insideCircle(cord circle, int circleR, cord testCord)
        {
            int distX = 0;
            int distY = 0;

            if (circle.X < testCord.X)
            {
                distX = testCord.X - circle.X;
            }
            else
            {
                if (circle.X > testCord.X)
                {
                    distX = circle.X - testCord.X;
                }
                else
                {
                    if (circle.X == testCord.X)
                    {
                        distX = 0;
                    }
                }
            }

            if (circle.Y < testCord.Y)
            {
                distY = testCord.Y - circle.Y;
            }
            else
            {
                if (circle.Y > testCord.Y)
                {
                    distY = circle.Y - testCord.Y;
                }
                else
                {
                    if (circle.Y == testCord.Y)
                    {
                        distY = 0;
                    }
                }
            }

            int compDist = distX * distX + distY * distY;

            if (compDist == circleR * circleR || compDist < circleR * circleR)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphics = pictureBox1.CreateGraphics();
            graphics.FillRectangle(whiteSol, 0, 0, 2000, 2000);
            fileExists = true;
        }

        public bool checkSide(Color currentColor, int currentCordX, int currentCordY)
        {
            Bitmap picBitmap = new Bitmap(pictureBox1.Image);
            Color testColor = picBitmap.GetPixel(currentCordX, currentCordY);

            if (currentColor == testColor)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            rectParams[0] = 130;
            rectParams[1] = 140;
            rectParams[2] = 100;
            rectParams[3] = 100;
            polyGonArray[0].X = 642;
            polyGonArray[0].Y = 111;
            polyGonArray[1].X = 714;
            polyGonArray[1].Y = 176;
            polyGonArray[2].X = 661;
            polyGonArray[2].Y = 241;
            polyGonArray[3].X = 832;
            polyGonArray[3].Y = 243;
            polyGonArray[4].X = 824;
            polyGonArray[4].Y = 104;

            firstGPath.StartFigure();
            cPath.StartFigure();
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

            if (e.KeyCode == Keys.Left)
            {
                movePolyGon();
                checkShapeOverlap();
            }

            if (e.KeyCode == Keys.Right)
            {
                moveRectangle();
                checkShapeOverlap();
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


        private System.Drawing.Drawing2D.GraphicsPath setGraphicsPath(cord[] setCords)
        {
            System.Drawing.Drawing2D.GraphicsPath returnPath = new System.Drawing.Drawing2D.GraphicsPath();
            returnPath.StartFigure();

            for (int i = 0; i < setCords.Length; i++)
            {
                Rectangle pixRect = new Rectangle(setCords[i].X, setCords[i].Y, 1, 1);
                cPath.AddRectangle(pixRect);
            }

            return returnPath;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateRectangle();
        }

        private void randomPolyGonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generatePolygon();
        }
    }
}
