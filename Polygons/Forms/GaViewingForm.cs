using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MoreLinq;
using Genetic_Algorithm.GA.Generics;
using Polygons.GA;
using Polygons.Forms.CustomControls;
using Polygons.Forms.DialogForms;
using Genetic_Algorithm.Utils;
using Polygons.Utils;


namespace Polygons.Forms
{
    /// <summary>
    /// Visualization and customization of a Genetic algorithm with Polygons.
    /// </summary>
    /// <remarks>
    /// Provides following features (among others):
    /// <list type="bullet">
    ///     <item><description>Import previously created individuals into a GA's initial population</description></item>
    ///     <item><description>Modify parameters of the genetic algorithm</description></item>
    ///     <item><description>Change frequency of generations in the GA to be viewed</description></item>
    ///     <item><description>Change frequency of generations to be saved during the run of the GA</description></item>
    ///     <item><description>View generated populations and change basic properties of the images</description></item>
    /// </list>
    /// </remarks>
    partial class GaViewerForm : Form
    {
        #region Main
        private class FitnessCalculatorWrapper 
            //ensures that FitnessCalculatorChanged event is always fired
            //(prevents circumventing the event, which could happen by accessing the backing field directly)
        {
            public event EventHandler FitnessCalculatorChanged;
            private IFitnessCalculator<PolygonIndividual, IPolygonGene> fitnessCalculator;
            public IFitnessCalculator<PolygonIndividual, IPolygonGene> FitnessCalculator
            {
                get { return fitnessCalculator; }
                set { fitnessCalculator = value; FitnessCalculatorChanged?.Invoke(null, EventArgs.Empty); }
            }
        }
        private readonly FitnessCalculatorWrapper fitnessCalculatorWrapper = new FitnessCalculatorWrapper();
        private readonly BindingList<IFitnessCalculator<PolygonIndividual, IPolygonGene>> availableFitnessCalculators;
        private IFitnessCalculator<PolygonIndividual, IPolygonGene> FitnessCalculator
        {
            get { return fitnessCalculatorWrapper.FitnessCalculator; }
            set { fitnessCalculatorWrapper.FitnessCalculator = value; }
        }
        private GeneticAlgorithm<PolygonIndividual, IPolygonGene> geneticAlgorithm;

        private BindingList<NumberedPopulation<PolygonIndividual, IPolygonGene>> savedGaPopulations = new BindingList<NumberedPopulation<PolygonIndividual, IPolygonGene>>();
        private double bestInitialFitness;
        private Population<PolygonIndividual, IPolygonGene> displayPopulation;

        private readonly IEnumerable<Control> gaRunningVisibilitySensitiveControls;
        private static readonly Color DefaultPicturesBackground = Color.Teal;

        /// <summary>
        /// Creates an instance of a form for visualizing and customizing the run of a Genetic algorithm for Polygons
        /// </summary>
        /// <param name="availableFitnessCalculators">All Fitness calculators which the form can load into its options</param>
        public GaViewerForm(IEnumerable<IFitnessCalculator<PolygonIndividual, IPolygonGene>> availableFitnessCalculators)
        {
            InitializeComponent();
            ReadParametersFromSettings();

            SavedGenerationsCombobox_DefaultWidth = savedGenerationsCombobox.Width;
            savedGenerationsCombobox.DataSource = savedGaPopulations;
            logBox.DataSource = logLines;
            importPopulationDialog.InitialDirectory = Paths.PolygonSavedShapesFolderNoBacklash;
            picturesBackgroundColorDialog.Color = DefaultPicturesBackground;
            this.availableFitnessCalculators = new BindingList<IFitnessCalculator<PolygonIndividual, IPolygonGene>>(availableFitnessCalculators.ToList());
            fitnessFunctionComboBox.DataSource = this.availableFitnessCalculators;
            FitnessFunctionComboBox_DefaultWidth = fitnessFunctionComboBox.Width;
            displayPopulation = Population<PolygonIndividual, IPolygonGene>.EmptyPopulation();

            fitnessCalculatorWrapper.FitnessCalculatorChanged += OnFitnessCalculatorChanged;
            GeneticAlgorithm<PolygonIndividual, IPolygonGene>.Initialised += OnGaInitialised;
            
            gaRunningVisibilitySensitiveControls = new Control[]
            {
                importInitialPopulationButton,
                fitnessFunctionComboBox,
                fitnessfunctionLabel,
                continueButton,
                populationSizeUpdown,
                populationSizeLabel,
                savedGenerationsCombobox,
                verticesCountUpdown,
                verticesCountLabel,
            };
        }

