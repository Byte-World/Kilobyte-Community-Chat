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
using Microsoft.VisualBasic;

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
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            this.MouseWheel += Form1_MouseWheel;
        }

        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (allTools.zoom.selected == true)
            {
                if (e.Delta != 0)
                {
                    if (e.Delta <= 0)
                    {
                        zoomOut();
                    }
                    else
                    {
                        cord mouseCord = new cord(e.X, e.Y);
                        zoomIn(mouseCord);
                    }
                }
            }
        }

        void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (allTools.zoom.selected == true)
            {
                if (e.Delta != 0)
                {
                    if (e.Delta <= 0)
                    {
                        zoomOut();
                    }
                    else
                    {
                        cord mouseCord = new cord(e.X, e.Y);
                        zoomIn(mouseCord);
                    }
                }
            }
        }

        public void zoomOut()
        {
            if (zoomStateOut == false)
            {
                Rectangle setRect = new Rectangle(0, 0, pictureBoxPic.Width, pictureBoxPic.Height);
                Graphics g = pictureBox1.CreateGraphics();
                g.FillRectangle(whiteSol, 0, 0, 2000, 2000);
                g.DrawImage(pictureBoxPic, setRect);
                zoomStateOut = true;
            }
        }

        public void zoomIn(cord mouseCord)
        {
            if (zoomStateOut == true)
            {
                cord topLeftCord = new cord(0, 0);
                if (mouseCord.X < 120)
                {
                    topLeftCord.X = 0;
                }
                else
                {
                    if (mouseCord.Y < 120)
                    {
                        topLeftCord.Y = 0;
                    }
                    else
                    {
                        topLeftCord.X = mouseCord.X - 120;
                        topLeftCord.Y = mouseCord.Y - 120;
                    }
                }

                Rectangle cropSection = new Rectangle(topLeftCord.X, topLeftCord.Y, 240, 240);
                Bitmap croppedPiece = cropImagePiece(cropSection, pictureBoxPic);
                Graphics g = pictureBox1.CreateGraphics();
                g.FillRectangle(whiteSol, 0, 0, 2000, 2000);
                Rectangle drawRect = new Rectangle(0, 0, 500, 500);
                g.DrawImage(croppedPiece, drawRect);
                zoomStateOut = false;
            }
        }

        public Boolean zoomStateOut = true;

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
            public zoomTool zoom = new zoomTool();

            public void changeCurrentSet(string nonSelect)
            {
                pen.selected = false;
                move.selected = false;
                cursor.selected = false;
                zoom.selected = false;

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
                        else
                        {
                            if (nonSelect == "zoom")
                            {
                                zoom.selected = true;
                            }
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

        public class zoomTool : toolType
        {

        }

        public class regCursor : toolType
        {

        }

        void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cord cursor = new cord(e.X, e.Y);
            cursorCordPts.X = e.X;
            cursorCordPts.Y = e.Y;

            string text = "x = " + cursor.X + ", y = " + cursor.Y;
            label1.Text = text;
            int selectedIn = comboBox1.SelectedIndex;
            int brushSize;

            if (picBoxClick == true && selectedIn < 11 && fileExists && allTools.pen.selected == true)
            {
                selectedIn = comboBox1.SelectedIndex;
                int selectedColor = comboBox2.SelectedIndex;
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

                    //firstGPath.AddEllipse(cursor.X, cursor.Y, brushSize, brushSize);
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
                    int selectedColorIn = comboBox2.SelectedIndex;
                    string color = availibleColors[selectedColorIn];
                    int[] rgb = new int[3];
                    int alpha = int.Parse(textBox1.Text);
                    if (color == "Black")
                    {
                        rgb[0] = 0;
                        rgb[1] = 0;
                        rgb[2] = 0;
                    }
                    else
                    {
                        if (color == "White")
                        {
                            rgb[0] = 255;
                            rgb[1] = 255;
                            rgb[2] = 255;
                        }
                        else
                        {
                            if (color == "Blue")
                            {
                                rgb[0] = 0;
                                rgb[1] = 0;
                                rgb[2] = 255;
                            }
                            else
                            {
                                if (color == "Red")
                                {
                                    rgb[0] = 255;
                                    rgb[1] = 0;
                                    rgb[2] = 0;
                                }
                            }
                        }
                    }
                    System.Drawing.Pen customSize = new System.Drawing.Pen(Color.FromArgb(alpha, rgb[0], rgb[1], rgb[2]), brushSize);
                    System.Drawing.Pen customWSize = new System.Drawing.Pen(Color.FromArgb(255, 255, 255, 255), brushSize);
                    
                    graphics = pictureBox1.CreateGraphics();
                    graphics.DrawLine(customWSize, prevCord.X, prevCord.Y, cursor.X, cursor.Y);
                    graphics.DrawLine(customSize, prevCord.X, prevCord.Y, cursor.X, cursor.Y);
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
        string[] availibleColors = new string[4];
        public cord cursorCordPts = new cord(0, 0);


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


        public void fillRegion()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Region fillRegion = new Region(blackDefPath);
            g.FillRegion(blackSol, fillRegion);
        }

        public void updateLineRegion()
        {

        }

        public void updateRegion()
        {
            int selectedIn = comboBox1.SelectedIndex;
            int brushSize;
            cord cursor = new cord(cursorCordPts.X, cursorCordPts.Y);
            if (picBoxClick == true && selectedIn < 11 && fileExists && allTools.pen.selected == true)
            {
                selectedIn = comboBox1.SelectedIndex;
                int selectedColor = comboBox2.SelectedIndex;
                brushSize = sizes[selectedIn];
                if (aDown == true)
                {
                    brushSize = brushSize * 2;
                }
                addCurrentMarkerSpotCirRegion(cursor, brushSize);

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

                    //firstGPath.AddEllipse(cursor.X, cursor.Y, brushSize, brushSize);
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
                    int selectedColorIn = comboBox2.SelectedIndex;
                    string color = availibleColors[selectedColorIn];
                    int[] rgb = new int[3];
                    int alpha = int.Parse(textBox1.Text);
                    regionUpdateColors(color, cursor);
                }
                else
                {
                    firstMark = false;
                }
            }
            prevCord.X = cursor.X;
            prevCord.Y = cursor.Y;
        }

        public void regionUpdateColors(string color, cord cursor)
        {
            if (color == "Black")
            {
                if (renderRegionInitial[0] == false)
                {
                    blackDefPath.StartFigure();
                    renderRegionInitial[0] = true;
                }
                blackDefPath.AddLine(prevCord.X, prevCord.Y, cursor.X, cursor.Y);
            }
            else
            {
                if (color == "White")
                {
                    if (renderRegionInitial[1] == false)
                    {
                        whiteDefPath.StartFigure();
                        renderRegionInitial[1] = true;
                    }
                    whiteDefPath.AddLine(prevCord.X, prevCord.Y, cursor.X, cursor.Y);
                }
                else
                {
                    if (color == "Blue")
                    {
                        if (renderRegionInitial[2] == false)
                        {
                            blueDefPath.StartFigure();
                            renderRegionInitial[2] = true;
                        }
                        blueDefPath.AddLine(prevCord.X, prevCord.Y, cursor.X, cursor.Y);
                    }
                    else
                    {
                        if (color == "Red")
                        {
                            if (renderRegionInitial[3] == false)
                            {
                                redDefPath.StartFigure();
                                renderRegionInitial[3] = true;
                            }
                            redDefPath.AddLine(prevCord.X, prevCord.Y, cursor.X, cursor.Y);
                        }
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

        GraphicsPath blackDefPath;
        GraphicsPath whiteDefPath;
        GraphicsPath blueDefPath;
        GraphicsPath redDefPath;
        bool[] renderRegionInitial = new bool[4];
        public void addCurrentMarkerSpotCirRegion(cord curPos, int sizePX)
        {
            int radius = sizePX / 2;
            int selectedColorIn = comboBox2.SelectedIndex;
            string color = availibleColors[selectedColorIn];

            markerSpotColor(color, curPos, radius, sizePX);
        }

        public void prototypeMarkerSpotColor(string color, cord cursorPoint, int diameterSZ)
        {
            int radius = diameterSZ / 2;
            string[] colorList = new string[4];
            colorList[0] = "Black";
            colorList[1] = "White";
            colorList[2] = "Blue";
            colorList[3] = "Red";
            int colorNo;

            for (int i = 0; i < colorList.Length; i++)
            {
                if (colorList[i] == color)
                {
                    colorNo = i + 1;
                }
            }
        }

        public void markerSpotColor(string color, cord curPos, int radius, int sizePX)
        {
            if (color == "Black")
            {
                if (renderRegionInitial[0] == false)
                {
                    cord centerCord = new cord(curPos.X, curPos.Y);
                    Rectangle renderCenter = new Rectangle(centerCord.X, centerCord.Y, 1, 1);
                    blackDefPath = new GraphicsPath();
                    blackDefPath.StartFigure();
                    blackDefPath.AddRectangle(renderCenter);
                    renderRegionInitial[0] = true;
                }
                blackDefPath.StartFigure();
                blackDefPath.AddEllipse(curPos.X - radius, curPos.Y - radius, sizePX, sizePX);
            }
            else
            {
                if (color == "White")
                {
                    if (renderRegionInitial[1] == false)
                    {
                        Rectangle renderCenter = new Rectangle(curPos.X, curPos.Y, 1, 1);
                        whiteDefPath = new GraphicsPath();
                        whiteDefPath.StartFigure();
                        whiteDefPath.AddRectangle(renderCenter);
                        renderRegionInitial[1] = true;
                    }
                    whiteDefPath.StartFigure();
                    whiteDefPath.AddEllipse(curPos.X - radius, curPos.Y - radius, sizePX, sizePX);
                }
                else
                {
                    if (color == "Blue")
                    {
                        if (renderRegionInitial[2] == false)
                        {
                            cord centerCord = new cord(curPos.X, curPos.Y);
                            Rectangle renderCenter = new Rectangle(centerCord.X, centerCord.Y, 1, 1);
                            blueDefPath = new GraphicsPath();
                            blueDefPath.StartFigure();
                            blueDefPath.AddRectangle(renderCenter);
                            renderRegionInitial[2] = true;
                        }
                        blueDefPath.StartFigure();
                        blueDefPath.AddEllipse(curPos.X - radius, curPos.Y - radius, sizePX, sizePX);
                    }
                    else
                    {
                        if (color == "Red")
                        {
                            if (renderRegionInitial[3] == false)
                            {
                                cord centerCord = new cord(curPos.X, curPos.Y);
                                Rectangle renderCenter = new Rectangle(centerCord.X, centerCord.Y, 1, 1);
                                redDefPath = new GraphicsPath();
                                redDefPath.StartFigure();
                                redDefPath.AddRectangle(renderCenter);
                                renderRegionInitial[3] = true;
                            }
                            redDefPath.StartFigure();
                            redDefPath.AddEllipse(curPos.X - radius, curPos.Y - radius, sizePX, sizePX);
                        }
                    }
                }
            }
        }

        public void drawCurrentMarkerSpotCir(cord curPos, int sizePX)
        {
            int radius = sizePX / 2;
            graphics = pictureBox1.CreateGraphics();
            //graphics.FillEllipse(blackSol, curPos.X, curPos.Y, sizePX, sizePX);
            int selectedColorIn = comboBox2.SelectedIndex;
            string color = availibleColors[selectedColorIn];
            int[] rgb = new int[3];

            int alpha = int.Parse(textBox1.Text);
            if (color == "Black")
            {
                rgb[0] = 0;
                rgb[1] = 0;
                rgb[2] = 0;
            }
            else
            {
                if (color == "White")
                {
                    rgb[0] = 255;
                    rgb[1] = 255;
                    rgb[2] = 255;
                }
                else
                {
                    if (color == "Blue")
                    {
                        rgb[0] = 0;
                        rgb[1] = 0;
                        rgb[2] = 255;
                    }
                    else
                    {
                        if (color == "Red")
                        {
                            rgb[0] = 255;
                            rgb[1] = 0;
                            rgb[2] = 0;
                        }
                    }
                }
            }
            System.Drawing.SolidBrush customBrush = new System.Drawing.SolidBrush(Color.FromArgb(alpha, rgb[0], rgb[1], rgb[2]));
            System.Drawing.SolidBrush customWBrush = new System.Drawing.SolidBrush(Color.FromArgb(255, 255, 255, 255));
            graphics.FillEllipse(customWBrush, curPos.X - radius, curPos.Y - radius, sizePX, sizePX);
            graphics.FillEllipse(customBrush, curPos.X - radius, curPos.Y - radius, sizePX, sizePX);
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

            for (int i = 0; i < renderRegionInitial.Length; i++)
            {
                renderRegionInitial[i] = false;
            }


                //firstGPath.StartFigure();
                cPath.StartFigure();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            availibleColors[0] = "Black";
            availibleColors[1] = "White";
            availibleColors[2] = "Blue";
            availibleColors[3] = "Red";

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
            comboBox2.Items.Add("Black");
            comboBox2.Items.Add("White");
            comboBox2.Items.Add("Blue");
            comboBox2.Items.Add("Red");
            comboBox2.SelectedIndex = 0;
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

        public Boolean imageSet = false;
        public Bitmap pictureBoxPic;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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

        public Bitmap cropImagePiece(Rectangle r, Bitmap imageToCrop)
        {
            Bitmap cropImg = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(cropImg);
            Graphics gd = pictureBox1.CreateGraphics();
            g.DrawImage(imageToCrop, -r.X, -r.Y);
            return cropImg;
        }

        private void cropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle cropRect = new Rectangle(161, 73, 80, 80);
            Bitmap croppedPiece = cropImagePiece(cropRect, pictureBoxPic);
            pictureBoxPic = croppedPiece;
            pictureBox1.Image = croppedPiece;
        }

        public void scaleImage(Bitmap originalImage)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.FillRectangle(whiteSol, 0, 0, 2000, 2000);
            float widthPercent = float.Parse(Interaction.InputBox("Width Percent", "Width resize percent:", "1", 200, 200));
            float heightPercent = float.Parse(Interaction.InputBox("Height Percent", "Height resize percent:", "1", 200, 200));
            float widthMultiplied = widthPercent * originalImage.Width;
            float heightMultiplied = heightPercent * originalImage.Height;
            int roundedWidth = (int)Math.Round(widthMultiplied, 0);
            int roundedHeight = (int)Math.Round(heightMultiplied, 0);
            Bitmap scaledPic = new Bitmap(roundedWidth, roundedHeight);
            using (Graphics graphics = pictureBox1.CreateGraphics())
            {
                graphics.DrawImage(originalImage, new Rectangle(0, 0, scaledPic.Width, scaledPic.Height));
            }
            
        }

        private void scaleImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scaleImage(pictureBoxPic);
        }

        public void updateEllipsesDrawing(cord mouseClickedSpot, int penSize)
        {
            int selectedIn = comboBox1.SelectedIndex;
            int brushSize = sizes[selectedIn];
            if (aDown == true)
            {
                brushSize = brushSize * 2;
            }
            int elipRadius = penSize / 2;
            cord elipCorner = new cord(0, 0);
            elipCorner.X = mouseClickedSpot.X - elipRadius;
            elipCorner.Y = mouseClickedSpot.Y - elipRadius;
            currentMarkPath.StartFigure();
            currentMarkPath.AddEllipse(elipCorner.X, elipCorner.Y, penSize, penSize);
        }

        public void renderMarkPath()
        {
            int[] argbInts = new int[4];
            // Order: Black, White, Blue, Red, Green
            int selectedColorInt = comboBox2.SelectedIndex;

            if (selectedColorInt == 0)
            {
                //Black
                argbInts[1] = 0;
                argbInts[2] = 0;
                argbInts[3] = 0;
            }
            else
            {
                if (selectedColorInt == 1)
                {
                    //White
                    argbInts[1] = 255;
                    argbInts[2] = 255;
                    argbInts[3] = 255;
                }
                else
                {
                    if (selectedColorInt == 2)
                    {
                        //Blue
                        argbInts[1] = 0;
                        argbInts[2] = 0;
                        argbInts[3] = 255;
                    }
                    else
                    {
                        if (selectedColorInt == 3)
                        {
                            //Red
                            argbInts[1] = 255;
                            argbInts[2] = 0;
                            argbInts[3] = 0;
                        }
                        else
                        {
                            if (selectedColorInt == 4)
                            {
                                //Green
                                argbInts[1] = 0;
                                argbInts[2] = 255;
                                argbInts[3] = 0;
                            }
                        }
                    }
                }
            }

            int alpha = int.Parse(textBox1.Text);
            argbInts[0] = alpha;

            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush customBrush = new SolidBrush(Color.FromArgb(argbInts[0], argbInts[1], argbInts[2], argbInts[3]));
            g.FillPath(customBrush, currentMarkPath);
            currentMarkPath = new GraphicsPath();
        }

        public GraphicsPath currentMarkPath = new GraphicsPath();
        public GraphicsPath testPath = new GraphicsPath();

        public void setTestPathClear(int method, cord[] coordinates)
        {
            cord[] usingCords;
            if (method == 0) {
                usingCords = new cord[coordinates.Length];
                testPath.StartFigure();
                for (int i = 0; i < coordinates.Length; i++)
                {
                    usingCords[i].X = coordinates[i].X;
                    usingCords[i].Y = coordinates[i].Y;
                }
                Point[] cordsForPolygon = new Point[usingCords.Length];
                for (int i = 0; i < usingCords.Length; i++)
                {
                    cordsForPolygon[i].X = usingCords[i].X;
                    cordsForPolygon[i].Y = usingCords[i].Y;
                }
                testPath.AddPolygon(cordsForPolygon);
            }
            else
            {
                if (method == 1)
                {
                    usingCords = new cord[1];
                    usingCords[0].X = 0;
                    usingCords[0].Y = 0;
                    testPath = new GraphicsPath();
                }
            }
        }

        public void renderTestPath()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Region regionConvert = new Region(testPath);
            g.FillRegion(regionConvert);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            allTools.changeCurrentSet("zoom");
            label3.Text = "Zoom";
        }
    }
}
