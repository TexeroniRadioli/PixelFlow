namespace PixelFlow
{
    partial class PngExport
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
            this.currentButton = new System.Windows.Forms.Button();
            this.allButton = new System.Windows.Forms.Button();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleSelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.scaleSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // currentButton
            // 
            this.currentButton.Location = new System.Drawing.Point(3, 3);
            this.currentButton.Name = "currentButton";
            this.currentButton.Size = new System.Drawing.Size(143, 52);
            this.currentButton.TabIndex = 0;
            this.currentButton.Text = "Export Current Frame";
            this.currentButton.UseVisualStyleBackColor = true;
            this.currentButton.Click += new System.EventHandler(this.currentButton_Click);
            // 
            // allButton
            // 
            this.allButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.allButton.Location = new System.Drawing.Point(148, 3);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(143, 52);
            this.allButton.TabIndex = 1;
            this.allButton.Text = "Export All";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(67, 84);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(224, 20);
            this.fileNameBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "File Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Scale:";
            // 
            // scaleSelector
            // 
            this.scaleSelector.Location = new System.Drawing.Point(67, 62);
            this.scaleSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scaleSelector.Name = "scaleSelector";
            this.scaleSelector.Size = new System.Drawing.Size(38, 20);
            this.scaleSelector.TabIndex = 5;
            this.scaleSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PngExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleSelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.currentButton);
            this.Name = "PngExport";
            this.Size = new System.Drawing.Size(294, 109);
            ((System.ComponentModel.ISupportInitialize)(this.scaleSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button currentButton;
        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown scaleSelector;
    }
}