        private void Reset()
        {
            startStopGaButton.Text = START_GA_BUTTON_TEXT;
            currentFunction = CurrentGaButtonFunction.Start;
            geneticAlgorithm = null;
            savedGaPopulations?.Clear();
            displayPopulation = Population<PolygonIndividual, IPolygonGene>.EmptyPopulation();
            logLines.Clear();
            continueButton.Visible = false;
            ignoreTerminationConditionsAbsence = false;
        }
        #endregion

        #region GaFlowControl
        /// <summary>
        /// Process the event of a generation being finished from the underlying <see cref="GeneticAlgorithm{PolygonIndividual, IPolygonGene}"/> 
        /// </summary>
        /// <param name="e"><see cref="GaEventArgs{PolygonIndividual, IPolygonGene}"/> holding information about the finished generation</param>
        protected virtual void OnGaGenerationComplete(GaEventArgs<PolygonIndividual, IPolygonGene> e)
        {
            LogGeneration(e.SavedPopulation);

            bool terminate = Terminate(e.SavedPopulation, e.SavedPopulation.Number);
            bool pause = e.SavedPopulation.Number % (int)pauseFrequencyUpdown.Value == 0;
            if (terminate || pause)
            {
                displayPopulation = e.SavedPopulation;
                UpdatePopulationPictures();
                continueButton.Visible = !terminate;
            }
            if (e.SavedPopulation.Number % (int)saveFrequencyUpdown.Value == 0)
            {
                savedGaPopulations.Add(e.SavedPopulation);
                savedGenerationsCombobox.SelectedIndex = savedGenerationsCombobox.Items.Count - 1;
            }
        }

        /// <summary>
        /// Process the event of the underlying <see cref="GaEventArgs{PolygonIndividual, IPolygonGene}"/> having been initialised
        /// </summary>
        /// <param name="e"><see cref="GaEventArgs{PolygonIndividual, IPolygonGene}"/> holding information about the initial generation</param>
        protected virtual void OnGaInitialised(GaEventArgs<PolygonIndividual, IPolygonGene> e)
        {
            displayPopulation = e.SavedPopulation;
            bestInitialFitness = e.SavedPopulation.Select(i => FitnessCalculator.IndividualFitness(i)).Max();
            e.SavedPopulation.TrySetFitness(bestInitialFitness);
            savedGaPopulations.Add(e.SavedPopulation);
            UpdatePopulationPictures();
        }

