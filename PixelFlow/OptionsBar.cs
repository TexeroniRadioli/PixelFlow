using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace PixelFlow
{
    public partial class OptionsBar : UserControl
    {

        //private MainWindow mainWindow;

        public OptionsBar()
        {
            InitializeComponent();

            this.undoButton.BackColor = Color.LightGray;
            this.redoButton.BackColor = Color.LightGray;
        }

        public int GetCurrentScale()
        {
            return (int)zoomPercent.Value;
        }

        private void lineThickness_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Instance.GetDrawPane().SetLineThickness((int)lineThickness.Value);
        }

        private void zoomPercent_ValueChanged(object sender, EventArgs e)
        {
            if (MainWindow.Instance.GetCurrentFrameIndex() > -1)
                MainWindow.Instance.GetDrawPane().SetScale((int)zoomPercent.Value);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            
            MainWindow.Instance.GetDrawPane().Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            
            MainWindow.Instance.GetDrawPane().Redo();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportControl exp = new ExportControl();
            DialogueForm dialogue = new DialogueForm(exp, "Export");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportControl imp = new ImportControl();
            DialogueForm dialogue = new DialogueForm(imp, "Import");
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoButton_Click(sender, e);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoButton_Click(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProjectControl npc = new NewProjectControl();
            DialogueForm dialogue = new DialogueForm(npc, "New");
        }
    }
}
