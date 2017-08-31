namespace PixelFlow
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.animationPane1 = new PixelFlow.AnimationPane();
            this.toolbarPane1 = new PixelFlow.ToolbarPane();
            this.optionsBar1 = new PixelFlow.OptionsBar();
            this.drawPanePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // animationPane1
            // 
            this.animationPane1.BackColor = System.Drawing.SystemColors.GrayText;
            this.animationPane1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationPane1.Dock = System.Windows.Forms.DockStyle.Right;
            this.animationPane1.Location = new System.Drawing.Point(751, 66);
            this.animationPane1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.animationPane1.Name = "animationPane1";
            this.animationPane1.Size = new System.Drawing.Size(433, 615);
            this.animationPane1.TabIndex = 6;
            // 
            // toolbarPane1
            // 
            this.toolbarPane1.BackColor = System.Drawing.SystemColors.GrayText;
            this.toolbarPane1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolbarPane1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolbarPane1.Location = new System.Drawing.Point(0, 66);
            this.toolbarPane1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toolbarPane1.Name = "toolbarPane1";
            this.toolbarPane1.Size = new System.Drawing.Size(112, 615);
            this.toolbarPane1.TabIndex = 4;
            // 
            // optionsBar1
            // 
            this.optionsBar1.BackColor = System.Drawing.SystemColors.GrayText;
            this.optionsBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.optionsBar1.Location = new System.Drawing.Point(0, 0);
            this.optionsBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optionsBar1.Name = "optionsBar1";
            this.optionsBar1.Size = new System.Drawing.Size(1184, 66);
            this.optionsBar1.TabIndex = 5;
            this.optionsBar1.Load += new System.EventHandler(this.optionsBar1_Load);
            // 
            // drawPanePanel
            // 
            this.drawPanePanel.AutoScroll = true;
            this.drawPanePanel.AutoSize = true;
            this.drawPanePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPanePanel.Location = new System.Drawing.Point(112, 66);
            this.drawPanePanel.Name = "drawPanePanel";
            this.drawPanePanel.Size = new System.Drawing.Size(639, 615);
            this.drawPanePanel.TabIndex = 7;
            this.drawPanePanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.drawPanePanel_Scroll);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.drawPanePanel);
            this.Controls.Add(this.animationPane1);
            this.Controls.Add(this.toolbarPane1);
            this.Controls.Add(this.optionsBar1);
            this.MinimumSize = new System.Drawing.Size(1198, 688);
            this.Name = "MainWindow";
            this.Text = "PixelFlow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolbarPane toolbarPane1;
        private OptionsBar optionsBar1;
        private AnimationPane animationPane1;
        private System.Windows.Forms.Panel drawPanePanel;
    }
}

