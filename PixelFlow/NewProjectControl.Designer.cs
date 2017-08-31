namespace PixelFlow
{
    partial class NewProjectControl
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
            this.nativeWidth = new System.Windows.Forms.NumericUpDown();
            this.currentScale = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nativeHeight = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nativeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // nativeWidth
            // 
            this.nativeWidth.Location = new System.Drawing.Point(122, 3);
            this.nativeWidth.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nativeWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nativeWidth.Name = "nativeWidth";
            this.nativeWidth.Size = new System.Drawing.Size(36, 20);
            this.nativeWidth.TabIndex = 0;
            this.nativeWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // currentScale
            // 
            this.currentScale.Location = new System.Drawing.Point(84, 30);
            this.currentScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentScale.Name = "currentScale";
            this.currentScale.Size = new System.Drawing.Size(31, 20);
            this.currentScale.TabIndex = 2;
            this.currentScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resolution:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current Scale:";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(94, 56);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 4;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "height:";
            // 
            // nativeHeight
            // 
            this.nativeHeight.Location = new System.Drawing.Point(209, 3);
            this.nativeHeight.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nativeHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nativeHeight.Name = "nativeHeight";
            this.nativeHeight.Size = new System.Drawing.Size(37, 20);
            this.nativeHeight.TabIndex = 1;
            this.nativeHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NewProjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nativeHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentScale);
            this.Controls.Add(this.nativeWidth);
            this.Name = "NewProjectControl";
            this.Size = new System.Drawing.Size(260, 88);
            ((System.ComponentModel.ISupportInitialize)(this.nativeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nativeWidth;
        private System.Windows.Forms.NumericUpDown currentScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nativeHeight;
    }
}
