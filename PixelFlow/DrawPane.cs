using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Utilities;

namespace PixelFlow
{
    public partial class DrawPane : UserControl
    {
        public DrawingGrid Grid;

        private bool dragable = false;
        private int drawX;
        private int drawY;

        private Color primaryColor = Color.Black;
        private Color secondaryColor = Color.White;
        private Color actingPrimaryColor = Color.Black;
        private Color actingSecondaryColor = Color.White;
        private int primaryAlpha = 255;
        private int secondaryAlpha = 255;
        private int lineThickness = 1;
        private int scale;
        private Size size;
        private Rectangle selectedRegion;
        private DrawingGrid.GridCell[,] tempClipboard;

        private List<Bitmap> history;
        private int currentHistory;

        public int frame = 1; // the frame of the animation this will act as


        public DrawPane(int width, int height, int scale) : this(new DrawingGrid(width, height, scale)) { }

        public DrawPane() : this(32, 32, 10) { }

        public DrawPane(Size nativeScale, int scale) : this(nativeScale.Width, nativeScale.Height, scale) { }

        public DrawPane(DrawingGrid grid)
        {
            InitializeComponent();

            Grid = grid;
            this.size = Grid.size;
            this.Size = new Size(size.Width * Grid.Scale, size.Height * Grid.Scale);
            scale = Grid.Scale;

            frame = 1;

            history = new List<Bitmap>();
            history.Add((Bitmap)Grid.DisplayMap.Clone());
        }

        public void ImportPNG(Stream pngStream, int scale, int nativeScale)
        {
            Grid = new DrawingGrid(pngStream, scale, nativeScale);
            this.size = Grid.size;
            this.Size = new Size(size.Width * scale, size.Height * scale);
            this.scale = scale;
            DisplayImage();
        }

        public void ImportGifFrame(Bitmap frame, int scale, int nativeScale)
        {
            Grid = new DrawingGrid(frame, scale, nativeScale);
            this.size = Grid.size;
            this.Size = new Size(size.Width * scale, size.Height * scale);
            this.scale = scale;
            DisplayImage();
        }

        public void DisplayImage(Bitmap newImage)
        {
            Graphics g = this.CreateGraphics();
            if (g == null)
                return;

            g.DrawImage(newImage, 0, 0, newImage.Width, newImage.Height);
        }

        public void DisplayImage()
        {
            Graphics g = CreateGraphics();
            if (g == null)
                return;

            g.DrawImage(Grid.DisplayMap, 0, 0, Grid.DisplayMap.Width, Grid.DisplayMap.Height);
            drawSelection();
           
            int index = MainWindow.Instance.GetCurrentFrameIndex();
            MainWindow.Instance.GetAnimationPane().GetFramePreview().GetPreviewButton(index).UpdatePreviewImage();
        }

        private void RenderSelection()
        {
            int sX = selectedRegion.X;
            int sY = selectedRegion.Y;
            Graphics g = CreateGraphics();
            for (int i = 0; i < tempClipboard.GetLength(0); i++)
            {
                for (int j = 0; j < tempClipboard.GetLength(1); j++)
                {
                    g.FillRectangle(new SolidBrush(tempClipboard[i, j].color), (sX + i) * scale, (sY + j) * scale, scale, scale);
                }
            }
        }

        private void DrawPane_Load(object sender, EventArgs e)
        {

        }

        public void Undo()
        {
            currentHistory--;
            if (currentHistory < 0)
            {
                currentHistory = 0;
            }

            //Grid = new DrawingGrid(history[currentHistory].Width, history[currentHistory].Height, scale);
            //Grid.DisplayMap = history[currentHistory];
            Grid = new DrawingGrid(history[currentHistory], scale, scale);
            DisplayImage();
        }

        public void Redo()
        {
            currentHistory++;
            if (currentHistory > history.Count - 1)
            {
                currentHistory = history.Count - 1;
            }
            Grid = new DrawingGrid(history[currentHistory], scale, scale);
            DisplayImage();
        }

        public void SetScale(int newScale)
        {
            Grid.Scale = newScale;
            scale = newScale;
            this.Size = new Size(size.Width * newScale, size.Height * newScale);
            DisplayImage();
        }


        /*
         * Sets the color of the pixel at the input point to the input color
         */
        public void ColorPixel(int x, int y, Color color)
        {
            try
            {
                // Color a pixel on the grid representation
                Grid.DrawToGrid(x, y, color);

                // tell the animator to update this frame, currently borked
                //MainWindow.Instance.GetAnimationPane().GetAnimationPreview().animation[frame - 1] = Grid.DisplayMap;
            }
            catch (IndexOutOfRangeException ex)
            {
                // no op
            }
        }


