using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using Utilities;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace Tests
{
    [TestFixture]
    class BitmapConvertersTests
    {
        [Test]
        public void TestBitmapToSourceConversion()
        {
            // Generate a random 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(r.Next()));
            }

            // Generate source from bitmap
            BitmapSource source = BitmapConverters.CreateSourceFromBitmap(bmp);

            // Recreate bitmap from source
            Bitmap newBmp = BitmapConverters.CreateBitmapFromSource(source);

            // Check that the two bitmap's sizes are identical
            AreEqual(bmp.Width, newBmp.Width);
            AreEqual(bmp.Height, newBmp.Height);

            // Check that the two bitmap's pixels are identical, assuming that the sizes are identical
            if (bmp.Size == newBmp.Size)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                        AreEqual(bmp.GetPixel(x, y), newBmp.GetPixel(x, y));
                }
            }
        }

        [Test]
        public void TestBitmapToPngConversion()
        {
            // Generate a random 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();
            string pngPath = "TestBitmapToPngConversion.png";

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(r.Next()));
            }

            // Save as a .png temporarily
            FileStream bmpFile = new FileStream(pngPath, FileMode.Create);
            BitmapConverters.SaveBitmapAsPNG(bmp, bmpFile);
            bmpFile.Flush();
            bmpFile.Close();

            // Convert the saved png back into a bitmap
            FileStream pngFile = new FileStream(pngPath, FileMode.Open);
            Bitmap png = BitmapConverters.CreateBitmapFromPNG(pngFile);
            pngFile.Close();

            // Clean up png
            if (File.Exists(pngPath))
                File.Delete(pngPath);

            // Check that the two bitmap's sizes are identical
            AreEqual(bmp.Width, png.Width);
            AreEqual(bmp.Height, png.Height);

            // Check that the two bitmap's pixels are identical, assuming that the sizes are identical
            if (bmp.Size == png.Size)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                        AreEqual(bmp.GetPixel(x, y), png.GetPixel(x, y));
                }
            }
        }

        [Test] // Tests a singular bitmap to gif conversion
        public void TestBitmapToGifConversion()
        {
            // Generate a random 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();
            string gifPath = "TestBitmapToGifConversion.gif";

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(r.Next()));
            }

            List<Bitmap> inputList = new List<Bitmap>();
            inputList.Add(bmp);

            // Save the bitmap as a gif
            BitmapConverters.SaveBitmapsAsAnimatedGIF(inputList, gifPath, 1);

            // Convert the gif back into a bitmap
            FileStream gifStream = new FileStream(gifPath, FileMode.Open);
            List<Bitmap> outputList = BitmapConverters.CreateBitmapsFromGIF(gifStream);
            gifStream.Close();

            // Clean up gif
            if (File.Exists(gifPath))
                File.Delete(gifPath);

            // Verify that there is one bitmap in the output list
            AreEqual(outputList.Count, 1);

            Bitmap gif = outputList[0];

            // Check that the two bitmap's sizes are identical
            AreEqual(bmp.Width, gif.Width);
            AreEqual(bmp.Height, gif.Height);

            // Check that the two bitmap's pixels are identical, assuming that the sizes are identical
            if (bmp.Size == gif.Size)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                        AreEqual(bmp.GetPixel(x, y), gif.GetPixel(x, y));
                }
            }
        }
    }

    [TestFixture]
    public class DrawingGridTests
    {
        [Test]
        public void BasicConstructorTest()
        {
            Random r = new Random();
            int width = r.Next(20);
            int height = r.Next(20);
            int scale = r.Next(20);

            // Create a new random grid
            DrawingGrid grid = new DrawingGrid(width, height, scale);

            // Verify that the grid maintains the correct parameters
            AreEqual(grid.Scale, scale);
            AreEqual(grid.size.Width, width);
            AreEqual(grid.size.Height, height);
            AreEqual(grid.Grid.GetLength(0), width);
            AreEqual(grid.Grid.GetLength(1), height);

            // Verify that the interior grid is entirely the default color
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                    AreEqual(grid.GetCell(x, y), Color.White);
            }
        }

        [Test]
        public void PngConstructorTest()
        {
            // Generate a random 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();
            string pngPath = "PngConstructorTest.png";

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(r.Next()));
            }

            // Save as a .png temporarily
            FileStream bmpFile = new FileStream(pngPath, FileMode.Create);
            BitmapConverters.SaveBitmapAsPNG(bmp, bmpFile);
            bmpFile.Close();

            // Convert the saved png back into a bitmap
            FileStream pngFile = new FileStream(pngPath, FileMode.Open);

            // Create a grid from the png saved
            DrawingGrid grid = new DrawingGrid(pngFile, 2, 1);
            pngFile.Close();

            // Clean up png
            if (File.Exists(pngPath))
                File.Delete(pngPath);

            // Verify that the grid maintains the same parameters
            AreEqual(grid.Scale, 2);
            AreEqual(grid.size.Width, 20);
            AreEqual(grid.size.Height, 20);
            AreEqual(grid.Grid.GetLength(0), 20);
            AreEqual(grid.Grid.GetLength(1), 20);

            // Verify that the interior grid has the same colors as the bitmap saved
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                    AreEqual(grid.GetCell(x, y), bmp.GetPixel(x, y));
            }
        }

        [Test]
        public void NativeScalingTest()
        {
            // Generate a randomly scaled 20 x 20 bitmap
            
            Random r = new Random();
            int nativeScale = r.Next(2, 11);
            Bitmap bmp = new Bitmap(20 * nativeScale, 20 * nativeScale);
            string pngPath = "NativeScalingTest.png";

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(r.Next()));
            }

            // Save as a .png temporarily
            FileStream bmpFile = new FileStream(pngPath, FileMode.Create);
            BitmapConverters.SaveBitmapAsPNG(bmp, bmpFile);
            bmpFile.Close();

            // Convert the saved png back into a bitmap
            FileStream pngFile = new FileStream(pngPath, FileMode.Open);

            // Create a grid from the png saved
            DrawingGrid grid = new DrawingGrid(pngFile, 2, nativeScale);
            pngFile.Close();

            // Clean up png
            if (File.Exists(pngPath))
                File.Delete(pngPath);

            // Verify that the grid maintains the same parameters
            AreEqual(grid.Scale, 2);
            AreEqual(grid.size.Width, 20);
            AreEqual(grid.size.Height, 20);
            AreEqual(grid.Grid.GetLength(0), 20);
            AreEqual(grid.Grid.GetLength(1), 20);

            // Verify that the interior grid has the same colors as the bitmap saved
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                    AreEqual(grid.GetCell(x, y), bmp.GetPixel(x * nativeScale, y * nativeScale));
            }
        }

        [Test]
        public void CreateImageTest()
        {
            // Generate a random 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(255, Color.FromArgb(r.Next())));
            }

            DrawingGrid grid = new DrawingGrid(bmp, 10, 1);

            // Generate a 5x scale image of the bitmap
            Bitmap scaledBmp = grid.CreateImage(5);

            // Check that the new image is 5 times larger
            AreEqual(scaledBmp.Width, 5 * bmp.Width);
            AreEqual(scaledBmp.Height, 5 * bmp.Height);

            // Verify that the new bitmap has the same colors as the old bitmap
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                    AreEqual(bmp.GetPixel(x, y), scaledBmp.GetPixel(x * 5, y * 5));
            }
        }

        [Test]
        public void DrawToGridTest()
        {
            DrawingGrid grid = new DrawingGrid(20, 20, 1);

            // Select a random location and color
            Random r = new Random();
            int x = r.Next(20);
            int y = r.Next(20);
            Color c = Color.FromArgb(255, Color.FromArgb(r.Next()));

            // Color that pixel
            grid.DrawToGrid(x, y, c);

            // Get the new bitmap of the grid
            Bitmap newBmp = grid.DisplayMap;

            // Verify that the pixel specified got colored correctly
            AreEqual(newBmp.GetPixel(x, y), c);
        }

        
        [Test]
        public void CopyRegionTest()
        {
            // Generate a random 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(255, Color.FromArgb(r.Next())));
            }

            // Initialize a grid of the random bitmap
            DrawingGrid grid = new DrawingGrid(bmp, 10, 1);
            
            // Generate a random inbounds rectangle
            Rectangle inBounds = new Rectangle(0, 0, r.Next(20), r.Next(20));
            // Copy the inbounds region
            DrawingGrid.GridCell[,] copy = grid.CopyRegion(inBounds);
            // Verify that the region was correctly copied
            copyVerifier(copy, grid);

            // Generate a random out of bounds (on the right) rectangle
            Rectangle outR = new Rectangle(0, 0, r.Next(21, 40), r.Next(20));
            // Copy the region
            copy = grid.CopyRegion(outR);
            // Verify
            copyVerifier(copy, grid);

            // Generate a random out of bounds (on the bottom) rectangle
            Rectangle outB = new Rectangle(0, 0, r.Next(20), r.Next(21, 40));
            // Copy the region
            copy = grid.CopyRegion(outB);
            // Verify
            copyVerifier(copy, grid);

            // Generate a random out of bounds rectangle
            Rectangle outBR = new Rectangle(0, 0, r.Next(21, 40), r.Next(21, 40));
            // Copy the region
            copy = grid.CopyRegion(outB);
            // Verify
            copyVerifier(copy, grid);

        }

        private void copyVerifier(DrawingGrid.GridCell[,] copy, DrawingGrid source)
        {
            for (int x = 0; x < copy.GetLength(0); x++)
            {
                for (int y = 0; y < copy.GetLength(1); y++)
                {
                    if (x < source.size.Width && y < source.size.Height)
                        AreEqual(copy[x, y].color, source.GetCell(x, y));
                    else
                        AreEqual(copy[x, y].color, Color.White);
                }
            }
        }

        [Test]
        public void ClearRegionTest()
        {
            // Generate a random 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(255, Color.FromArgb(r.Next())));
            }

            // Initialize a grid of the random bitmap
            DrawingGrid grid = new DrawingGrid(bmp, 10, 1);

            // Generate a random inbounds rectangle
            Rectangle inBounds = new Rectangle(0, 0, r.Next(20), r.Next(20));

            // Clear the region
            grid.ClearRegion(inBounds);

            // Verify that the region was actually cleared
            for (int x = 0; x < inBounds.Width; x++)
            {
                for (int y = 0; y < inBounds.Height; y++)
                    AreEqual(grid.GetCell(x, y), Color.White);
            }

            // Now Generate a random out of bounds rectangle
            Rectangle outBounds = new Rectangle(r.Next(5, 10), r.Next(5, 10), 20, 20);

            // Clear that region
            grid = new DrawingGrid(bmp, 10, 1);
            grid.ClearRegion(outBounds);

            // Verify that the region was cleared
            for (int x = 0; x < inBounds.Width; x++)
            {
                for (int y = 0; y < inBounds.Height; y++)
                {
                    if (x + outBounds.X < grid.size.Width && y + outBounds.Y < grid.size.Height)
                        AreEqual(grid.GetCell(x + outBounds.X, y + outBounds.Y), Color.White);
                }
            }
        }

        [Test]
        public void PasteRegionTest()
        {
            // Generate a white 20 x 20 bitmap
            Bitmap bmp = new Bitmap(20, 20);
            Random r = new Random();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                    bmp.SetPixel(x, y, Color.White);
            }

            // Generate a grid from the bitmap
            DrawingGrid grid = new DrawingGrid(bmp, 10, 1);

            // Generate a randomly colored 5 x 5 region
            DrawingGrid.GridCell[,] region = new DrawingGrid.GridCell[5,5];
            for (int x = 0; x < region.GetLength(0); x++)
            {
                for (int y = 0; y < region.GetLength(1); y++)
                    region[x,y] = new DrawingGrid.GridCell(Color.FromArgb(255, Color.FromArgb(r.Next())));
            }

            // Paste the region in at (0,0)
            grid.PasteRegion(0, 0, region);

            // Verify that the region was correctly copied
            for (int x = 0; x < region.GetLength(0); x++)
            {
                for (int y = 0; y < region.GetLength(1); y++)
                    AreEqual(region[x, y].color, grid.GetCell(x, y));
            }
        }
    }
}
