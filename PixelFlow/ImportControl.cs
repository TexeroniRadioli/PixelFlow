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
    public partial class ImportControl : UserControl
    {
        public ImportControl()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\Exports\\";
            openFileDialog1.Filter = "PNG files (*.png)|*.png|GIF files (*.gif)|*.gif*|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(openFileDialog1.InitialDirectory))
                Directory.CreateDirectory(openFileDialog1.InitialDirectory);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                fileBox.Text = openFileDialog1.FileName;
            
        }

        private void bushDidBumpin_Click(object sender, EventArgs e)
        {
            if (!File.Exists(fileBox.Text))
                return;

            FileStream stream = new FileStream(fileBox.Text, FileMode.Open);

            if (fileBox.Text.Contains(".png") || fileBox.Text.Contains(".PNG")) 
            {
                if (MainWindow.Instance.GetCurrentFrameIndex() < 0)
                {
                    int index = MainWindow.Instance.AddNewFrame();
                    MainWindow.Instance.GetAnimationPane().GetFramePreview().AddNewPreview(index);
                    MainWindow.Instance.GetDrawPane().ImportPNG(stream, MainWindow.Instance.GetOptionsBar().GetCurrentScale(), (int)nativeScaleSelect.Value);
                }
                else
                    MainWindow.Instance.GetDrawPane().ImportPNG(stream, MainWindow.Instance.GetOptionsBar().GetCurrentScale(), (int)nativeScaleSelect.Value);
            }

            if (fileBox.Text.Contains(".gif") || fileBox.Text.Contains(".GIF"))
            {
                if (MainWindow.Instance.GetCurrentFrameIndex() < 0)
                {
                    List<Bitmap> bitmaps = Utilities.BitmapConverters.CreateBitmapsFromGIF(stream);

                    for (int i = 0; i < bitmaps.Count; i++)
                    {
                        int index = MainWindow.Instance.AddNewFrame();
                        MainWindow.Instance.GetAnimationPane().GetFramePreview().AddNewPreview(index);
                        MainWindow.Instance.GetDrawPane().ImportGifFrame(bitmaps[i], MainWindow.Instance.GetOptionsBar().GetCurrentScale(), (int)nativeScaleSelect.Value);
                    }
                }
            }

            stream.Close();
        }
    }
}
