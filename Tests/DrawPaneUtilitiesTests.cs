using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NUnit.Framework;
using PixelFlow;
using Utilities;
using System.Windows.Forms;
using static NUnit.Framework.Assert;

namespace Tests
{
    class DrawPaneUtilitiesTests
    {
        [Test]
        public void PixelTests()
        {
            Bitmap b = new Bitmap(10, 10);
            DrawingGrid g = new DrawingGrid(b, 1, 1);
            DrawPane d = new DrawPane(g);

            // color a pixel within the range of the bitmap
            d.ColorPixel(new Point(0, 0), Color.Blue);
            Assert.AreEqual(d.GetPixel(0, 0), Color.Blue);

            // color a pixel outside the range of the bitmap
            d.ColorPixel(new Point(11, 11), Color.Blue); // show this won't crash

            // retreive the valid pixel
            Assert.AreEqual(d.GetPixel(new Point(0, 0)), Color.Blue);

            // retrieve the 
            Assert.AreEqual(d.GetImage(), g.DisplayMap);
        }

        [Test]
        public void OptionTests()
        {
            Bitmap b = new Bitmap(10, 10);
            DrawingGrid g = new DrawingGrid(b, 1, 1);
            DrawPane d = new DrawPane(g);

            Color c = Color.Blue;
            d.SetPrimaryColor(c);

            c = Color.Red;
            d.SetSecondaryColor(c);

            d.SetLineThickness(2);

            d.SetPrimaryAlpha(50);

            d.SetSecondaryAlpha(100);

            MouseEventArgs e = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            
            //d.DrawPane_MouseDown(new object(), e);

        }
    }
}
