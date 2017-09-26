using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygons.Forms.DialogForms
{
    /// <summary>
    /// Dialog box asking the user to confirm overwriting an existing file
    /// </summary>
    internal partial class ShapeOverwritePromptForm : Form
    {
        internal ShapeOverwritePromptForm(string shapeName)
        {
            InitializeComponent();
            richTextBox1.Text = $"You are about to overwrite an existing shape.{Environment.NewLine}Name: {shapeName}{Environment.NewLine}Continue?";
        }
    }
}