        private const string START_GA_BUTTON_TEXT = "Start GA!";
        private const string STOP_GA_BUTTON_TEXT = "Stop and reset";
        private enum CurrentGaButtonFunction { Start, Stop };
        private CurrentGaButtonFunction currentFunction = CurrentGaButtonFunction.Start;
        private void startStopGaButton_Click(object sender, EventArgs e)
        {
            SwitchGaSensitiveControlsVisibility();
            switch (currentFunction)
            {
                case CurrentGaButtonFunction.Start:
                    startStopGaButton.Text = STOP_GA_BUTTON_TEXT;
                    currentFunction = CurrentGaButtonFunction.Stop;
                    geneticAlgorithm = new GeneticAlgorithm<PolygonIndividual, IPolygonGene>
                        (new PolygonAdapter((IFitnessCalculator<PolygonIndividual, IPolygonGene>)fitnessFunctionComboBox.SelectedItem),
                        displayPopulation,
                        (int)populationSizeUpdown.Value);
                    geneticAlgorithm.GenerationComplete += OnGaGenerationComplete;
                    break;
                case CurrentGaButtonFunction.Stop:
                    Reset();
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }       

        private void SwitchGaSensitiveControlsVisibility()
        {
            foreach (var control in gaRunningVisibilitySensitiveControls)
            {
                control.Visible = !control.Visible;
            }
        }        

        private void continueButton_Click(object sender, EventArgs e)
        {
            continueButton.Visible = false;
            geneticAlgorithm.RunGenerations((int)pauseFrequencyUpdown.Value);
        }
        
        #region Termination checking
        private bool Terminate(Population<PolygonIndividual, IPolygonGene> currentGeneration, int generationNumber)
        {
            bool? generationNumberTermination = GenerationNumberTerminate(generationNumber);
            bool? improvementTermination = ImprovementTerminate(currentGeneration);
            if (generationNumberTermination.HasValue && improvementTermination.HasValue)
            {
                if (andRadioButton.Checked) return (bool)generationNumberTermination && (bool)improvementTermination;
                if (orRadioButton.Checked) return (bool)generationNumberTermination || (bool)improvementTermination;
            }

            bool? conditionWithValue = new bool?[] { generationNumberTermination, improvementTermination }
                .FirstOrDefault(x => x.HasValue);
            if (conditionWithValue.HasValue)
            {
                return (bool)conditionWithValue;
            }
            else
            {
                if(!ignoreTerminationConditionsAbsence)
                {
                    MessageBoxManager.OK = "I know :P";
                    MessageBoxManager.Register();
                    var action = MessageBox.Show("No termination conditions activated.", "Warning", MessageBoxButtons.OK);
                    MessageBoxManager.Unregister();
                    ignoreTerminationConditionsAbsence = (action == DialogResult.OK ? true : false);
                }
                return false;
            }            
        }
        private bool ignoreTerminationConditionsAbsence = false;

        private bool? GenerationNumberTerminate(int generationNumber)
        {
            return useGenerationNumberCheckbox.Checked ?
                    generationNumber >= terminationGenerationUpdown.Value : default(bool?);
        }

        private bool? ImprovementTerminate(Population<PolygonIndividual, IPolygonGene> currentGeneration)
        {
            var currentBestIndividual = currentGeneration.OrderByDescending(i => FitnessCalculator.IndividualFitness(i)).First();
            return useFitnessCheckbox.Checked ?
                    currentBestIndividual.Fitness >= (bestInitialFitness * (double)improvementRatioUpdown.Value) : default(bool?);
        }
        #endregion
        #endregion

        #region Genetic Algorithm Controls
        private void importInitialPopulationButton_Click(object sender, EventArgs e)
        {
            if (importPopulationDialog.ShowDialog() == DialogResult.OK && ValidFolderSelected)
                {
                foreach (var file in importPopulationDialog.FileNames)
                {
                    var newIndividual = new PolygonIndividual(PolygonXmlHandler.Load(file));
                    displayPopulation.Add(newIndividual);
                }
                ResolveDisplayedPopulationUniformity();
                UpdatePopulationPictures();
            }
        }

        private bool ValidFolderSelected { get; set; }
        private void importPopulationDialog_FileOk(object sender, CancelEventArgs e)
        {
            //check if user left the predefined directory
            if (importPopulationDialog.FileName.Contains(importPopulationDialog.InitialDirectory))
            {
                ValidFolderSelected = true;
            }
            else
            {
                MessageBox.Show("You have left the pre-set directory. Invalid action.");
                ValidFolderSelected = false;
            }
        }

        /// <summary>
        /// Evaluates number of vertices of display population,
        /// current vertex count value specified in settings and adjusts either of them based on user's decision
        /// </summary>
        /// <remarks>
        /// <list type="bullet">   
        ///     <item><see cref="DialogResult.Yes"/> to remove displayed population</item>
        ///     <item><see cref="DialogResult.No"/> to keep current displayed population and change settings</item>
        /// </list>
        /// </remarks>
        private void ResolveDisplayedVertexCount()
        {
            if (displayPopulation == null || displayPopulation.Empty) return;
            int displayedVertexCount = displayPopulation.First().Polygon.VerticesCount;
            if (displayedVertexCount == Utils.PolygonSettingsAccessor.PolygonsVertices) return;

            MessageBoxManager.Yes = "Remove";
            MessageBoxManager.No = "Change settings";
            MessageBoxManager.Register();
            var action = MessageBox.Show($"Displayed population vertices count ({displayedVertexCount}) don't match the specified vertex count in settings ({Utils.PolygonSettingsAccessor.PolygonsVertices})." 
                + $"{System.Environment.NewLine}Do you want to remove displayed individuals or adjust the settings accordingly?", "Resolve vertex counts", MessageBoxButtons.YesNo);
            MessageBoxManager.Unregister();

            switch (action)
            {
                case DialogResult.Yes:
                    ClearPopulation();
                    break;
                case DialogResult.No:
                    verticesCountUpdown.Value = displayedVertexCount;
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }

            populationSizeUpdown.Value = Math.Max(populationSizeUpdown.Value, displayPopulation.Count);
        }

        /// <summary>
        /// Evaluates all sets of different vertex counts in current display population and ensures that only a single set of the same vertex count remains
        /// </summary>
        private void ResolveDisplayedPopulationUniformity()
        {
            if (displayPopulation == null || displayPopulation.Empty) return;

            var resultUniformPopulation = Population<PolygonIndividual, IPolygonGene>.EmptyPopulation();

            var populationGroupsByCount = displayPopulation
                .GroupBy(individual => individual.Polygon.VerticesCount)
                .Select(group => new { VertexCount = group.Key, Individuals = group.ToList() })
                .OrderBy(group => group.VertexCount);

            if (populationGroupsByCount.Count() > 1)
            {
                var possibleCounts = populationGroupsByCount.
                    Select(group => new IndividualsOfVertexCountPair(group.VertexCount, group.Individuals.Count)).ToList();
                using (var countChooser = new ChooseVerticesCountToImportDialog(possibleCounts))
                {
                    countChooser.ShowDialog();
                    int? chosenCount = countChooser.ChosenVertexCount;
                    if (chosenCount != null)
                    {
                        resultUniformPopulation.AddRange(populationGroupsByCount
                            .FirstOrDefault(group => group.VertexCount == chosenCount)
                            .Individuals);
                    }
                }
            }
            else { resultUniformPopulation.AddRange(populationGroupsByCount.FirstOrDefault().Individuals); }

            displayPopulation = resultUniformPopulation;
            ResolveDisplayedVertexCount();
        }

        private readonly int SavedGenerationsCombobox_DefaultWidth;
        private void savedGenerationsCombobox_DropDown(object sender, EventArgs e)
            => savedGenerationsCombobox.Width = Math.Max(
                (int)LongestFitnessFunctionNameWidth(savedGenerationsCombobox).Width, SavedGenerationsCombobox_DefaultWidth);

        private void savedGenerationsCombobox_DropDownClosed(object sender, EventArgs e)
            => savedGenerationsCombobox.Width = SavedGenerationsCombobox_DefaultWidth;

        private readonly int FitnessFunctionComboBox_DefaultWidth;
        private void fitnessFunctionComboBox_DropDown(object sender, EventArgs e)
            => fitnessFunctionComboBox.Width = Math.Max(
                (int)LongestFitnessFunctionNameWidth(fitnessFunctionComboBox).Width, FitnessFunctionComboBox_DefaultWidth);

        private void fitnessFunctionComboBox_DropDownClosed(object sender, EventArgs e)
            => fitnessFunctionComboBox.Width = FitnessFunctionComboBox_DefaultWidth;

        private void fitnessFunctionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            FitnessCalculator = fitnessFunctionComboBox.SelectedItem as IFitnessCalculator<PolygonIndividual, IPolygonGene>;
        }

