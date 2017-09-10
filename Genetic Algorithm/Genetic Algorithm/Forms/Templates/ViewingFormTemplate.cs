using Genetic_Algorithm.GA;
using Polygons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genetic_Algorithm.Forms
{
    /// <summary>
    /// Management of multiple Genetic algorithm polygon individuals
    /// </summary>
    public partial class ViewingFormTemplate : Form
    {
        #region Main
        Population<PolygonIndividual, PolygonGene> population;
        SymmetryFitnessCalculator fitnessCalculator = new SymmetryFitnessCalculator();
        private readonly static Color defaultPicturesBackground = Color.DarkCyan;

        /// <summary>
        /// Creates a population management form for Genetic algorithm
        /// </summary>
        public ViewingFormTemplate()
        {
            InitializeComponent();

            SettingsAccessor.PopulationSize = 25;
            SettingsAccessor.SaveSettings();

            popSizeUpdown.Value = SettingsAccessor.PopulationSize;
            verticesUpdown.Value = SettingsAccessor.PolygonsVertices;

            picturesBackgroundColorDialog.Color = defaultPicturesBackground;
            openShapesDialog.InitialDirectory = Paths.PolygonSavedShapesFolder();

            savedShapesNotification.Icon = SystemIcons.Information;
            savedShapesNotification.BalloonTipIcon = ToolTipIcon.Info;
        }

        /// <summary>
        /// Paint the controls of the form
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (picturesLayoutPanel.Controls != null)
            { PaintPopulation(); }
        }

        private void PopulationForm_Resize(object sender, EventArgs e)
        {
            PaintPopulation();
            picturesLayoutPanel.Invalidate();
        }

        /// <summary>
        /// Safely close form on ESC press
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region Population Control
        private void RemoveCurrentPopulation()
        {
            foreach (var item in picturesLayoutPanel.Controls)
            {
                Control c = item as Control;
                c.Dispose();
            }
            picturesLayoutPanel.Controls.Clear();
            if (population != null)
            { population.Clear(); }
        }

        private void RemoveIndividual(LabeledPolygonImage image)
        {
            population.Remove(population.FirstOrDefault(indiv => indiv.Polygon == image.SavedPolygon));
            picturesLayoutPanel.Controls.Remove(image);
        }

        private void CreateNewPopulation()
        {
            RemoveCurrentPopulation();
            population = new Population<PolygonIndividual, PolygonGene>((int)popSizeUpdown.Value);
        }

        private void OverwritePopulationPictures()
        {
            picturesLayoutPanel.Controls.Clear();
            SavePopulationPictures();
        }

        private void createPopulationButton_Click(object sender, EventArgs e)
        {
            CreateNewPopulation();
            SavePopulationPictures();
        }

        private void clearPopulationbutton_Click(object sender, EventArgs e)
        {
            RemoveCurrentPopulation();
        }

        private void verticesUpdown_ValueChanged(object sender, EventArgs e)
        {
            SettingsAccessor.PolygonsVertices = (int)verticesUpdown.Value;
        }
        #endregion

        #region Images management
        private void SavePopulationPictures()
        {
            SuspendLayout();

            IEnumerable<PolygonIndividual> populationOrder;
            if (sortPopulationCheckbox.Checked)
            {
                populationOrder = population?.
                   OrderByDescending(indiv => fitnessCalculator.IndividualFitness(indiv));
            }
            else
            {
                populationOrder = population;
            }
            if (populationOrder != null)
            {
                foreach (var individual in populationOrder)
                {
                    picturesLayoutPanel.Controls.Add(BuildLabeledImage(individual));
                }
            }

            ResumeLayout();
            Invalidate();
        }

        private LabeledPolygonImage BuildLabeledImage(PolygonIndividual buildFrom)
        {
            var result = new LabeledPolygonImage(Polygon.Copy(buildFrom.Polygon));
            result.Description =
                $"{buildFrom.Polygon.Name}{System.Environment.NewLine}Fitness: {fitnessCalculator.IndividualFitness(buildFrom)}";
            result.BackColor = picturesBackgroundColorDialog.Color;
            result.ContextMenuStrip = labeledImageContextMenu;
            result.Width = currentImagesWidth;
            result.Height = currentImagesHeight;
            return result;
        }

        #region Images constants
        private const int DEFAULT_IMAGES_WIDTH = 200;
        private const int DEFAULT_IMAGES_HEIGHT = 250;
        private int currentImagesWidth = DEFAULT_IMAGES_WIDTH;
        private int currentImagesHeight = DEFAULT_IMAGES_HEIGHT;
        #endregion
        private void PaintPopulation()
        {
            SuspendLayout();
            foreach (LabeledPolygonImage c in picturesLayoutPanel.Controls)
            {
                c.Width = currentImagesWidth;
                c.Height = currentImagesHeight;
                c.BackColor = picturesBackgroundColorDialog.Color;
                c.Invalidate();
            }
            ResumeLayout();
        }

        private void picturesLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            LinearGradientBrush lgBrush = new LinearGradientBrush(
                picturesLayoutPanel.ClientRectangle,
                Color.DarkCyan, Color.DarkSlateGray,
                LinearGradientMode.Horizontal);
            g.FillRectangle(lgBrush, picturesLayoutPanel.ClientRectangle); 
        }

        private void picturesBackColorButton_Click(object sender, EventArgs e)
        {
            picturesBackgroundColorDialog.ShowDialog();
            Invalidate();
        }

        private void picturesSizeBar_ValueChanged(object sender, EventArgs e)
        {
            int scaleValue = picturesSizeBar.Value;
            scaleValue = scaleValue < 3 ? 3 : scaleValue;
            double sizeBarMean = (double)((picturesSizeBar.Minimum + picturesSizeBar.Maximum) / 2);
            double scaleFactor = (double)scaleValue / sizeBarMean;
            currentImagesWidth = (int)(DEFAULT_IMAGES_WIDTH * scaleFactor);
            currentImagesHeight = (int)(DEFAULT_IMAGES_HEIGHT * scaleFactor);
            Invalidate();
        }

        private void sortPopulationCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            OverwritePopulationPictures();
        }

        private void resetColorButton_Click(object sender, EventArgs e)
        {
            picturesBackgroundColorDialog.Color = defaultPicturesBackground;
            Invalidate();
        }
        #endregion

        #region Import/Export
        private void createShapesButton_Click(object sender, EventArgs e)
        {
            new PolygonCreationForm().Show();
        }

        private IEnumerable<LabeledPolygonImage> SelectedImages()
        {
            IEnumerable<LabeledPolygonImage> polygonImages = picturesLayoutPanel.Controls.OfType<LabeledPolygonImage>();
            return polygonImages.Where(image => image.Selected).ToList();
        }

        private void saveSelectionButton_Click(object sender, EventArgs e)
        {
            IEnumerable<Polygon> selected = SelectedImages().Select(image => image.SavedPolygon);
            foreach (var selectedPolygon in selected)
            {
                PolygonXmlHandler.SaveToDefaultFolder(selectedPolygon);
            }
            if (selected.Count() > 0)
            { savedShapesNotification.ShowBalloonTip(2000); }
        }

        private void importShapesButton_Click(object sender, EventArgs e)
        {
            if (openShapesDialog.ShowDialog() == DialogResult.OK && ValidFolderSelected)
            {
                if (population == null)
                { population = new Population<PolygonIndividual, PolygonGene>(); }

                foreach (var file in openShapesDialog.FileNames)
                {
                    var newIndividual = new PolygonIndividual(PolygonXmlHandler.Load(file));
                    population.Add(newIndividual);
                    picturesLayoutPanel.Controls.Add(BuildLabeledImage(newIndividual));
                }

                if (sortPopulationCheckbox.Checked)
                { OverwritePopulationPictures(); }
            }
        }

        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            foreach (var image in SelectedImages())
            {
                DeleteIndividual(image);
            }
        }
        #endregion

        #region  Images Contextmenustrip
        private LabeledPolygonImage GetImageFromSender(object sender)
        {
            // Try to cast the sender to a ToolStripItem
            ToolStripItem menuItem = sender as ToolStripItem;
            // Retrieve the ContextMenuStrip that owns this ToolStripItem
            ContextMenuStrip owner = menuItem?.Owner as ContextMenuStrip;
            // Get the control that is displaying this context menu and try to cast it as a LabeledPolygonImage
            return owner?.SourceControl as LabeledPolygonImage;
        }

        private void saveShapeMenuItem_Click(object sender, EventArgs e)
        {
            var image = GetImageFromSender(sender);
            PolygonXmlHandler.SaveToDefaultFolder(image?.SavedPolygon);
        }

        private void removeShapeFromPopulationMenuItem_Click(object sender, EventArgs e)
        {
            var image = GetImageFromSender(sender);
            RemoveIndividual(image);
        }

        private void replaceShapeMenuItem_Click(object sender, EventArgs e)
        {
            var image = GetImageFromSender(sender);
            if (openShapesDialog.ShowDialog() == DialogResult.OK && ValidFolderSelected)
            {
                Polygon replacementPolygon = PolygonXmlHandler.Load(openShapesDialog.FileName);
                PolygonIndividual replacementIndividual = new PolygonIndividual(replacementPolygon);
                ReplaceIndividual(image, replacementIndividual);
                OverwritePopulationPictures();
                Invalidate();
            }
        }

        private void ReplaceIndividual(LabeledPolygonImage toReplace, PolygonIndividual replaceWith)
        {
            population.Replace(
                    population.Find(toReplace.SavedPolygon.Name),
                    replaceWith);

            picturesLayoutPanel.Controls.Remove(toReplace);
            picturesLayoutPanel.Controls.Add(BuildLabeledImage(replaceWith));
        }

        private bool ValidFolderSelected { get; set; }
        private void openShapesDialog_FileOk(object sender, CancelEventArgs e)
        {
            //check if user left the predefined directory
            if (openShapesDialog.FileName.Contains(Paths.LocalPath(openShapesDialog.InitialDirectory)))
            {
                ValidFolderSelected = true;
            }
            else
            {
                MessageBox.Show("You have left the pre-set directory. Invalid action.");
                ValidFolderSelected = false;
            }
        }

        private void DeleteIndividual(LabeledPolygonImage selectedToDelete)
        {
            population.Remove(population.Find(selectedToDelete.SavedPolygon.Name));
            picturesLayoutPanel.Controls.Remove(selectedToDelete);
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var image in picturesLayoutPanel.Controls)
            {
                if (image is LabeledPolygonImage)
                {
                    var labeledImage = image as LabeledPolygonImage;
                    labeledImage.Select();
                }
            }
        }

        private void deselectAllMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var image in picturesLayoutPanel.Controls)
            {
                if (image is LabeledPolygonImage)
                {
                    var labeledImage = image as LabeledPolygonImage;
                    labeledImage.Deselect();
                }
            }
        }
        #endregion
    }
}
