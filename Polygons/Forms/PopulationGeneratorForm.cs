using Genetic_Algorithm.GA;
using Polygons;
using Polygons.Forms;
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
using Genetic_Algorithm.GA.Generics;
using Polygons.GA;
using Polygons.Forms.CustomControls;
using Polygons.Utils;
using Genetic_Algorithm.Utils;

namespace Polygons.Forms
{
    /// <summary>
    /// Management of multiple Genetic algorithm polygon individuals
    /// </summary>
    /// <remarks>
    /// Provides following features (among others):
    /// <list type="bullet">
    ///     <item><description>Import previously created shapes</description></item>
    ///     <item><description>Manage saved shapes in larger quantities</description></item>
    ///     <item><description>Sort viewed images by their fitness</description></item>
    ///     <item><description>Change basic properties of the images</description></item>
    /// </list>
    /// </remarks>
    partial class PopulationGeneratorForm : Form
    {
        #region Main
        private Population<PolygonIndividual, IPolygonGene> population;
        private readonly GA.FitnessCalculators.BasicSymmetryFitnessCalculator fitnessCalculator;
        private readonly PolygonAdapter adapter;
        private static readonly Color DefaultPicturesBackground = Color.DarkCyan;

        /// <summary>
        /// Creates a population management form for Genetic algorithm
        /// </summary>
        public PopulationGeneratorForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            SettingsAccessor.PopulationSize = 25;
            SettingsAccessor.SaveSettings();

            popSizeUpdown.Value = SettingsAccessor.PopulationSize;
            verticesUpdown.Value = PolygonSettingsAccessor.PolygonsVertices;

            picturesBackgroundColorDialog.Color = DefaultPicturesBackground;
            openShapesDialog.InitialDirectory = Paths.PolygonSavedShapesFolder;

            savedShapesNotification.Icon = SystemIcons.Information;
            savedShapesNotification.BalloonTipIcon = ToolTipIcon.Info;

            fitnessCalculator = new GA.FitnessCalculators.BasicSymmetryFitnessCalculator();
            adapter = new PolygonAdapter(fitnessCalculator);
        }

