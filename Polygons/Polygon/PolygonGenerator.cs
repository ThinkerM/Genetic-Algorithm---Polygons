using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Polygons.Utils;
using ThinkerExtensions.Geometry;

namespace Polygons
{
    /// <summary>
    /// Provides static methods for generation of polygons
    /// </summary>
    public static class PolygonGenerator
    {
        private const int MAX_VERTICES = 30;
        private const int MAX_DISTANCE_CENTER = 300;

        /// <summary>
        /// Generate a random polygon with a random number of vertices
        /// </summary>
        /// <returns>Random polygon</returns>
        public static Polygon RandomPolygon() 
            => RandomPolygon(UniqueRandom.Instance.Next(3, MAX_VERTICES));

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
                        (int)(distances[i] * Math.Cos(angles[i].ToRadians())), //X coordinate
                        (int)(distances[i] * Math.Sin(angles[i].ToRadians())))); //Y coordinate
            }

            var result = new Polygon(vertices,RandomColor(), GenerateName(vertices.Count));
            result.ShiftUpperLeftCorner(new Point(0, 0));
            return result;
        }

        private static Color RandomColor()
        {
            int a = UniqueRandom.Instance.Next(256);
            int r = UniqueRandom.Instance.Next(256);
            int g = UniqueRandom.Instance.Next(256);
            int b = UniqueRandom.Instance.Next(256);
            return Color.FromArgb(a, r, g, b);
        }

        private static string GenerateName(int vertices)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{vertices}VTX_");
            sb.Append(RandomAlphanumericString(8));
            return sb.ToString();
        }

        private static string RandomAlphanumericString(int length)
        {
            var result = new StringBuilder(length);
            const string Alphanumerics = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < length; i++)
            {
                result.Append(Alphanumerics[UniqueRandom.Instance.Next(Alphanumerics.Length)]);
            }
            return result.ToString();
        }
    }
}
