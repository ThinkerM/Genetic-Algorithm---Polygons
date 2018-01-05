using System;
using System.Windows.Forms;

namespace Polygons.Forms.DialogForms
{
    internal partial class DeleteFileConfirmation : Form
    {
        private DeleteFileConfirmation(string captionFileName, bool faultyFile = false)
        {
            InitializeComponent();

            if (!faultyFile)
            {
                int nFiles;
                captionTextBox.Text = int.TryParse(captionFileName, out nFiles)
                    ? $"Delete {nFiles} files?"
                    : $"Delete {captionFileName}?";
            }
            else
            {
                captionTextBox.Text = $"There's something wrong with {captionFileName}. Get rid of it?";
            }
        }

        private static bool DeleteOk { get; set; }
        internal static bool Confirm(string fileDescription = "", bool faultyFile = false)
        {
            DeleteFileConfirmation del = new DeleteFileConfirmation(fileDescription, faultyFile);
            del.ShowDialog();
            return DeleteOk;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DeleteOk = false;
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteOk = true;
            Close();
        }
    }
}
