using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace PixelFlow
{
    public partial class AnimationPreview : UserControl
    {
        public int currentFrame = 1;
        public int frameRate = 0;
        public System.Threading.Thread animator;

        public bool paused = true;
        public volatile bool animating = true;

        public AnimationPreview()
        {
            InitializeComponent();
        }

        private void AnimationPreview_Load(object sender, EventArgs e)
        {
            animator = new System.Threading.Thread(Play);
            animator.Start();
        }

        public void Play()
        {
            while(animating)
            {
                if (!paused)
                {
                    if (frameRate != 0)
                    {
                        
                        System.Threading.Thread.Sleep(1000 / frameRate);
                        MethodInvoker mi = delegate ()
                        {
                            StepToFrame(currentFrame + 1);
                        };
                        this.Invoke(mi);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }          
            }
        }

        public void PlayPause()
        {
            paused = !paused;
        }

        public void StepToFrame(int frame)
        {
            currentFrame = frame;
            if (currentFrame > MainWindow.Instance.Frames.Count)
            {
                currentFrame = 1;
            }
            else if (currentFrame < 1)
            {
                currentFrame = MainWindow.Instance.Frames.Count;
            }

            DisplayFrame(currentFrame);
        }

        public void DisplayFrame(int frame)
        {

            Graphics g = this.CreateGraphics();
            // scales the frame to the size of the window, even if the frame is bigger than the previous frame. This is fine because animations should have all frames the same size
            g.DrawImage(MainWindow.Instance.GetDrawPane(frame - 1).GetImage(), 0, 0, this.Width, this.Height);
        }
    }
}
