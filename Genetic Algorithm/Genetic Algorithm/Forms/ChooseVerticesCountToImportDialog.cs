using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoreLinq;

namespace Genetic_Algorithm.Forms
{
    /// <summary>
    /// Structure used to transfer constructor data to <see cref="ChooseVerticesCountToImportDialog"/>.
    /// <para>Holds information about a group of polygon individuals - the group's vertex count and number of individuals in the group.</para>
    /// </summary>
    internal struct IndividualsOfVertexCountPair
    {
        public int VertexCount { get; }
        public int IndividualsCount { get; }

        public IndividualsOfVertexCountPair(int vertexCount, int individuals)
        {
            VertexCount = vertexCount;
            IndividualsCount = individuals;
        }
    }

    /// <summary>
    /// Helper dialog form used to select a single group of individuals with a uniform vertex count
    /// </summary>
    internal partial class ChooseVerticesCountToImportDialog : Form
    {
        List<RadioButton> allRadioButtons = new List<RadioButton>();

        /// <summary>
        /// Creates a dialog window asking the user to select one of multiple groups
        /// </summary>
        /// <param name="possibleCountPairs">All possible groups to be chosen from</param>
        public ChooseVerticesCountToImportDialog(List<IndividualsOfVertexCountPair> possibleCountPairs)
        {
            InitializeComponent();
            foreach (var pair in possibleCountPairs)
            {
                var newRadioButton = new RadioButton()
                {
                    Text = $"{pair.VertexCount} vertices - {pair.IndividualsCount} individual(s)",
                    Tag = pair.VertexCount,
                    AutoCheck = true
                };
                allRadioButtons.Add(newRadioButton);
                flowLayoutPanel1.Controls.Add(newRadioButton);
            }
            if (allRadioButtons.Count > 0)
            { allRadioButtons[
                possibleCountPairs.
                    IndexOf(possibleCountPairs.MaxBy(i => i.IndividualsCount))]
                        .Checked = true; } //auto-check button with highest individuals count
        }

        /// <summary>
        /// Return value of the dialog
        /// </summary>
        public int? ChosenVertexCount { get; private set; }

        private void okButton_Click(object sender, EventArgs e)
        {
            var checkedButton = allRadioButtons.FirstOrDefault(button => button.Checked);
            ChosenVertexCount = (int?)checkedButton?.Tag;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
