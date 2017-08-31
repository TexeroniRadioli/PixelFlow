using System;
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
    public partial class FramePreview : UserControl
    {
        /*
        private List<Bitmap> animation = new List<Bitmap>();
        public int numFrames;
        public int currFrame;
        */
        private List<FrameButton> previewButtons;

        public FramePreview()
        {
            InitializeComponent();

            previewButtons = new List<FrameButton>();
        }

        public void AddNewPreview(int index)
        {
            FrameButton newButton = new FrameButton(index);
            previewButtons.Add(newButton);

            Controls.Add(newButton);
            if (index == 0)
                newButton.Location = new Point(5, 0);
            else
                newButton.Location = new Point(previewButtons[index - 1].Location.X + newButton.Width + 5, 0);
        }

        public void DeletePreview(int index)
        {
            FrameButton toDelete = previewButtons[index];
            Controls.Remove(toDelete);
            previewButtons.RemoveAt(index);
            toDelete.Dispose();
            packPreviewButtons();
        }

        public FrameButton GetPreviewButton(int index)
        {
            return previewButtons[index];
        }

        private void packPreviewButtons()
        {
            for (int i = 0; i < previewButtons.Count; i++)
            {
                if (i == 0)
                {
                    previewButtons[i].Location = new Point(5, 0);
                    previewButtons[i].SetIndex(i);
                }
                else
                {
                    previewButtons[i].Location = new Point(previewButtons[i - 1].Location.X + previewButtons[i].Width + 5, 0);
                    previewButtons[i].SetIndex(i);
                }
            }
        }

        /*
        public void AddFrame(Bitmap image)
        {
            animation.Add(image);
            numFrames = animation.Count;
        }

        public Bitmap GetCurrentFrame()
        {
            return animation[currFrame];
        }
        */
    }
}