        /*
         * Overload that takes a point instead of 2 ints
         */
        public void ColorPixel(Point p, Color color)
        {
            ColorPixel(p.X, p.Y, color);
        }


        /*
         * Gets the color at the specified point
         */
        public Color GetPixel(int x, int y)
        {
            return Grid.GetCell(x, y);
        }


        /*
         * Overload that takes a point instead of 2 ints
         */
        public Color GetPixel(Point p)
        {
            return GetPixel(p.X, p.Y);
        }


        public Bitmap GetImage()
        {
            return Grid.DisplayMap;
            // I'm not certain that this will do what we want
        }

        public void SetImage(Bitmap image)
        {
            // This might need some work...
        }


        public void SetPrimaryColor(Color c)
        {
            primaryColor = c;
        }

        public void SetSecondaryColor(Color c)
        {
            secondaryColor = c;
        }

        public void SetLineThickness(int thickness)
        {
            lineThickness = thickness;
        }

        public void SetPrimaryAlpha(int a)
        {
            primaryAlpha = a;
        }

        public void SetSecondaryAlpha(int a)
        {
            secondaryAlpha = a;
        }

        public bool NoHotkeysPressed()
        {
            bool keysDown = System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftAlt) ||
                            System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl);

            return !keysDown;
        }

        // was private, changed to public for tests
        public void DrawPane_MouseDown(object sender, MouseEventArgs e)
        {

            dragable = true;
            string tool;
            if (sender is string)
            {
                tool = (string)sender;
            }
            else
            {
                tool = MainWindow.Instance.GetToolbar().GetActiveTool();
            }

            if (e.Button == MouseButtons.Left)
            {
                actingPrimaryColor = Color.FromArgb(primaryAlpha, primaryColor);
                actingSecondaryColor = Color.FromArgb(secondaryAlpha, secondaryColor);
            }
            else if (e.Button == MouseButtons.Right)
            {
                actingPrimaryColor = Color.FromArgb(secondaryAlpha, secondaryColor);
                actingSecondaryColor = Color.FromArgb(primaryAlpha, primaryColor);
            }

            if (tool == "pencil" && NoHotkeysPressed())
            {
                DrawPencilDown(e);
            }
            else if (tool == "line" && NoHotkeysPressed() || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl))
            {
                DrawLineDown(e);
            }
            else if (tool == "circle" && NoHotkeysPressed())
            {
                DrawCircleDown(e);
            }
            else if (tool == "rectangle" && NoHotkeysPressed())
            {
                DrawRectangleDown(e);
            }
            else if (tool == "gradient" && NoHotkeysPressed())
            {
                DrawGradientDown(e);
            }
            else if (tool == "fill" && NoHotkeysPressed())
            {
                //DrawFillDown(e);
            }
            else if (tool == "select" && NoHotkeysPressed())
            {
                SelectDown(e);
            }
            else if (tool == "eyedropper" && NoHotkeysPressed() || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftAlt))
            {
                DrawEyedropperDown(e);
            }
            else if (tool == "drag")
            {
                DragDown(e);
            }
            else
            {
                Console.WriteLine("No viable tool selected");
            }
        }

        public void DrawPane_MouseMove(object sender, MouseEventArgs e)
        {

            string tool;
            if (sender is string)
            {
                tool = (string)sender;
            }
            else
            {
                tool = MainWindow.Instance.GetToolbar().GetActiveTool();
            }

            if (tool == "pencil" && NoHotkeysPressed())
            {
                DrawPencilMove(e);
            }
            else if (tool == "line" && NoHotkeysPressed() || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl))
            {
                DrawLineMove(e);
            }
            else if (tool == "circle" && NoHotkeysPressed())
            {
                DrawCircleMove(e);
            }
            else if (tool == "rectangle" && NoHotkeysPressed())
            {
                DrawRectangleMove(e);
            }
            else if (tool == "gradient" && NoHotkeysPressed())
            {
                DrawGradientMove(e);
            }
            else if (tool == "fill" && NoHotkeysPressed())
            {
                //DrawFillMove(e);
            }
            else if (tool == "select" && NoHotkeysPressed())
            {
                SelectMove(e);
            }
            else if (tool == "eyedropper" && NoHotkeysPressed() || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftAlt))
            {
                DrawEyedropperMove(e);
            }
            else if (tool == "drag")
            {
                DragMove(e);
            }
            else
            {
                Console.WriteLine("No viable tool selected");
            }
        }

        public void DrawPane_MouseUp(object sender, MouseEventArgs e)
        {
            string tool;
            if (sender is string)
            {
                tool = (string) sender;
            }
            else
            {
                tool = MainWindow.Instance.GetToolbar().GetActiveTool();
            }
            

            if (tool == "pencil" && NoHotkeysPressed())
            {
                DrawPencilUp(e);
            }
            else if (tool == "line" && NoHotkeysPressed() || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftCtrl))
            {
                DrawLineUp(e);
            }
            else if (tool == "circle" && NoHotkeysPressed())
            {
                DrawCircleUp(e);
            }
            else if (tool == "rectangle" && NoHotkeysPressed())
            {
                DrawRectangleUp(e);
            }
            else if (tool == "gradient" && NoHotkeysPressed())
            {
                DrawGradientUp(e);
            }
            else if (tool == "fill" && NoHotkeysPressed())
            {
                DrawFillUp(e);
            }
            else if (tool == "select" && NoHotkeysPressed())
            {
                //DrawSelectUp(e);
            }
            else if (tool == "eyedropper" && NoHotkeysPressed() || System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftAlt))
            {
                DrawEyedropperUp(e);
            }
            else if (tool == "drag")
            {
                DragUp(e);
            }
            else
            {
                Console.WriteLine("No viable tool selected");
            }

            dragable = false;

            // update history
            if (currentHistory != history.Count - 1)
            {
                List<Bitmap> tempHistory = new List<Bitmap>();
                for (int i = 0; i < currentHistory + 1; i++)
                {
                    tempHistory.Add(history[i]);
                }

                history = tempHistory;
            }

            history.Add((Bitmap)Grid.DisplayMap.Clone());
            currentHistory = history.Count - 1;
        }


        /***********************************************************************/
        /*                               PENCIL                                */
        /***********************************************************************/

        private void DrawPencilDown(MouseEventArgs e)
        {

            ColorPixel(e.X / scale, e.Y / scale, actingPrimaryColor);
            drawX = e.X;
            drawY = e.Y;
            DisplayImage();
        }

        private void DrawPencilMove(MouseEventArgs e)
        {

            if (dragable == true)
            {
                DrawLineUp(e);
                drawX = e.X;
                drawY = e.Y;
                DisplayImage();
            }
        }
        private void DrawPencilUp(MouseEventArgs e)
        {
            // no action
        }


        /***********************************************************************/
        /*                                LINE                                 */
        /***********************************************************************/

        private void DrawLineDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawLineMove(MouseEventArgs e)
        {
            // show where the line will be
        }
        private void DrawLineUp(MouseEventArgs e)
        {

            int sX = drawX / scale;
            int sY = drawY / scale;
            int eX = e.X / scale;
            int eY = e.Y / scale;

            DrawLine(sX, sY, eX, eY);

            /*int steps;
            if (Math.Abs(sX - eX) > Math.Abs(sY - eY))
            {
                steps = Math.Abs(sX - eX);
            }
            else
            {
                steps = Math.Abs(sY - eY);
            }

            float dx = (float)(eX - sX) / (float)steps;
            float dy = (float)(eY - sY) / (float)steps;

            float x = sX;
            float y = sY;

            ColorPixel(sX, sY, actingPrimaryColor);
            for (int i = 0; i < steps; i++)
            {
                x += dx;
                y += dy;
                ColorPixel((int)(x + 0.5), (int)(y + 0.5), actingPrimaryColor);
            }*/

            DisplayImage();
        }

        public void DrawLine(int sX, int sY, int eX, int eY)
        {
            int steps;
            if (Math.Abs(sX - eX) > Math.Abs(sY - eY))
            {
                steps = Math.Abs(sX - eX);
            }
            else
            {
                steps = Math.Abs(sY - eY);
            }

            float dx = (float)(eX - sX) / (float)steps;
            float dy = (float)(eY - sY) / (float)steps;

            float x = sX;
            float y = sY;

            ColorPixel(sX, sY, actingPrimaryColor);
            for (int i = 0; i < steps; i++)
            {
                x += dx;
                y += dy;
                ColorPixel((int)(x + 0.5), (int)(y + 0.5), actingPrimaryColor);
            }
        }



        /***********************************************************************/
        /*                               CIRCLE                                */
        /***********************************************************************/

        private void DrawCircleDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawCircleMove(MouseEventArgs e)
        {
            // show where the circle will be
        }
        private void DrawCircleUp(MouseEventArgs e)
        {
            /* Drake's implementation */
            //int minX = Math.Min(drawX, e.X) / scale;
            //int maxX = Math.Max(drawX, e.X) / scale + 1;
            //int minY = Math.Min(drawY, e.Y) / scale;
            //int maxY = Math.Max(drawY, e.Y) / scale + 1;
            //
            //int cenX = (maxX + minX) / 2;
            //int cenY = (maxY + minY) / 2;
            //
            //double xRad = (double)(maxX - minX) / 2.0;
            //double yRad = (double)(maxY - minY) / 2.0;
            //
            ///*double step = 10.0 / (xRad + yRad);
            //int numSteps = (int)(2 * Math.PI / step) + 1;*/
            //
            //int lastX = (int)(cenX + Math.Cos(/*step*/.1) * xRad);
            //int lastY = (int)(cenY + Math.Sin(/*step*/.1) * yRad);
            //
            //for (double theta = .2; theta < 6.4; theta+= .1)
            ////for (int i = 1; i < numSteps + 2; i++) 
            //{
            //    //double theta = step * (double)i;
            //    int x = (int)(cenX + Math.Cos(theta) * xRad);
            //    int y = (int)(cenY + Math.Sin(theta) * yRad);
            //
            //    if (x != lastX || y != lastY)
            //    {
            //        DrawLine(lastX, lastY, x, y);
            //    }
            //
            //    lastX = x;
            //    lastY = y;
            //
            //}
            //

            Point p0 = new Point(Math.Min(drawX, e.X) / scale, Math.Min(drawY, e.Y) / scale);
            Point p1 = new Point(Math.Max(drawX, e.X) / scale, Math.Max(drawY, e.Y) / scale);
            double cX = (double)(p0.X + p1.X) / 2.0;
            double cY = (double)(p0.Y + p1.Y) / 2.0;
            int h = p1.Y - p0.Y;
            int w = p1.X - p0.X;

            int numSteps = 16 * Math.Max(w, h); //The number of steps will never exceed the perimiter of the bounding box
            double deltaR = 2 * Math.PI / numSteps;
            for (int n = 0; n < numSteps; n++)
            {
                double r = n * deltaR;
                int x = (int)Math.Round(Math.Cos(r) * w / 2 + cX);
                int y = (int)Math.Round(Math.Sin(r) * h / 2 + cY);
                ColorPixel(x, y, actingPrimaryColor);
            }

            DisplayImage();
        }


        /***********************************************************************/
        /*                              RECTANGLE                              */
        /***********************************************************************/

        private void DrawRectangleDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawRectangleMove(MouseEventArgs e)
        {
            // show where the rectangle will be
        }
        private void DrawRectangleUp(MouseEventArgs e)
        {
            //Brush brush = new SolidBrush(actingPrimaryColor);
            int minX = Math.Min(drawX, e.X) / scale;
            int maxX = Math.Max(drawX, e.X) / scale;
            int minY = Math.Min(drawY, e.Y) / scale;
            int maxY = Math.Max(drawY, e.Y) / scale;

            for (int x = minX; x < maxX + 1; x++)
            {
                for (int y = minY; y < maxY + 1; y++)
                {
                    ColorPixel(x, y, actingPrimaryColor);
                }
            }

            DisplayImage();
        }


        /***********************************************************************/
        /*                              GRADIENT                               */
        /***********************************************************************/

        private void DrawGradientDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawGradientMove(MouseEventArgs e)
        {

        }

        private void DrawGradientUp(MouseEventArgs e)
        {
            int sx = drawX / scale;
            int sy = drawY / scale;
            int fx = e.X / scale;
            int fy = e.Y / scale;

            int vfx = fx - sx;
            int vfy = fy - sy;

            Color p, s;
            p = actingPrimaryColor;
            s = actingSecondaryColor;

            for (int x = Math.Max(selectedRegion.X, 0); x < Math.Min(selectedRegion.Right + 1, size.Width); x++)
            {
                for (int y = Math.Max(selectedRegion.Y, 0); y < Math.Min(selectedRegion.Bottom + 1, size.Height); y++)
                {
                    int vx = x - sx;
                    int vy = y - sy;

                    double mag = ((double)(vx * vfx + vy * vfy) / (vfx * vfx + vfy * vfy));
                    Color c;
                    if (mag <= 0)
                    {
                        c = p;
                    }
                    else if (mag >= 1)
                    {
                        c = s;
                    }
                    else
                    {
                        byte r, g, b;
                        int a;
                        r = (byte)(s.R * mag + p.R * (1 - mag));
                        g = (byte)(s.G * mag + p.G * (1 - mag));
                        b = (byte)(s.B * mag + p.B * (1 - mag));
                        a = (byte)(s.A * mag + p.A * (1 - mag));
                        c = Color.FromArgb(a, r, g, b);
                    }
                    ColorPixel(x, y, c);
                }
            }
            DisplayImage();
        }

        


        /***********************************************************************/
        /*                                FILL                                 */
        /***********************************************************************/

        private void DrawFillUp(MouseEventArgs e)
        {
            int sX = e.X / scale;
            int sY = e.Y / scale;

            HashSet<Point> inFill = new HashSet<Point>();
            Queue<Point> openList = new Queue<Point>();
            openList.Enqueue(new Point(sX, sY));
            Color color = GetPixel(sX, sY);
            while (openList.Count > 0)
            {

                Point active = openList.Dequeue();
                int x = active.X;
                int y = active.Y;
                ColorPixel(x, y, actingPrimaryColor);
                int xMax = size.Width;
                int yMax = size.Height;
                Point[] points = { new Point(x + 1, y), new Point(x, y + 1), new Point(x - 1, y), new Point(x, y - 1) };
                foreach (Point p in points)
                {
                    if (p.X < xMax && p.Y < yMax && p.X >= 0 && p.Y >= 0 && !inFill.Contains(p) && !openList.Contains(p)
                        && GetPixel(p.X, p.Y).Equals(color))
                    {
                        openList.Enqueue(p);
                    }
                }

                inFill.Add(active);
            }
            DisplayImage();
        }




        /***********************************************************************/
        /*                               SELECT                                */
        /***********************************************************************/

        private void SelectDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
            selectedRegion = new Rectangle(-1, -1, Grid.size.Width + 1, Grid.size.Height + 1);
            DisplayImage();
            dragable = true;
        }

        private void SelectMove(MouseEventArgs e)
        {
            if (!dragable) return;
            int sX = (int) Math.Round((double)drawX / scale);
            int sY = (int) Math.Round((double)drawY / scale);
            int fX = (int)Math.Round((double)e.X / scale);
            int fY = (int)Math.Round((double)e.Y / scale);
            if (fX < sX)
            {
                int tmp = fX;
                fX = sX;
                sX = tmp;
            }
            if (fY < sY)
            {
                int tmp = fY;
                fY = sY;
                sY = tmp;
            }
            Rectangle newRegion = new Rectangle(sX, sY, fX - sX, fY - sY);
            if (newRegion.Equals(selectedRegion)) return;
            selectedRegion = newRegion;
            DisplayImage();
        }

        private void SelectUp(MouseEventArgs e)
        {
            dragable = false;
        }

        private void drawSelection()
        {
            Graphics g = this.CreateGraphics();
            Brush b = new HatchBrush(HatchStyle.SmallCheckerBoard, Color.Black, Color.Transparent);
            Rectangle toDraw = new Rectangle(selectedRegion.X * scale + scale / 2, selectedRegion.Y * scale + scale / 2, selectedRegion.Width * scale, selectedRegion.Height * scale);
            g.DrawRectangle(new Pen(b, scale), toDraw);
        }
        /***********************************************************************/
        /*                                DRAG                                 */
        /***********************************************************************/

        private void DragDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
            tempClipboard = Grid.CopyRegion(selectedRegion);
            Grid.ClearRegion(selectedRegion);
            dragable = true;
        }

        private void DragMove(MouseEventArgs e)
        {
            if (!dragable) return;
            int dX = e.X / scale - drawX / scale;
            int dY = e.Y / scale - drawY / scale;
            if (dX == 0 && dY == 0) return; // Take no action if no drag took place
            drawX = e.X;
            drawY = e.Y;
            selectedRegion.X += dX;
            selectedRegion.Y += dY;
            DisplayImage();
            RenderSelection();
            drawSelection();
        }

        private void DragUp(MouseEventArgs e)
        {
            dragable = false;
            Grid.PasteRegion(selectedRegion.X, selectedRegion.Y, tempClipboard);
            DisplayImage();
        }


        /***********************************************************************/
        /*                             EYEDROPPER                              */
        /***********************************************************************/

        private void DrawEyedropperDown(MouseEventArgs e)
        {
            // no action
        }

        private void DrawEyedropperMove(MouseEventArgs e)
        {
            // no action
        }

        private void DrawEyedropperUp(MouseEventArgs e)
        {

            int sX = e.X / scale;
            int sY = e.Y / scale;

            if (e.Button == MouseButtons.Left)
            {
                SetPrimaryColor(GetPixel(sX, sY));
                MainWindow.Instance.GetToolbar().SetPrimaryColorSelector(GetPixel(sX, sY));
            }
            if (e.Button == MouseButtons.Right)
            {
                SetSecondaryColor(GetPixel(sX, sY));
                MainWindow.Instance.GetToolbar().SetSecondaryColorSelector(GetPixel(sX, sY));
            }
            
        }
    }
}
