using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CustomExtensions.Geometry;


namespace Genetic_Algorithm.GA.Polygon_based
{
    /// <summary>
    /// Represents genetic information about one vertex of a polygon
    /// </summary>
    class SimplePolygonGene : IPolygonGene
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public double DistanceFromCentroid { get; private set; }
        private Point Centroid { get; }

        /// <summary>
        /// Represents angle on a circle relative to whole individual's centroid.
        /// 0° to the right, 90° up, 180° left, 270° down
        /// </summary>
        public Angle AngleRelativeToCentroid { get; private set; }

        public void UpdateAngularRepresentation(Point centroid)
        {
            DistanceFromCentroid = GeometryExtensions.Distance(PointRepresentation, centroid);
            AngleRelativeToCentroid = Angle.FromRadians(Math.Atan2(Y, X));
        }

        public void UpdatePointRepresentation()
        {
            var newLocation = GeometryExtensions.GetCoordinates(Centroid, AngleRelativeToCentroid, DistanceFromCentroid);
            X = newLocation.X;
            Y = newLocation.Y;
        }

        public SimplePolygonGene(Point vertexPosition, Point centroid)
        {
            this.X = vertexPosition.X;
            this.Y = vertexPosition.Y;
            Centroid = centroid;
            UpdateAngularRepresentation(centroid);
        }

        public void Mutate()
        {
            int maxAngleChange = SettingsAccessor.AngleMaximumMutation;
            int angleChange = UniqueRandom.Instance.Next(-maxAngleChange, maxAngleChange + 1);
            AngleRelativeToCentroid += angleChange;

            int maxDistanceAbsoluteChange = (int)(SettingsAccessor.CentroidDistanceMaximumMutation * DistanceFromCentroid);
            int distanceChange = UniqueRandom.Instance.Next(-maxDistanceAbsoluteChange, maxDistanceAbsoluteChange + 1);
            DistanceFromCentroid += distanceChange;

            UpdatePointRepresentation();
        }

        private Point PointRepresentation { get { return new Point(X, Y); } }
        public Point Decode()=> PointRepresentation;
    }
}
