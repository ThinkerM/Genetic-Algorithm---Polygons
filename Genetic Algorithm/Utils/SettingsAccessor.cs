using System;
using Genetic_Algorithm.Properties;
using System.Windows.Forms;

namespace Genetic_Algorithm.Utils
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
    public static class SettingsAccessor
    {
        /// <summary>
        /// Indicates whether top individual of population should always be guaranteed to continue without changes
        /// </summary>
        public static bool Elitism
        {
            get { return GaSettings.Default.Elitism; }
            set { GaSettings.Default.Elitism = value; }
        }

        /// <summary>
        /// Chance that two individuals will generate a meiotic offspring instead of continuing unchanged
        /// </summary>
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

        /// <summary>
        /// Percentage of individuals to automatically survive each generation
        /// </summary>
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

        /// <summary>
        /// Chance that a single gene will mutate
        /// </summary>
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
        /// <summary>
        /// Number of individuals per generation
        /// </summary>
        public static int PopulationSize
        {
            get { return GaSettings.Default.PopulationSize; }
            set {
                if (value >= MIN_POP_SIZE)
                {
                    GaSettings.Default.PopulationSize = value;
                }
                else { MessageBox.Show($"Population must have at least {MIN_POP_SIZE} individuals"); }
            }
        }

        /// <summary>
        /// <see cref="SelectionType"/> currently used
        /// </summary>
        public static SelectionType Selection
        {
            get { return (SelectionType)Enum.Parse(typeof(SelectionType), GaSettings.Default.SelectionType, true); }
            set { GaSettings.Default.SelectionType = Enum.GetName(typeof(SelectionType), value); }
        }

        /// <summary>
        /// Write current settings state to permanent settings file
        /// </summary>
        public static void SaveSettings() => GaSettings.Default.Save();

        private static readonly string PROBABILITY_ERROR_MESSAGE = "Invalid value, probability must be between 0 and 1";

        /// <summary>
        /// Retrieve GA parameters from a backup settings file
        /// </summary>
        public static void ResetToDefaults()
        {
            Elitism = Settings.Default.Elitism;
            MutationProbability = Settings.Default.MutationProbability;
            CrossoverProbability = Settings.Default.CrossoverProbability;
            PopulationSize  = Settings.Default.PopulationSize;
            SteadyStateSurvivalRate = Settings.Default.SteadyStateSurvivalRate;
            Selection = (SelectionType)Enum.Parse(typeof(SelectionType), Settings.Default.SelectionType, true);
        }
    }
}
