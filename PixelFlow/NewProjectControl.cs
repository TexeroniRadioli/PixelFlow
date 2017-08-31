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
    public partial class NewProjectControl : UserControl
    {
        public NewProjectControl()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            int index = MainWindow.Instance.AddNewFrame(new Size((int)nativeWidth.Value, (int)nativeHeight.Value), (int)currentScale.Value);
            if (index == -1)
                return;
            MainWindow.Instance.GetAnimationPane().GetFramePreview().AddNewPreview(index);

            ((Form)Parent).Close();
        }
    }
}