        private SizeF LongestFitnessFunctionNameWidth(ComboBox box)
        {
            string longestName = String.Empty;
            foreach (var item in box.Items)
            {
                if (box.GetItemText(item).Length > longestName?.Length)
                { longestName = box.GetItemText(item); }
            }
            SizeF requiredSize = CreateGraphics().MeasureString(longestName, box.Font);
            return requiredSize;
        }

        private void OnFitnessCalculatorChanged(object sender, EventArgs e)
        {
            if (displayPopulation == null) return; 

            foreach (var individual in displayPopulation)
            {
                individual.InvalidateFitness();
                FitnessCalculator.IndividualFitness(individual);
            }
            UpdatePopulationPictures();
        }
        #endregion

        #region Images management
        private void SavePopulationPictures()
        {
            SuspendLayout();

            IEnumerable<PolygonIndividual> populationOrder;
            if (sortPopulationCheckbox.Checked)
            {
                populationOrder = displayPopulation?.
                   OrderByDescending(indiv => FitnessCalculator?.IndividualFitness(indiv));
            }
            else
            {
                populationOrder = displayPopulation;
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

        private void UpdatePopulationPictures()
        {
            picturesLayoutPanel.Controls.Clear();
            SavePopulationPictures();
        }

        private void ClearPopulation()
        {
            displayPopulation.Clear();
            picturesLayoutPanel.Controls.Clear();
        }

        private void clearPopulationButton_Click(object sender, EventArgs e) => ClearPopulation();

        private LabeledPolygonImage BuildLabeledImage(PolygonIndividual buildFrom)
        {
            var result = new LabeledPolygonImage(Polygon.Copy(buildFrom.Polygon));
            result.Description =
                $"{buildFrom.Polygon.Name}{System.Environment.NewLine}Fitness: {FitnessCalculator?.IndividualFitness(buildFrom)}";
            result.BackColor = picturesBackgroundColorDialog.Color;
            result.Width = currentImagesWidth;
            result.Height = currentImagesHeight;
            result.AllowSelectionCheckbox = false;
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
                    image.BackColor = picturesBackgroundColorDialog.Color;
                    image.Invalidate();
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
                image.Width = currentImagesWidth;
                image.Height = currentImagesHeight;
                image.Invalidate();
            }
        }

        private void sortPopulationCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePopulationPictures();
        }

