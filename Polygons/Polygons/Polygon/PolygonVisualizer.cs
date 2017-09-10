﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Polygons;

namespace Polygons
{
    /// <summary>
    /// Provides static methods for drawing polygons
    /// </summary>
    public static class PolygonVisualizer
    {
        /// <summary>
        /// Draw a complete polygon
        /// </summary>
        /// <param name="p">Polygon to draw</param>
        /// <param name="g">Graphics object to be used to draw the polygon</param>
        public static void Draw(Polygon p, Graphics g)
        {
            using (Brush vertexBrush = new SolidBrush(p.OutlineColor))
            {
                foreach (var point in p.Vertices)
                {
                    g.FillEllipse(vertexBrush, point.X - 5, point.Y - 5, 10, 10);
                }
                if (p.VerticesCount > 1)
                {
                    using (Pen outlinePen = new Pen(p.OutlineColor, 3))
                    { g.DrawPolygon(outlinePen, p.Vertices.ToArray()); }
                }
            }
        }

        /// <summary>
        /// Draw polygon without connection between the first and last vertex of the polygon
        /// </summary>
        /// <param name="p">Polygon to incompletely draw</param>
        /// <param name="g">Graphics object to be used to draw the polygon</param>
        public static void DrawIncomplete(Polygon p, Graphics g)
        {
            using (Brush filler = new SolidBrush(p.OutlineColor))
            {
                foreach (var point in p.Vertices)
                {
                    g.FillEllipse(filler, point.X - 5, point.Y - 5, 10, 10);
                }
                if (p.VerticesCount > 1)
                {
                    using (Pen outlinePen = new Pen(p.OutlineColor, 3))
                    { g.DrawLines(outlinePen, p.Vertices.ToArray()); }
                }
            }
        }

        /// <summary>
        /// Draw a mark in the position of the polygon's center
        /// </summary>
        /// <param name="p">Polygon whose center to draw</param>
        /// <param name="g">Graphics object to be used to mark the center</param>
        public static void DrawCenter(Polygon p, Graphics g)
        {
            using (Brush b = new SolidBrush(p.OutlineColor))
            {
                g.DrawString("x", SystemFonts.DefaultFont, b,
                new Rectangle(p.Center.X - 5, p.Center.Y - 5, 10, 10));
            }
        }

        /// <summary>
        /// Draw a mark in the position of the polygon's centroid
        /// </summary>
        /// <param name="p">Polygon whose center to draw</param>
        /// <param name="g">Graphics object to be used to mark the center</param>
        public static void DrawCentroid(Polygon p, Graphics g)
        {
            using (Brush b = new SolidBrush(p.OutlineColor))
            {
                g.DrawString("x", SystemFonts.DefaultFont, b,
                new Rectangle(p.Centroid.X - 5, p.Centroid.Y - 5, 10, 10));
            }
        }

        /// <summary>
        /// Create a new polygon with the properties of its template, vertices coordinates scaled to fit a PictureBox
        /// </summary>
        /// <param name="p">Polygon to normalize</param>
        /// <param name="normalizeTo">Picturebox whose bounds should be used for normalization calculations</param>
        /// <returns></returns>
        public static Polygon PolygonNormalizedToBox(Polygon p, PictureBox normalizeTo)
            => new Polygon(p, p.GetScalingFactor(normalizeTo.Width, normalizeTo.Height));

        /// <summary>
        /// Create a new polygon with the properties of its template, vertices coordinates scaled to fit a container of specified dimensions
        /// </summary>
        /// <param name="p">Polygon to normalize</param>
        /// <param name="width">Width of the container</param>
        /// <param name="height">Height of the container</param>
        /// <returns></returns>
        public static Polygon PolygonNormalizedToBox(Polygon p, int width, int height)
            => new Polygon(p, p.GetScalingFactor(width, height));

    }
}