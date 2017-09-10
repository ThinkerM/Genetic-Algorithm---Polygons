using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic_Algorithm.Properties;
using System.Windows.Forms;

namespace Genetic_Algorithm.GA
{
    /// <summary>
    /// Defines different methods of selecting individuals to advance into further generations
    /// </summary>
    public enum SelectionType
    {
        /// <summary>
        /// Every individual's fitness proportionally increases its chance to be selected.
        /// </summary>
        /// <remarks>
        /// If an individua's fitness makes up 30% of the whole population's summed scores, the individual has 30% chance to be selected.
        /// </remarks>
        Roulette,
        /// <summary>
        /// Larger group of individuals is selected to survive into next generation.
        /// </summary>
        /// <remarks>
        /// Certain percentage of individuals gets "killed", the remainder continues (and possibly gets mutated) 
        /// and creates new offspring to fill the gap after the killed individuals.
        /// </remarks>
        SteadyState
    };

    /// <summary>
    /// Serves as an intermediary to the Genetic Algorithm's GaSettings.Default
    /// </summary>
    internal static class SettingsAccessor
    {
        public static bool Elitism
        {
            get { return GaSettings.Default.Elitism; }
            set { GaSettings.Default.Elitism = value; }
        }

        public static double CrossoverProbability
        {
            get { return GaSettings.Default.CrossoverProbability; }
            set
            {
                if (value >= 0 && value <= 1)
                { GaSettings.Default.CrossoverProbability = value; }
                else { MessageBox.Show(PROBABILITY_ERROR_MESSAGE); }
            }            
        }

        public static double SteadyStateSurvivalRate
        {
            get { return GaSettings.Default.SteadyStateSurvivalRate; }
            set
            {
                if (value >= 0 && value <= 1)
                { GaSettings.Default.SteadyStateSurvivalRate = value; }
                else { MessageBox.Show(PROBABILITY_ERROR_MESSAGE); }
            }
        }

        public static int PolygonsVertices
        {
            get { return GaSettings.Default.PolygonVertices; }
            set
            {
                if (value >=3)
                {
                    GaSettings.Default.PolygonVertices = value;
                }
                else
                { MessageBox.Show("Polygons must have at least 3 vertices."); }
            }
        }

        public static double MutationProbability
        {
                get { return GaSettings.Default.MutationProbability; }
                set {
                if (value >= 0 && value <= 1)
                { GaSettings.Default.MutationProbability = value; }
                else { MessageBox.Show(PROBABILITY_ERROR_MESSAGE); }
                }
        }

        private static readonly int MIN_POP_SIZE = 2;
        public static int PopulationSize
        {
            get { return GaSettings.Default.PopulationSize; }
            set {
                if (value >= MIN_POP_SIZE)
                {
                    GaSettings.Default.PopulationSize = value;
                }
                else { MessageBox.Show("Population must have at least " + MIN_POP_SIZE.ToString() + " individuals"); }
            }
        }

        public static SelectionType Selection
        {
            get { return (SelectionType)Enum.Parse(typeof(SelectionType), GaSettings.Default.SelectionType, true); }
            set { GaSettings.Default.SelectionType = Enum.GetName(typeof(SelectionType), value); }
        }

        public static double CentroidDistanceMaximumMutation
        {
            get { return GaSettings.Default.CentroidDistanceMaximumMutation; }
            set
            {
                if (value >= 0 && value <= 1)
                { GaSettings.Default.CentroidDistanceMaximumMutation = value; }
                else { MessageBox.Show(PROBABILITY_ERROR_MESSAGE); }
            }
        }

        public static int AngleMaximumMutation
        {
            get { return GaSettings.Default.AngleMutationMaximumVariance; }
            set
            {
                if(value>=0 && value <= 180)
                { GaSettings.Default.AngleMutationMaximumVariance = value; }
                else { MessageBox.Show("Angle mutation must be between 0 and 180."); }
            }
        }

        public static void SaveSettings() => GaSettings.Default.Save();

        private static readonly string PROBABILITY_ERROR_MESSAGE = "Invalid value, probability must be between 0 and 1";

        public static void ResetToDefaults()
        {
            Elitism = Settings.Default.Elitism;
            MutationProbability = Settings.Default.MutationProbability;
            CrossoverProbability = Settings.Default.CrossoverProbability;
            PolygonsVertices = Settings.Default.PolygonVertices;
            PopulationSize  = Settings.Default.PopulationSize;
            SteadyStateSurvivalRate = Settings.Default.SteadyStateSurvivalRate;
            Selection = (SelectionType)Enum.Parse(typeof(SelectionType), Settings.Default.SelectionType, true);
            AngleMaximumMutation = Settings.Default.AngleMutationMaximumVariance;
            CentroidDistanceMaximumMutation = Settings.Default.CentroidDistanceMaximumMutation;
        }
    }
}