        private void resetColorButton_Click(object sender, EventArgs e)
        {
            picturesBackgroundColorDialog.Color = DefaultPicturesBackground;
            foreach (var c in picturesLayoutPanel.Controls)
            {
                var image = c as LabeledPolygonImage;
                image.BackColor = DefaultPicturesBackground;
                image.Invalidate();
            }
        }
        #endregion

        #region GaParameters
        private void ReadParametersFromSettings()
        {
            populationSizeUpdown.Value = SettingsAccessor.PopulationSize;
            mutationUpdown.Value = (decimal)SettingsAccessor.MutationProbability;
            crossoverUpdown.Value = (decimal)SettingsAccessor.CrossoverProbability;
            maxAngleMutationUpdown.Value = Utils.PolygonSettingsAccessor.AngleMaximumMutation;
            maxDistanceMutationUpdown.Value = (decimal)Utils.PolygonSettingsAccessor.CentroidDistanceMaximumMutation;
            elitismCheckbox.Checked = SettingsAccessor.Elitism;
            steadyStateRateUpdown.Value = (decimal)SettingsAccessor.SteadyStateSurvivalRate;
            verticesCountUpdown.Value = Utils.PolygonSettingsAccessor.PolygonsVertices;
            switch (SettingsAccessor.Selection)
            {
                case SelectionType.Roulette:
                    rouletteRadioButton.Checked = true;
                    break;
                case SelectionType.SteadyState:
                    steadyStateRadioButton.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e) => Utils.PolygonSettingsAccessor.SaveSettings();

        private void resetSettingsButton_Click(object sender, EventArgs e)
        {
            Utils.PolygonSettingsAccessor.ResetToDefaults();
            ReadParametersFromSettings();
        }

        private void populationSizeUpdown_ValueChanged(object sender, EventArgs e) => SettingsAccessor.PopulationSize = (int)populationSizeUpdown.Value;

        private void verticesCountUpdown_ValueChanged(object sender, EventArgs e) => Utils.PolygonSettingsAccessor.PolygonsVertices = (int)verticesCountUpdown.Value;

        private void steadyStateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bool steadyStateSelected = steadyStateRadioButton.Checked;
            steadyStateLabel.Visible = steadyStateSelected;
            steadyStateRateUpdown.Visible = steadyStateSelected;

            if (steadyStateSelected) { SettingsAccessor.Selection = SelectionType.SteadyState; }
        }

