namespace PixelFlow
{
    partial class GifExport
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
            this.exportButton = new System.Windows.Forms.Button();
            this.scaleSelector = new System.Windows.Forms.NumericUpDown();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.frameRateSelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(3, 3);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(288, 51);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Export!";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // scaleSelector
            // 
            this.scaleSelector.Location = new System.Drawing.Point(63, 60);
            this.scaleSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleSelector.Name = "scaleSelector";
            this.scaleSelector.Size = new System.Drawing.Size(36, 20);
            this.scaleSelector.TabIndex = 1;
            this.scaleSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(63, 86);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(228, 20);
            this.fileNameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Scale:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Frame Rate:";
            // 
            // frameRateSelector
            // 
            this.frameRateSelector.Location = new System.Drawing.Point(177, 60);
            this.frameRateSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameRateSelector.Name = "frameRateSelector";
            this.frameRateSelector.Size = new System.Drawing.Size(34, 20);
            this.frameRateSelector.TabIndex = 6;
            this.frameRateSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // GifExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.frameRateSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.scaleSelector);
            this.Controls.Add(this.exportButton);
            this.Name = "GifExport";
            this.Size = new System.Drawing.Size(294, 109);
            ((System.ComponentModel.ISupportInitialize)(this.scaleSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameRateSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.NumericUpDown scaleSelector;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown frameRateSelector;
    }
}
