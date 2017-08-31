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
    public partial class AnimationPane : UserControl
    {
        public AnimationPane()
        {
            InitializeComponent();

            this.playPause.BackColor = Color.LightGray;
            this.stepBackward.BackColor = Color.LightGray;
            this.stepForward.BackColor = Color.LightGray;
            this.addFrame.BackColor = Color.LightGray;
            this.copyFrameButton.BackColor = Color.LightGray;
            this.deleteButton.BackColor = Color.LightGray;

            //this.frame.Maximum = this.framesPreview1.numFrames;
        }

        public AnimationPreview GetAnimationPreview()
        {
            return this.animationPreview1;
        }

        public FramePreview GetFramePreview()
        {
            return framePreview1;
        }

        private void addFrame_Click(object sender, EventArgs e)
        {
            int frameIndex = MainWindow.Instance.AddNewFrame();
            if (frameIndex == -1)
                return;
            framePreview1.AddNewPreview(frameIndex);
        }

        private void copyFrameButton_Click(object sender, EventArgs e)
        {
            int frameIndex = MainWindow.Instance.CopyFrame();
            if (frameIndex == -1)
                return;
            framePreview1.AddNewPreview(frameIndex);
            MainWindow.Instance.GetDrawPane().DisplayImage();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int toDelete = MainWindow.Instance.DeleteFrame();
            if (toDelete == -1)
                return;
            framePreview1.DeletePreview(toDelete);
        }

        private void frame_ValueChanged(object sender, EventArgs e)
        {
            //this.framePreview1.currFrame = (int)this.frame.Value;
        }

        private void frameRate_ValueChanged(object sender, EventArgs e)
        {
            this.animationPreview1.frameRate = (int)this.frameRate.Value;
        }

        private void playPause_Click(object sender, EventArgs e)
        {
            this.animationPreview1.PlayPause();
        }

        private void stepForward_Click(object sender, EventArgs e)
        {
            this.animationPreview1.StepToFrame(this.animationPreview1.currentFrame + 1);
        }

        private void stepBackward_Click(object sender, EventArgs e)
        {
            this.animationPreview1.StepToFrame(this.animationPreview1.currentFrame - 1);
        }
    }
}
