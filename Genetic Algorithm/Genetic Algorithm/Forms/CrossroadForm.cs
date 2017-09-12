using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Genetic_Algorithm.GA;

namespace Genetic_Algorithm.Forms
{
    /// <summary>
    /// Serves as a central form for the genetic algorithm - grants access to every important component of the application.
    /// Only one instance of this form can be run at once.
    /// </summary>
    public partial class CrossroadForm : Form
    {
        #region Singleton
        private static CrossroadForm instance;
        private static readonly object padlock = new object();

        /// <summary>
        /// Access an instance of CrossroadForm
        /// </summary>
        public static CrossroadForm Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) { instance = new CrossroadForm(); }
                    return instance; 
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
            geneticAlgorithmIcon.AssignIconPicture(Properties.Resources.evolution);
            shapeCreationIcon.AssignIconPicture(Properties.Resources.singlePolygon);
            populationGenerationIcon.AssignIconPicture(Properties.Resources.multiplePolygons);

            geneticAlgorithmIcon.Text = "Genetic Algorithm";
            populationGenerationIcon.Text = "Population Manager";
            shapeCreationIcon.Text = "Shape Creator";

            geneticAlgorithmIcon.OnGaIconClicked += geneticAlgorithmIcon_Click;
            shapeCreationIcon.OnGaIconClicked += shapeCreationIcon_Click;
            populationGenerationIcon.OnGaIconClicked += populationGenerationIcon_Click;
        }
        Stream GetStream(string name, Assembly assembly) 
            => assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{name}".Replace(' ','_'));

        string AssemblyResourceString(string fileName, Assembly assembly)
            => $"{assembly.GetName().Name}.{fileName}".Replace(' ', '_').Replace('/', '.').Replace('\\', '.');
        string PictureFolderPath => Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        string PilePath(string fileName) => $"{PictureFolderPath}/{fileName}";

        private void shapeCreationIcon_Click(object sender, EventArgs e) => new Polygons.Forms.PolygonCreationForm().Show();

        private void populationGenerationIcon_Click(object sender, EventArgs e) => new PopulationGeneratorForm().Show();

        private void geneticAlgorithmIcon_Click(object sender, EventArgs e) 
            => new GaViewerForm(GA.Polygon_based.FitnessCalculators.CalculatorRetriever.GetAllCalculators()).Show();
    }
}
