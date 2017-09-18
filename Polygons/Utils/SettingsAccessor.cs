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
        public static int PolygonsVertices
        {
            get { return Default.PolygonVertices; }
            set
            {
                if (value >=3)
                {
                    Default.PolygonVertices = value;
                }
                else
                { MessageBox.Show("Polygons must have at least 3 vertices."); }
            }
        }

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

        public static void SaveSettings() => Default.Save();

        private static readonly string PROBABILITY_ERROR_MESSAGE = "Invalid value, probability must be between 0 and 1";

        public static void ResetToDefaults()
        {
            PolygonsVertices = Default.PolygonVertices;
            AngleMaximumMutation = Default.MaximumAngleMutation;
            CentroidDistanceMaximumMutation = Default.MaximumDistanceMutation;
            Genetic_Algorithm.Utils.SettingsAccessor.ResetToDefaults();
        }
    }
}