        private void rouletteRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rouletteRadioButton.Checked) { SettingsAccessor.Selection = SelectionType.Roulette; }
        }

        private void steadyStateRateUpdown_ValueChanged(object sender, EventArgs e) => SettingsAccessor.SteadyStateSurvivalRate = (double)steadyStateRateUpdown.Value;

        private void elitismCheckbox_CheckedChanged(object sender, EventArgs e) => SettingsAccessor.Elitism = elitismCheckbox.Checked;

        private void maxDistanceMutationUpdown_ValueChanged(object sender, EventArgs e) => Utils.PolygonSettingsAccessor.CentroidDistanceMaximumMutation = (double)maxDistanceMutationUpdown.Value;

        private void maxAngleMutationUpdown_ValueChanged(object sender, EventArgs e)
        {
            int testInt = (int)(Math.Round(maxAngleMutationUpdown.Value));
            Utils.PolygonSettingsAccessor.AngleMaximumMutation = testInt;
        }

        private void crossoverUpdown_ValueChanged(object sender, EventArgs e) => SettingsAccessor.CrossoverProbability = (double)crossoverUpdown.Value;

        private void mutationUpdown_ValueChanged(object sender, EventArgs e) => SettingsAccessor.MutationProbability = (double)mutationUpdown.Value;
        #endregion

        #region GaLogs
        private const int MAXIMUM_LOG_LINES = 500;
        private BindingList<string> logLines = new BindingList<string>();
        private void LogGeneration(NumberedPopulation<PolygonIndividual, IPolygonGene> populationToLog)
        {
            var sortedFitnesses = populationToLog
                .Select(i => FitnessCalculator.IndividualFitness(i))
                .OrderByDescending(fitness => fitness);
            double bestFitness = sortedFitnesses.First();
            double averageFitness = sortedFitnesses.Average();
            string message = $@"Generation {populationToLog.Number}:"
                + $"      Best fitness: {bestFitness}"
                + $"      Average fitness: {averageFitness}";

            logLines.Add(message);
            //   while (logLines.Count > MAXIMUM_LOG_LINES)
            // { logLines.RemoveAt(logLines.Count - 1); }
            logBox.SelectedIndex = logLines.Count - 1;
        }
        #endregion  
              
        #region Miscellaneous
        /// <summary>
        /// Safely close form on ESC press
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns>True to close form, False otherwise</returns>
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

        private void savedGenerationsCombobox_SelectedItemChanged(object sender, EventArgs e)
        {
            displayPopulation = (Population<PolygonIndividual, IPolygonGene>)savedGenerationsCombobox.SelectedItem;
            UpdatePopulationPictures();
        }
    }
}
