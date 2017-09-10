using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygons.Forms.HelperForms
{
    internal partial class DeleteFileConfirmation : Form
    {
        internal DeleteFileConfirmation(string caption, bool faultyFile = false)
        {
            InitializeComponent();

            if (!faultyFile)
            {
                int nFiles;
                if (int.TryParse(caption, out nFiles))
                { captionTextBox.Text = String.Format("Delete {0} files?", nFiles); }
                else
                { captionTextBox.Text = String.Format("Delete {0}?", caption); } 
            }
            else
            {
                captionTextBox.Text = String.Format("There's something wrong with {0}. Get rid of it?", caption);
            }
        }

        private static bool DeleteOK { get; set; }
        internal static bool Confirm(string fileDescription = "", bool faultyFile = false)
        {
            DeleteFileConfirmation del = new DeleteFileConfirmation(fileDescription, faultyFile);
            del.ShowDialog();
            return DeleteOK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DeleteOK = false;
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteOK = true;
            Close();
        }
    }
}
