using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Polygons
{
    
    public class Polygon : IPolygon
    {
        #region Properties

        
        public Color OutlineColor { get; private set; }

        /// <summary>
        /// Name assigned to the polygon
        /// </summary>
        public string Name { get; private set; }

        
        public List<Point> Vertices { get; private set; } = new List<Point>();

        
        public int VerticesCount => Vertices.Count;

        private Point? center;
        
        public Point Center
        {
            get
            {
                if (Vertices.Any())
                {
                    UpdateCenter();
                    return (Point)center;
                }
                return Point.Empty;
            }
        }

        private Point? centroid;
        
        public Point Centroid
        {
            get
            {
                if (Vertices.Any())
                {
                    UpdateCentroid();
                    return (Point)centroid;
                }
                return Point.Empty;
            }
        }
        #endregion

        #region Manipulation
        private void UpdateCentroid()
        {
            int xMean = (int)Math.Round(Vertices.Select(v => v.X).Average());
            int yMean = (int)Math.Round(Vertices.Select(v => v.Y).Average());
            centroid = new Point(xMean, yMean);
        }

        private void UpdateCenter()
        {
            Point upperLeftCorner = UpperLeftCorner();
            center = new Point(
                upperLeftCorner.X + XSpan() / 2,
                upperLeftCorner.Y + YSpan() / 2);
        }

        private Point UpperLeftCorner()
        {
            int lowestX = Vertices.OrderBy(v => v.X).First().X;
            int lowestY = Vertices.OrderBy(v => v.Y).First().Y;
            return new Point(lowestX, lowestY);
        }

        private int XSpan()
        {
            var orderedVertices = Vertices.OrderBy(v => v.X);
            return orderedVertices.Last().X - orderedVertices.First().X;
        }

        private int YSpan()
        {
            var orderedVertices = Vertices.OrderBy(v => v.Y);
            return orderedVertices.Last().Y - orderedVertices.First().Y;
        }

        /// <summary>
        /// Moves vertices of the polygon so that the specified point becomes the new center.
        /// </summary>
        /// <param name="newCenter">Location to become the new center after the shift</param>
        public void ShiftCenter(Point newCenter) => Vertices = ShiftedToCenter(newCenter);

        /// <summary>
        /// Representation of this polygon's vertices adjusted to a hypothetical center
        /// </summary>
        /// <param name="hypotheticalCenter"></param>
        /// <returns>List of polygon's vertices adjusted to center</returns>
        public List<Point> ShiftedToCenter(Point hypotheticalCenter)
        {
            int xShift = hypotheticalCenter.X - Center.X;
            int yShift = hypotheticalCenter.Y - Center.Y;

            return ShiftedVertices(this.Vertices, xShift, yShift);
        }

        /// <summary>
        /// Moves all of polygon's vertices so that they match a new centroid position
        /// </summary>
        /// <param name="newCentroid"></param>
        public void ShiftCentroid(Point newCentroid) => Vertices = ShiftedToCentroid(newCentroid);

        /// <summary>
        /// Representation of this polygon's vertices adjusted to a hypothetical centroid
        /// </summary>
        /// <param name="hypotheticalCentroid"></param>
        /// <returns>List of polygon's vertices adjusted to centroid</returns>
        private List<Point> ShiftedToCentroid(Point hypotheticalCentroid)
        {
            int xShift = hypotheticalCentroid.X - Centroid.X;
            int yShift = hypotheticalCentroid.Y - Centroid.Y;

            return ShiftedVertices(this.Vertices, xShift, yShift);
        }

        /// <summary>
        /// Change the coordinates of every vertex withotu distoring their relative positions.
        /// Left-most point of the polygon will share its X coordinate with the imaginary upper-left corner.
        /// Top-most point of the polygon will share its Y coordinate with the imaginary upper-left corner.
        /// </summary>
        /// <param name="shiftTo">Imaginary upper-left corner to shift to</param>
        public void ShiftUpperLeftCorner(Point shiftTo) 
            => Vertices = ShiftedUpperLeftCorner(shiftTo);

        /// <summary>
        /// Change the coordinates of every vertex without distorting their relative positions.
        /// </summary>
        /// <param name="dX">Shift on the horizontal axis</param>
        /// <param name="dY">Shift on the vertical axis</param>
        public void ShiftVertices(int dX, int dY) 
            => Vertices = ShiftedVertices(Vertices, dX, dY);

        private List<Point> ShiftedUpperLeftCorner(Point shiftTo) 
            => ShiftedVertices(this.Vertices, shiftTo);

        private List<Point> ShiftedUpperLeftCorner(int dX, int dY) 
            => ShiftedVertices(this.Vertices, dX, dY);

        /// <summary>
        /// Moves vertices to a new location (specified by amount of movement on X and Y axes.
        /// </summary>
        /// <param name="vertices">Vertices to be shifted</param>
        /// <param name="dX">Amount of movement on X axis</param>
        /// <param name="dY">Amount of movement on Y axis</param>
        /// <returns>Vertices adjusted to a new location</returns>
        public static List<Point> ShiftedVertices(IEnumerable<Point> vertices, int dX, int dY) 
            => vertices.Select(v => new Point(v.X + dX, v.Y + dY)).ToList();

        /// <summary>
        /// Moves vertices to a new location (specified by upper left corner of the whole shape).
        /// </summary>
        /// <param name="vertices">Vertices to be shifted</param>
        /// <param name="shiftToCorner">Upper left corner of the desired output</param>
        /// <returns>Vertices adjusted to a new location</returns>
        private static List<Point> ShiftedVertices(List<Point> vertices, Point shiftToCorner)
        {
            int lowestX = vertices.OrderBy(p => p.X).First().X;
            int xShift = shiftToCorner.X - lowestX;
            int lowestY = vertices.OrderBy(p => p.Y).First().Y;
            int yShift = shiftToCorner.Y - lowestY;

            return ShiftedVertices(vertices, xShift, yShift);
        }

        /// <summary>
        /// Determine a proper resize value to fit polygon into a container of specified size
        /// </summary>
        /// <param name="normalizeToX">Horizontal size of container</param>
        /// <param name="normalizeToY">Vertical size of container</param>
        /// <returns></returns>
        public double GetScalingFactor(int normalizeToX, int normalizeToY)
        {
            double xNorm = (double)normalizeToX / XSpan();
            double yNorm = (double)normalizeToY / YSpan();

            return (Math.Min(xNorm, yNorm));
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Construct polygon from a list of vertices, optionally specify its color and name
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="outlineColor"></param>
        /// <param name="name"></param>
        public Polygon(List<Point> vertices, Color outlineColor = default(Color), string name = default(string))
        {
            this.Vertices = vertices;
            this.OutlineColor = outlineColor;
            Name = name;
        }

        /// <summary>
        /// Create an identical copy of polygon
        /// </summary>
        /// <param name="original">Template polygon</param>
        /// <returns>Identical copy of original</returns>
        public static Polygon Copy(Polygon original)
        {
            return new Polygon(
                original.Vertices,
                original.OutlineColor,
                original.Name);
        }

        /// <summary>
        /// Construct polygon according to a template, adjust relative positions of vertices by a scaling factor
        /// </summary>
        /// <param name="original">Template polygon</param>
        /// <param name="resizeFactor"></param>
        public Polygon(Polygon original, double resizeFactor)
        {
            foreach (var originalPoint in original.Vertices)
            {
                Vertices.Add(new Point((int)(originalPoint.X * resizeFactor), (int)(originalPoint.Y * resizeFactor)));
            }
            OutlineColor = original.OutlineColor;
            Name = original.Name;
        }
        #endregion
    }
}
