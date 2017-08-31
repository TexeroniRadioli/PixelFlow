using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows;
using ImageMagick;

namespace Utilities
{
    public class BitmapConverters
    {
        // Creates a BitmapSource object from an input Bitmap
        public static BitmapSource CreateSourceFromBitmap(Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var bitmapSource = BitmapSource.Create(bitmapData.Width, bitmapData.Height, 96, 96, System.Windows.Media.PixelFormats.Bgra32, null, bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }

        // Creates a Bitmap from an input BitmapSource object
        public static Bitmap CreateBitmapFromSource(BitmapSource source)
        {
            Bitmap bitmap = new Bitmap(source.PixelWidth, source.PixelHeight, PixelFormat.Format32bppArgb);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(System.Drawing.Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            source.CopyPixels(Int32Rect.Empty, bitmapData.Scan0, bitmapData.Height * bitmapData.Stride, bitmapData.Stride);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        public static Bitmap CreateBitmapFromFrame(BitmapFrame frame)
        {
            Bitmap bitmap = new Bitmap(frame.PixelWidth, frame.PixelHeight, PixelFormat.Format32bppArgb);
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(System.Drawing.Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            frame.CopyPixels(Int32Rect.Empty, bitmapData.Scan0, bitmapData.Height * bitmapData.Stride, bitmapData.Stride);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        // Creates a Bitmap from an input .png file
        public static Bitmap CreateBitmapFromPNG(Stream pngStream)
        {
            try
            {
                PngBitmapDecoder pngDec = new PngBitmapDecoder(pngStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                BitmapSource bitmapSource = pngDec.Frames[0];
                return CreateBitmapFromSource(bitmapSource);
            }
            catch (FileFormatException ex)
            {
                // Might want to do something like spawn a pop up that says the error message.
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Creates a List of Bitmaps from an input gif file
        public static List<Bitmap> CreateBitmapsFromGIF(Stream gifStream)
        {
            try
            {
                List<Bitmap> toReturn = new List<Bitmap>();

                GifBitmapDecoder gifDec = new GifBitmapDecoder(gifStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                foreach (BitmapFrame bf in gifDec.Frames)
                    toReturn.Add(CreateBitmapFromFrame(bf));

                return toReturn;
            }
            catch (FileFormatException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Saves a Bitmap as a png file
        public static void SaveBitmapAsPNG(Bitmap bitmap, Stream pngStream)
        {
            BitmapSource source = CreateSourceFromBitmap(bitmap);
            PngBitmapEncoder pngEnc = new PngBitmapEncoder();
            pngEnc.Frames.Add(BitmapFrame.Create(source));
            
            pngEnc.Save(pngStream);
        }

        // Saves a list of Bitmaps as a gif file
        public static void SaveBitmapsAsGIF(List<Bitmap> bitmaps, Stream gifStream)
        {
            GifBitmapEncoder gifEnc = new GifBitmapEncoder();
            foreach (Bitmap bmp in bitmaps)
                gifEnc.Frames.Add(BitmapFrame.Create(CreateSourceFromBitmap(bmp)));
            
            gifEnc.Save(gifStream);
        }

        // Saves a list of Bitmaps as an animated gif file
        public static void SaveBitmapsAsAnimatedGIF(List<Bitmap> bitmaps, string path, int fps)
        {
            MagickImageCollection collection = new MagickImageCollection();
            int delay = 100 / fps;

            for (int i = 0; i < bitmaps.Count; i++)
            {
                collection.Add(new MagickImage(bitmaps[i]));
                collection[i].AnimationDelay = delay;
            }

            collection.Optimize();

            collection.Write(path);
        }
    }
}