        /// <summary>
        /// Safely close form on ESC press
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys != Keys.None || keyData != Keys.Escape)
            {
                return base.ProcessDialogKey(keyData);
            }
            this.Close();
            return true;
        }
        #endregion

        #region Population Control
        private void RemoveCurrentPopulation()
        {
            foreach (var item in picturesLayoutPanel.Controls)
            {
                Control c = item as Control;
                c?.Dispose();
            }
            picturesLayoutPanel.Controls.Clear();
            if (population != null)
            { population.Clear(); }
            Invalidate();
        }

        private void RemoveIndividual(LabeledPolygonImage image)
        {
            population.Remove(population.FirstOrDefault(indiv => indiv.Polygon == image.SavedPolygon));
            picturesLayoutPanel.Controls.Remove(image);
        }

        private void CreateNewPopulation()
        {
            RemoveCurrentPopulation();
            population = new Population<PolygonIndividual, IPolygonGene>((int)popSizeUpdown.Value);
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
            Utils.PolygonSettingsAccessor.PolygonsVertices = (int)verticesUpdown.Value;
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
                   OrderByDescending(indiv => fitnessCalculator?.IndividualFitness(indiv));
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
                $"{buildFrom.Polygon.Name}{System.Environment.NewLine}Fitness: {fitnessCalculator?.IndividualFitness(buildFrom)}";
            result.BackColor = picturesBackgroundColorDialog.Color;
            result.ContextMenuStrip = labeledImageContextMenu;
            result.Width = currentImagesWidth;
            result.Height = currentImagesHeight;
            result.ImageMouseDown += picturesLayoutPanel_MouseDown;
            result.ImageMouseUp += picturesLayoutPanel_MouseUp;
            return result;
        }

        #region Images constants
        private const int DEFAULT_IMAGES_WIDTH = 200;
        private const int DEFAULT_IMAGES_HEIGHT = 250;
        private int currentImagesWidth = DEFAULT_IMAGES_WIDTH;
        private int currentImagesHeight = DEFAULT_IMAGES_HEIGHT;
        #endregion
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
            if (picturesBackgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var c in picturesLayoutPanel.Controls)
                {
                    var image = c as LabeledPolygonImage;
                    if (image != null)
                    { image.BackColor = picturesBackgroundColorDialog.Color; }
                }
            }
        }

        private void picturesSizeBar_ValueChanged(object sender, EventArgs e)
        {
            int scaleValue = picturesSizeBar.Value;
            scaleValue = scaleValue < 3 ? 3 : scaleValue;
            double sizeBarMean = (double)((picturesSizeBar.Minimum + picturesSizeBar.Maximum) / 2);
            double scaleFactor = (double)scaleValue / sizeBarMean;
            currentImagesWidth = (int)(DEFAULT_IMAGES_WIDTH * scaleFactor);
            currentImagesHeight = (int)(DEFAULT_IMAGES_HEIGHT * scaleFactor);
            foreach (var c in picturesLayoutPanel.Controls)
            {
                var image = c as LabeledPolygonImage;
                if (image != null)
                {
                    image.Width = currentImagesWidth;
                    image.Height = currentImagesHeight;
                    image.Invalidate();
                }
            }
        }

        private void sortPopulationCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            OverwritePopulationPictures();
        }

        private void resetColorButton_Click(object sender, EventArgs e)
        {
            picturesBackgroundColorDialog.Color = DefaultPicturesBackground;
            foreach (var c in picturesLayoutPanel.Controls)
            {
                var image = c as LabeledPolygonImage;
                if (image != null)
                { image.BackColor = DefaultPicturesBackground; }
            }
        }
        #endregion

        #region Import/Export
        private void createShapesButton_Click(object sender, EventArgs e) => new PolygonCreationForm().Show();


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
                { population = new Population<PolygonIndividual, IPolygonGene>(); }

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
            (image?.SavedPolygon).SaveToDefaultFolder();
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
            if (openShapesDialog.FileName.Contains(openShapesDialog.InitialDirectory))
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
                var labeledImage = image as LabeledPolygonImage;
                labeledImage?.Select();
            }
        }

        private void deselectAllMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var image in picturesLayoutPanel.Controls)
            {
                var labeledImage = image as LabeledPolygonImage;
                labeledImage?.Deselect();
            }
        }
        #endregion

        #region Images Drag'n'Drop

        #endregion

        private LabeledPolygonImage beingDragged = null;
        private void picturesLayoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            var imageAtLocation = picturesLayoutPanel.GetChildAtPoint(e.Location) as LabeledPolygonImage;
            if (imageAtLocation == null) { return; }
            beingDragged = imageAtLocation;
        }

        private void picturesLayoutPanel_MouseUp(object sender, MouseEventArgs e)
        {
            var imageAtLocation = picturesLayoutPanel.GetChildAtPoint(e.Location) as LabeledPolygonImage;
            if (imageAtLocation == null || beingDragged == null || imageAtLocation == beingDragged)
            {
                //either dragged didn't land on another image or landed on itself => no UI reaction
                beingDragged = null;
                return;
            }

            var child = ReproduceImages(imageAtLocation, beingDragged);
            population.Add(child);
            if (sortPopulationCheckbox.Checked)
            { OverwritePopulationPictures(); }
            else
            { picturesLayoutPanel.Controls.Add(BuildLabeledImage(child)); }
            beingDragged = null;
        }

        private PolygonIndividual ReproduceImages(LabeledPolygonImage image1, LabeledPolygonImage image2)
             {
            var newIndividual = adapter.CrossOver(new PolygonIndividual(image1.SavedPolygon), new PolygonIndividual(image2.SavedPolygon));
            adapter.Mutate(newIndividual, Genetic_Algorithm.Utils.SettingsAccessor.MutationProbability);
            return newIndividual;
        }
        
    }
}
