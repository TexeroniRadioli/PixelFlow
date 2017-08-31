namespace PixelFlow
{
    partial class ExportControl
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
            this.formatBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exportPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // formatBox
            // 
            this.formatBox.FormattingEnabled = true;
            this.formatBox.Items.AddRange(new object[] {
            "Portable Network Graphics (.png)",
            "Graphics Interchange Format (.gif)"});
            this.formatBox.Location = new System.Drawing.Point(75, 11);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(203, 21);
            this.formatBox.TabIndex = 0;
            this.formatBox.Text = "-- File Format --";
            this.formatBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export as:";
            // 
            // exportPanel
            // 
            this.exportPanel.Location = new System.Drawing.Point(3, 38);
            this.exportPanel.Name = "exportPanel";
            this.exportPanel.Size = new System.Drawing.Size(294, 109);
            this.exportPanel.TabIndex = 2;
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exportPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formatBox);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(300, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox formatBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel exportPanel;
    }
}
