namespace PixelFlow
{
    partial class ImportControl
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.bushDidBumpin = new System.Windows.Forms.Button();
            this.nativeScaleSelect = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nativeScaleSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Location = new System.Drawing.Point(270, 3);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(27, 23);
            this.fileSelectButton.TabIndex = 0;
            this.fileSelectButton.Text = "...";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(4, 4);
            this.fileBox.Name = "fileBox";
            this.fileBox.ReadOnly = true;
            this.fileBox.Size = new System.Drawing.Size(260, 20);
            this.fileBox.TabIndex = 1;
            this.fileBox.Text = "Select File to Import";
            // 
            // bushDidBumpin
            // 
            this.bushDidBumpin.Location = new System.Drawing.Point(123, 31);
            this.bushDidBumpin.Name = "bushDidBumpin";
            this.bushDidBumpin.Size = new System.Drawing.Size(174, 48);
            this.bushDidBumpin.TabIndex = 2;
            this.bushDidBumpin.Text = "Import";
            this.bushDidBumpin.UseVisualStyleBackColor = true;
            this.bushDidBumpin.Click += new System.EventHandler(this.bushDidBumpin_Click);
            // 
            // nativeScaleSelect
            // 
            this.nativeScaleSelect.Location = new System.Drawing.Point(77, 47);
            this.nativeScaleSelect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nativeScaleSelect.Name = "nativeScaleSelect";
            this.nativeScaleSelect.Size = new System.Drawing.Size(40, 20);
            this.nativeScaleSelect.TabIndex = 3;
            this.nativeScaleSelect.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Native Scale";
            // 
            // ImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nativeScaleSelect);
            this.Controls.Add(this.bushDidBumpin);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.fileSelectButton);
            this.Name = "ImportControl";
            this.Size = new System.Drawing.Size(300, 84);
            ((System.ComponentModel.ISupportInitialize)(this.nativeScaleSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.TextBox fileBox;
        private System.Windows.Forms.Button bushDidBumpin;
        private System.Windows.Forms.NumericUpDown nativeScaleSelect;
        private System.Windows.Forms.Label label1;
    }
}
