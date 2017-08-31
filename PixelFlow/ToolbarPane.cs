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
    public partial class ToolbarPane : UserControl
    {

        private string activeTool; // stores the tool that is currently active

        private MainWindow mainWindow;

        public ToolbarPane()
        {
            InitializeComponent();
            mainWindow = (MainWindow)this.Parent;
            activeTool = "pencil";
            ResetButtonColors();
            this.pencilTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Returns the active tool for use in the DrawPane
         */
        public string GetActiveTool()
        {
            return this.activeTool;
        }

        public void SetActiveTool(string tool)
        {
            this.activeTool = tool;
        }

        /*
         * Allows the setting of the primary color through a color dialog
         * Passes the color information to the DrawPane
         */
        private void primaryColorSelector_Click(object sender, EventArgs e)
        {
            primaryColorDialog.ShowDialog();
            mainWindow = (MainWindow)this.Parent; // in case the parent is not currently set
            mainWindow.GetDrawPane().SetPrimaryColor(primaryColorDialog.Color);
            SetPrimaryColorSelector(primaryColorDialog.Color);
        }

        public void SetPrimaryColorSelector(Color color)
        {
            primaryColorSelector.BackColor = color;
        }

        /*
         * Allows the setting of the secondary color through a color dialog
         * Passes the color information to the DrawPane
         */
        private void secondaryColorSelector_Click(object sender, EventArgs e)
        {
            secondaryColorDialog.ShowDialog();
            mainWindow = (MainWindow)this.Parent; // in case the parent is not currently set
            mainWindow.GetDrawPane().SetSecondaryColor(secondaryColorDialog.Color);
            SetSecondaryColorSelector(secondaryColorDialog.Color);
        }

        public void SetSecondaryColorSelector(Color color)
        {
            secondaryColorSelector.BackColor = color;
        }

        /*
         * Sets the active tool to the pencil tool, resets every buttons color, and sets the color of this button to blue
         */
        private void pencilTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "pencil";
            ResetButtonColors();
            this.pencilTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the line tool, resets every buttons color, and sets the color of this button to blue
         */
        private void lineTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "line";
            ResetButtonColors();
            this.lineTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the circle tool, resets every buttons color, and sets the color of this button to blue
         */
        private void circleTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "circle";
            ResetButtonColors();
            this.circleTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the rectangle tool, resets every buttons color, and sets the color of this button to blue
         */
        private void rectangleTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "rectangle";
            ResetButtonColors();
            this.rectangleTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the gradient tool, resets every buttons color, and sets the color of this button to blue
         */
        private void gradientTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "gradient";
            ResetButtonColors();
            this.gradientTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the fill tool, resets every buttons color, and sets the color of this button to blue
         */
        private void fillTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "fill";
            ResetButtonColors();
            this.fillTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the select tool, resets every buttons color, and sets the color of this button to blue
         */
        private void selectTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "select";
            ResetButtonColors();
            this.selectTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the eyedropper tool, resets every buttons color, and sets the color of this button to blue
         */
        private void eyedropperTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "eyedropper";
            ResetButtonColors();
            this.eyedropperTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets the active tool to the drag tool, resets every buttons color, and sets the color of this button to blue
         */
        private void dragTool_Click(object sender, EventArgs e)
        {
            this.activeTool = "drag";
            ResetButtonColors();
            this.dragTool.BackColor = Color.LightSkyBlue;
        }

        /*
         * Sets all of the button colors to LightGray to show that they are not active
         */
        void ResetButtonColors()
        {
            this.pencilTool.BackColor = Color.LightGray;
            this.lineTool.BackColor = Color.LightGray;
            this.circleTool.BackColor = Color.LightGray;
            this.rectangleTool.BackColor = Color.LightGray;
            this.gradientTool.BackColor = Color.LightGray;
            this.fillTool.BackColor = Color.LightGray;
            this.selectTool.BackColor = Color.LightGray;
            this.eyedropperTool.BackColor = Color.LightGray;
            this.dragTool.BackColor = Color.LightGray;
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mainWindow = (MainWindow)this.Parent;
            mainWindow.GetDrawPane().SetPrimaryAlpha((int)this.alpha1Value.Value);
        }

        private void alpha2Value_ValueChanged(object sender, EventArgs e)
        {
            mainWindow = (MainWindow)this.Parent;
            mainWindow.GetDrawPane().SetSecondaryAlpha((int)this.alpha2Value.Value);
        }

        
    }
}
