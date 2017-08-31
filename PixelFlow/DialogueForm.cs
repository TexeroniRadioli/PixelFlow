using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelFlow
{
    public partial class DialogueForm : Form
    {
        public DialogueForm(Control contents, string title)
        {
            InitializeComponent();
            Controls.Add(contents);
            Text = title;
            Visible = true;
        }
    }
}
