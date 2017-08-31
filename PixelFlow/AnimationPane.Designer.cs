namespace PixelFlow
{
    partial class AnimationPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimationPane));
            this.playPause = new System.Windows.Forms.Button();
            this.stepBackward = new System.Windows.Forms.Button();
            this.stepForward = new System.Windows.Forms.Button();
            this.frameRate = new System.Windows.Forms.NumericUpDown();
            this.frameRateText = new System.Windows.Forms.TextBox();
            this.animationToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.addFrame = new System.Windows.Forms.Button();
            this.copyFrameButton = new System.Windows.Forms.Button();
            this.frame = new System.Windows.Forms.NumericUpDown();
            this.frameText = new System.Windows.Forms.TextBox();
            this.layerPreview1 = new PixelFlow.LayerPreview();
            this.framePreview1 = new PixelFlow.FramePreview();
            this.animationPreview1 = new PixelFlow.AnimationPreview();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.frameRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frame)).BeginInit();
            this.SuspendLayout();
            // 
            // playPause
            // 
            this.playPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playPause.BackgroundImage")));
            this.playPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playPause.Location = new System.Drawing.Point(243, 350);
            this.playPause.Name = "playPause";
            this.playPause.Size = new System.Drawing.Size(40, 40);
            this.playPause.TabIndex = 1;
            this.animationToolTips.SetToolTip(this.playPause, "Play or Pause the animation");
            this.playPause.UseVisualStyleBackColor = true;
            this.playPause.Click += new System.EventHandler(this.playPause_Click);
            // 
            // stepBackward
            // 
            this.stepBackward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stepBackward.BackgroundImage")));
            this.stepBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stepBackward.Location = new System.Drawing.Point(113, 350);
            this.stepBackward.Name = "stepBackward";
            this.stepBackward.Size = new System.Drawing.Size(40, 40);
            this.stepBackward.TabIndex = 2;
            this.animationToolTips.SetToolTip(this.stepBackward, "Step backward one frame");
            this.stepBackward.UseVisualStyleBackColor = true;
            this.stepBackward.Click += new System.EventHandler(this.stepBackward_Click);
            // 
            // stepForward
            // 
            this.stepForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stepForward.BackgroundImage")));
            this.stepForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stepForward.Location = new System.Drawing.Point(373, 350);
            this.stepForward.Name = "stepForward";
            this.stepForward.Size = new System.Drawing.Size(40, 40);
            this.stepForward.TabIndex = 3;
            this.animationToolTips.SetToolTip(this.stepForward, "Step forward one frame");
            this.stepForward.UseVisualStyleBackColor = true;
            this.stepForward.Click += new System.EventHandler(this.stepForward_Click);
            // 
            // frameRate
            // 
            this.frameRate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.frameRate.Location = new System.Drawing.Point(357, 18);
            this.frameRate.Name = "frameRate";
            this.frameRate.Size = new System.Drawing.Size(56, 20);
            this.frameRate.TabIndex = 4;
            this.frameRate.ValueChanged += new System.EventHandler(this.frameRate_ValueChanged);
            // 
            // frameRateText
            // 
            this.frameRateText.BackColor = System.Drawing.SystemColors.ControlLight;
            this.frameRateText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frameRateText.Location = new System.Drawing.Point(286, 18);
            this.frameRateText.Name = "frameRateText";
            this.frameRateText.ReadOnly = true;
            this.frameRateText.Size = new System.Drawing.Size(65, 20);
            this.frameRateText.TabIndex = 5;
            this.frameRateText.Text = "Frame Rate";
            // 
            // addFrame
            // 
            this.addFrame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addFrame.BackgroundImage")));
            this.addFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addFrame.Location = new System.Drawing.Point(402, 400);
            this.addFrame.Name = "addFrame";
            this.addFrame.Size = new System.Drawing.Size(30, 30);
            this.addFrame.TabIndex = 8;
            this.animationToolTips.SetToolTip(this.addFrame, "Add new frame");
            this.addFrame.UseVisualStyleBackColor = true;
            this.addFrame.Click += new System.EventHandler(this.addFrame_Click);
            // 
            // copyFrameButton
            // 
            this.copyFrameButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("copyFrameButton.BackgroundImage")));
            this.copyFrameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.copyFrameButton.Location = new System.Drawing.Point(402, 434);
            this.copyFrameButton.Name = "copyFrameButton";
            this.copyFrameButton.Size = new System.Drawing.Size(30, 30);
            this.copyFrameButton.TabIndex = 13;
            this.animationToolTips.SetToolTip(this.copyFrameButton, "Duplicate selected frame");
            this.copyFrameButton.UseVisualStyleBackColor = true;
            this.copyFrameButton.Click += new System.EventHandler(this.copyFrameButton_Click);
            // 
            // frame
            // 
            this.frame.BackColor = System.Drawing.SystemColors.ControlLight;
            this.frame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frame.Location = new System.Drawing.Point(340, 526);
            this.frame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frame.Name = "frame";
            this.frame.Size = new System.Drawing.Size(60, 20);
            this.frame.TabIndex = 9;
            this.frame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frame.ValueChanged += new System.EventHandler(this.frame_ValueChanged);
            // 
            // frameText
            // 
            this.frameText.BackColor = System.Drawing.SystemColors.ControlLight;
            this.frameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frameText.Location = new System.Drawing.Point(288, 526);
            this.frameText.Name = "frameText";
            this.frameText.ReadOnly = true;
            this.frameText.Size = new System.Drawing.Size(46, 20);
            this.frameText.TabIndex = 10;
            this.frameText.Text = "Frame";
            // 
            // layerPreview1
            // 
            this.layerPreview1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.layerPreview1.Location = new System.Drawing.Point(10, 44);
            this.layerPreview1.Name = "layerPreview1";
            this.layerPreview1.Size = new System.Drawing.Size(93, 350);
            this.layerPreview1.TabIndex = 12;
            // 
            // framePreview1
            // 
            this.framePreview1.AutoScroll = true;
            this.framePreview1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.framePreview1.Location = new System.Drawing.Point(10, 400);
            this.framePreview1.Name = "framePreview1";
            this.framePreview1.Size = new System.Drawing.Size(390, 120);
            this.framePreview1.TabIndex = 11;
            // 
            // animationPreview1
            // 
            this.animationPreview1.BackColor = System.Drawing.SystemColors.Window;
            this.animationPreview1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.animationPreview1.Location = new System.Drawing.Point(113, 44);
            this.animationPreview1.Name = "animationPreview1";
            this.animationPreview1.Size = new System.Drawing.Size(300, 300);
            this.animationPreview1.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteButton.Location = new System.Drawing.Point(402, 468);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 30);
            this.deleteButton.TabIndex = 14;
            this.animationToolTips.SetToolTip(this.deleteButton, "Delete selected frame");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // AnimationPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.copyFrameButton);
            this.Controls.Add(this.layerPreview1);
            this.Controls.Add(this.framePreview1);
            this.Controls.Add(this.frameText);
            this.Controls.Add(this.frame);
            this.Controls.Add(this.addFrame);
            this.Controls.Add(this.frameRateText);
            this.Controls.Add(this.frameRate);
            this.Controls.Add(this.stepForward);
            this.Controls.Add(this.stepBackward);
            this.Controls.Add(this.playPause);
            this.Controls.Add(this.animationPreview1);
            this.Name = "AnimationPane";
            this.Size = new System.Drawing.Size(433, 600);
            ((System.ComponentModel.ISupportInitialize)(this.frameRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnimationPreview animationPreview1;
        private System.Windows.Forms.Button playPause;
        private System.Windows.Forms.Button stepBackward;
        private System.Windows.Forms.Button stepForward;
        private System.Windows.Forms.NumericUpDown frameRate;
        private System.Windows.Forms.TextBox frameRateText;
        private System.Windows.Forms.ToolTip animationToolTips;
        private System.Windows.Forms.Button addFrame;
        private System.Windows.Forms.NumericUpDown frame;
        private System.Windows.Forms.TextBox frameText;
        private FramePreview framePreview1;
        private LayerPreview layerPreview1;
        private System.Windows.Forms.Button copyFrameButton;
        private System.Windows.Forms.Button deleteButton;
    }
}
