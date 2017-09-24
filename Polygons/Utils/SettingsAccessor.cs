using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polygons.Properties.PolygonGaSettings;
using System.Windows.Forms;

namespace Polygons.Utils
{
    /// <summary>
    /// Serves as an intermediary to the Genetic Algorithm's GaSettings.Default
    /// </summary>
    internal static class PolygonSettingsAccessor 
    {
        /// <summary>
        /// Defines how many vertices every <see cref="Polygons.GA.PolygonIndividual"/> will have.
        /// Must be at least 3.
        /// </summary>
        public static int PolygonsVertices
        {
            get { return Default.PolygonVertices; }
            set
            {
                if (value >= 3)
                {
                    Default.PolygonVertices = value;
                }
                else
                { MessageBox.Show("Polygons must have at least 3 vertices."); }
            }
        }

        /// <summary>
        /// Defines how large a relative change can occur in a gene.
        /// Must be between 0 and 1.
        /// </summary>
        public static double CentroidDistanceMaximumMutation
        {
            get { return Default.MaximumDistanceMutation; }
            set
            {
                if (value >= 0 && value <= 1)
                { Default.MaximumDistanceMutation = value; }
                else { MessageBox.Show(PROBABILITY_ERROR_MESSAGE); }
            }
        }

        /// <summary>
        /// Defines how large a mutation (in angles) can occur in each gene.
        /// Must be between 0 and 180.
        /// </summary>
        public static int AngleMaximumMutation
        {
            get { return Default.MaximumAngleMutation; }
            set
            {
                if(value>=0 && value <= 180)
                { Default.MaximumAngleMutation = value; }
                else { MessageBox.Show("Angle mutation must be between 0 and 180."); }
            }
        }

        /// <summary>
        /// Write current Polygon and generic GA settings to permanent settings file
        /// </summary>
        public static void SaveSettings()
        {
            Default.Save();
            Genetic_Algorithm.Utils.SettingsAccessor.SaveSettings();
        }

        private static readonly string PROBABILITY_ERROR_MESSAGE = "Invalid value, probability must be between 0 and 1";

        /// <summary>
        /// Retrievve Polygons GA parameters from a backup settings file
        /// </summary>
        public static void ResetToDefaults()
        {
            PolygonsVertices = Default.PolygonVertices;
            AngleMaximumMutation = Default.MaximumAngleMutation;
            CentroidDistanceMaximumMutation = Default.MaximumDistanceMutation;
            Genetic_Algorithm.Utils.SettingsAccessor.ResetToDefaults();
        }
    }
}
