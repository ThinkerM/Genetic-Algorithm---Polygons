using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions.Geometry;
using Genetic_Algorithm.GA.Generics;

namespace Genetic_Algorithm.GA.Polygon_based
{
    /// <summary>
    /// Gene which can be included in a <see cref="PolygonIndividual"/>'s genome
    /// </summary>
    interface IPolygonGene : IGene<System.Drawing.Point>
    {
        /// <summary>
        /// X coordinate of the gene's encoded point
        /// </summary>
        int X { get;}

        /// <summary>
        /// Y coordinate of the gene's encoded point
        /// </summary>
        int Y { get;  }

        /// <summary>
        /// Distance between the point encoded by the gene and the whole individual's (polygon's) centroid
        /// </summary>
        double DistanceFromCentroid { get; }

        /// <summary>
        /// Represents angle on a circle relative to whole individual's centroid.
        /// 0° to the right, 90° up, 180° left, 270° down
        /// </summary>
        Angle AngleRelativeToCentroid { get; }

        /// <summary>
        /// Rebuild DistanceFromCentroid and AngleRelativeToCentroid properties based on a new centroid point and current X,Y coordinates
        /// </summary>
        /// <param name="centroid">New centroid to update according to</param>
        void UpdateAngularRepresentation(System.Drawing.Point centroid);
    }
}
