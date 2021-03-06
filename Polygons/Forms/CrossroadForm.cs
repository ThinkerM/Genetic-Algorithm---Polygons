﻿using System;
using System.Windows.Forms;

namespace Polygons.Forms
{
    /// <summary>
    /// Serves as a central form for the genetic algorithm - grants access to every important component of the application.
    /// Only one instance of this form can be run at once.
    /// </summary>
    public partial class CrossroadForm : Form
    {
        #region Singleton
        private static CrossroadForm instance;
        private static readonly object Lock = new object();

        /// <summary>
        /// Access an instance of CrossroadForm
        /// </summary>
        public static CrossroadForm Instance
        {
            get
            {
                lock (Lock)
                {
                    return instance ?? (instance = new CrossroadForm());
                }
            }
        }
        #endregion

        private CrossroadForm()
        {
            InitializeComponent();
            InitializeIcons();
        }

        private void InitializeIcons()
        {
            geneticAlgorithmIcon.AssignIconPicture(Properties.Resources.croppedEvolution);
            shapeCreationIcon.AssignIconPicture(Properties.Resources.singlePolygon);
            populationGenerationIcon.AssignIconPicture(Properties.Resources.multiplePolygons);

            geneticAlgorithmIcon.Text = "Genetic Algorithm";
            populationGenerationIcon.Text = "Population Manager";
            shapeCreationIcon.Text = "Shape Creator";

            geneticAlgorithmIcon.OnGaIconClicked += geneticAlgorithmIcon_Click;
            shapeCreationIcon.OnGaIconClicked += shapeCreationIcon_Click;
            populationGenerationIcon.OnGaIconClicked += populationGenerationIcon_Click;
        }

        private static string PictureFolderPath => Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        private string FilePath(string fileName) => $"{PictureFolderPath}/{fileName}";

        private void shapeCreationIcon_Click(object sender, EventArgs e) => new PolygonCreationForm().Show();

        private void populationGenerationIcon_Click(object sender, EventArgs e) => new PopulationGeneratorForm().Show();

        private void geneticAlgorithmIcon_Click(object sender, EventArgs e) 
            => new GaViewerForm(GA.FitnessCalculators.CalculatorRetriever.GetAllCalculators()).Show();
    }
}
