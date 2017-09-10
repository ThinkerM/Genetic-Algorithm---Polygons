using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomExtensions.Math;

namespace Polygons
{
    /// <summary>
    /// Represents a shape with a variable number of vertices, specific color and an optional name
    /// </summary>
    public class Polygon : IPolygon
    {
        #region Properties
        private List<Point> vertices = new List<Point>();

        /// <summary>
        /// Color of the connecting lines and points of the polygon
        /// </summary>
        public Color OutlineColor { get; set; }

        /// <summary>
        /// Name assigned to the polygon
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// All of the polygon's vertices represented as Points
        /// </summary>
        public List<Point> Vertices { get { return vertices; } }

        /// <summary>
        /// Number of vertices
        /// </summary>
        public int VerticesCount { get { return vertices.Count; } }

        private Point? center;
        /// <summary>
        /// Point which is the average of the polygon's left/right-most and top/lower-most vertices
        /// </summary>
        public Point Center
        {
            get
            {
                if (vertices.Any())
                {
                    if (center == null)
                    { UpdateCenter(); }
                    return (Point)center;
                }
                return new Point(-1, -1);
            }
        }

        private Point? centroid;
        /// <summary>
        /// Point which is the average of every vertex's coordinates
        /// </summary>
        public Point Centroid
        {
            get
            {
                if (vertices.Any())
                {
                    UpdateCentroid();
                    return (Point)centroid;
                }
                return new Point(-1, -1);
            }
        }

        private void UpdateCentroid()
        {
            int xMean = (int)Math.Round(vertices.Select(v => v.X).Average());
            int yMean = (int)Math.Round(vertices.Select(v => v.Y).Average());
            centroid = new Point(xMean, yMean);
        }

        #endregion

        #region Manipulation
        private void UpdateCenter()
        {
            Point upperLeftCorner = UpperLeftCorner();
            center = new Point(
                upperLeftCorner.X + xSpan() / 2,
                upperLeftCorner.Y + ySpan() / 2);
        }

        private Point UpperLeftCorner()
        {
            int lowestX = vertices.OrderBy(v => v.X).First().X;
            int lowestY = vertices.OrderBy(v => v.Y).First().Y;
            return new Point(lowestX, lowestY);
        }

        private int xSpan()
        {
            var orderedVertices = vertices.OrderBy(v => v.X);
            return orderedVertices.Last().X - orderedVertices.First().X;
        }

        private int ySpan()
        {
            var orderedVertices = vertices.OrderBy(v => v.Y);
            return orderedVertices.Last().Y - orderedVertices.First().Y;
        }

        /// <summary>
        /// Moves vertices of the polygon so that the specified point becomes the new center.
        /// </summary>
        /// <param name="newCenter">Location to become the new center after the shift</param>
        public void ShiftCenter(Point newCenter) => vertices = ShiftedToCenter(newCenter);

        /// <summary>
        /// Representation of this polygon's vertices adjusted to a hypothetical center
        /// </summary>
        /// <param name="hypotheticalCenter"></param>
        /// <returns>List of polygon's vertices adjusted to center</returns>
        public List<Point> ShiftedToCenter(Point hypotheticalCenter)
        {
            int xShift = hypotheticalCenter.X - Center.X;
            int yShift = hypotheticalCenter.Y - Center.Y;

            return ShiftedVertices(this.vertices, xShift, yShift);
        }

        /// <summary>
        /// Moves all of polygon's vertices so that they match a new centroid position
        /// </summary>
        /// <param name="newCentroid"></param>
        public void ShiftCentroid(Point newCentroid) => vertices = ShiftedToCentroid(newCentroid);

        /// <summary>
        /// Representation of this polygon's vertices adjusted to a hypothetical centroid
        /// </summary>
        /// <param name="hypotheticalCentroid"></param>
        /// <returns>List of polygon's vertices adjusted to centroid</returns>
        public List<Point> ShiftedToCentroid(Point hypotheticalCentroid)
        {
            int xShift = hypotheticalCentroid.X - Centroid.X;
            int yShift = hypotheticalCentroid.Y - Centroid.Y;

            return ShiftedVertices(this.vertices, xShift, yShift);
        }

        /// <summary>
        /// Change the coordinates of every vertex withotu distoring their relative positions.
        /// Left-most point of the polygon will share its X coordinate with the imaginary upper-left corner.
        /// Top-most point of the polygon will share its Y coordinate with the imaginary upper-left corner.
        /// </summary>
        /// <param name="shiftTo">Imaginary upper-left corner to shift to</param>
        public void ShiftUpperLeftCorner(Point shiftTo) => vertices = ShiftedUpperLeftCorner(shiftTo);

        /// <summary>
        /// Change the coordinates of every vertex without distorting their relative positions.
        /// </summary>
        /// <param name="dX">Shift on the horizontal axis</param>
        /// <param name="dY">Shift on the vertical axis</param>
        public void ShiftVertices(int dX, int dY) => vertices = ShiftedVertices(vertices, dX, dY);

        private List<Point> ShiftedUpperLeftCorner(Point shiftTo) => ShiftedVertices(this.vertices, shiftTo);

        private List<Point> ShiftedUpperLeftCorner(int dX, int dY) => ShiftedVertices(this.vertices, dX, dY);

        /// <summary>
        /// Moves vertices to a new location (specified by amount of movement on X and Y axes.
        /// </summary>
        /// <param name="vertices">Vertices to be shifted</param>
        /// <param name="dX">Amount of movement on X axis</param>
        /// <param name="dY">Amount of movement on Y axis</param>
        /// <returns>Vertices adjusted to a new location</returns>
        public static List<Point> ShiftedVertices(List<Point> vertices, int dX, int dY)
        {
            List<Point> result = new List<Point>();
            foreach (var v in vertices)
            {
                result.Add(new Point(v.X + dX, v.Y + dY));
            }
            return result;
        }

        /// <summary>
        /// Moves vertices to a new location (specified by upper left corner of the whole shape).
        /// </summary>
        /// <param name="vertices">Vertices to be shifted</param>
        /// <param name="shiftToCorner">Upper left corner of the desired output</param>
        /// <returns>Vertices adjusted to a new location</returns>
        public static List<Point> ShiftedVertices(List<Point> vertices, Point shiftToCorner)
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
            double xNorm = (double)normalizeToX / xSpan();
            double yNorm = (double)normalizeToY / ySpan();

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
            this.vertices = vertices;
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
                vertices.Add(new Point((int)(originalPoint.X * resizeFactor), (int)(originalPoint.Y * resizeFactor)));
            }
            OutlineColor = original.OutlineColor;
            Name = original.Name;
        }
        #endregion
    }
}
