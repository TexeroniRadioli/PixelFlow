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

namespace PixelFlow
{
    public partial class GifExport : UserControl
    {
        private string exportDirectory;
        public GifExport()
        {
            InitializeComponent();
            scaleSelector.Value = MainWindow.Instance.GetOptionsBar().GetCurrentScale();
            exportDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\Exports\\";
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (fileNameBox.Text != "" && MainWindow.Instance.GetCurrentFrameIndex() != -1)
            {
                if (!Directory.Exists(exportDirectory))
                    Directory.CreateDirectory(exportDirectory);

                List<Bitmap> toSave = new List<Bitmap>();

                for (int i = 0; i < MainWindow.Instance.Frames.Count; i++)
                    toSave.Add(MainWindow.Instance.GetDrawPane(i).Grid.CreateImage((int)scaleSelector.Value));

                Utilities.BitmapConverters.SaveBitmapsAsAnimatedGIF(toSave, exportDirectory + fileNameBox.Text + ".Animated.gif", (int)frameRateSelector.Value);
                //stream.Flush();
                //stream.Close();
            }
        }
    }
}
