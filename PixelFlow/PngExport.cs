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
    public partial class PngExport : UserControl
    {
        private string exportDirectory;
        public PngExport()
        {
            InitializeComponent();
            scaleSelector.Value = MainWindow.Instance.GetOptionsBar().GetCurrentScale();
            exportDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\Exports\\";
        }

        private void currentButton_Click(object sender, EventArgs e)
        {
            if (fileNameBox.Text != "" && MainWindow.Instance.GetCurrentFrameIndex() != -1)
            {
                FileStream stream;
                try
                {
                    stream = new FileStream(exportDirectory + fileNameBox.Text + ".png", FileMode.Create);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Directory.CreateDirectory(exportDirectory);
                    stream = new FileStream(exportDirectory + fileNameBox.Text + ".png", FileMode.Create);
                }

                Bitmap toSave = MainWindow.Instance.GetDrawPane().Grid.CreateImage((int)scaleSelector.Value);
                Utilities.BitmapConverters.SaveBitmapAsPNG(toSave, stream);
                stream.Flush();
                stream.Close();
            }
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            if (fileNameBox.Text != "" && MainWindow.Instance.GetCurrentFrameIndex() != -1)
            {
                int cap = MainWindow.Instance.GetNumberOfFrames();
                for (int i = 0; i < cap; i++)
                {
                    FileStream stream = new FileStream(exportDirectory + fileNameBox.Text + (i + 1) + ".png", FileMode.Create);
                    Bitmap toSave = MainWindow.Instance.GetDrawPane(i).Grid.CreateImage((int)scaleSelector.Value);
                    Utilities.BitmapConverters.SaveBitmapAsPNG(toSave, stream);
                    stream.Flush();
                    stream.Close();
                }
            }
        }
    }
}
