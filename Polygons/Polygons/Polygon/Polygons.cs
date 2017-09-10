using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Randomization;
using CustomExtensions;
using CustomExtensions.Geometry;

namespace Polygons
{
    /// <summary>
    /// Provides methods for static generation of polygons
    /// </summary>
    public class Polygons
    {
        private static readonly int MAX_VERTICES = 30;
        private static readonly int MAX_DISTANCE_CENTER = 300;

        /// <summary>
        /// Generate a random polygon with a random number of vertices
        /// </summary>
        /// <returns>Random polygon</returns>
        public static Polygon RandomPolygon()
        {
            return RandomPolygon(UniqueRandom.Instance.Next(3, MAX_VERTICES));
        }

        /// <summary>
        /// Generate a random polygon with the specified number of vertices
        /// </summary>
        /// <param name="verticesCount">Number of vertices of the result polygon</param>
        /// <returns>Random polygon with 'n' vertices</returns>
        public static Polygon RandomPolygon(int verticesCount)
        {
            if (verticesCount < 3) { throw new Exception("Polygon must contain at least 3 vertices to be formed."); }

            //randomly generate unique angles on a circle
            List<int> angles = new List<int>();
            for (int i = 0; i < verticesCount; i++)
            {
                bool newAngleFound = false;
                while (!newAngleFound)
                {
                    int randomAngle = UniqueRandom.Instance.Next(360);
                    if (!angles.Contains(randomAngle))
                    {
                        angles.Add(randomAngle);
                        newAngleFound = true;
                    }
                }
            }
            angles.Sort();

            //randomly generate distances from centre
            List<int> distances = new List<int>();
            for (int i = 0; i < verticesCount; i++)
            {
                distances.Add(UniqueRandom.Instance.Next(MAX_DISTANCE_CENTER));
            }

            //combine angles and distances
            List<Point> vertices = new List<Point>();
            for (int i = 0; i < verticesCount; i++)
            {
                vertices.Add(
                    new Point(
                        (int)(distances[i] * Math.Cos(GeometryExtensions.DegreesToRadians(angles[i]))), //X coordinate
                        (int)(distances[i] * Math.Sin(GeometryExtensions.DegreesToRadians(angles[i]))))); //Y coordinate
            }

            var result = new Polygon(vertices, RandomColors.RandomColor(), GenerateName(vertices.Count));
            result.ShiftUpperLeftCorner(new Point(0, 0));
            return result;
        }

        private static string GenerateName(int vertices)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{vertices.ToString()}VTX_");
            sb.Append(RandomCharsAndStrings.RandomAlphanumericString(8));
            return sb.ToString();
        }
    }
}
