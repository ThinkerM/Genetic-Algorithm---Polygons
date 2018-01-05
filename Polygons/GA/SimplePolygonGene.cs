using System;
using System.Drawing;
using Polygons.Utils;

namespace Polygons.GA
{
    /// <summary>
    /// Represents genetic information about one vertex of a polygon
    /// </summary>
    public class SimplePolygonGene : IPolygonGene
    {
        
        public int X { get; private set; }

        
        public int Y { get; private set; }

        
        public double DistanceFromCentroid { get; private set; }
        private Point Centroid { get; }

        
        public Angle AngleRelativeToCentroid { get; private set; }

        
        public void UpdateAngularRepresentation(Point centroid)
        {
            DistanceFromCentroid = GeometryExtensions.Distance(PointRepresentation, centroid);
            AngleRelativeToCentroid = Angle.FromRadians(Math.Atan2(Y, X));
        }

        private void UpdatePointRepresentation()
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
            int maxAngleChange = PolygonSettingsAccessor.AngleMaximumMutation;
            int angleChange = UniqueRandom.Instance.Next(-maxAngleChange, maxAngleChange + 1);
            AngleRelativeToCentroid += angleChange;

            int maxDistanceAbsoluteChange = (int)(PolygonSettingsAccessor.CentroidDistanceMaximumMutation * DistanceFromCentroid);
            int distanceChange = UniqueRandom.Instance.Next(-maxDistanceAbsoluteChange, maxDistanceAbsoluteChange + 1);
            DistanceFromCentroid += distanceChange;

            UpdatePointRepresentation();
        }

        private Point PointRepresentation => new Point(X, Y);

        
        public Point Decode()=> PointRepresentation;
    }
}
