using System.Collections.Generic;
using System.Drawing;

namespace Polygons
{
    /// <summary>
    /// Represents a shape with a variable number of vertices, specific color and an optional name
    /// </summary>
    public interface IPolygon
    {
        /// <summary>
        /// Number of vertices
        /// </summary>
        int VerticesCount { get; }

        /// <summary>
        /// Color of the lines connecting vertices
        /// </summary>
        Color OutlineColor { get; }

        /// <summary>
        /// List representation of the polygon's vertices
        /// </summary>
        List<Point> Vertices { get; }

        /// <summary>
        /// Point which is the average of the polygon's left/right-most and top/lower-most vertices
        /// </summary>
        Point Center { get; }

        /// <summary>
        /// Point which is the average of every vertex's coordinates
        /// </summary>
        Point Centroid { get; }
    }
}
