using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Polygons
{
    /// <summary>
    /// Provides static methods for loading and saving Polygons from/to .xml files
    /// </summary>
    public static class PolygonXmlHandler
    {
        /// <summary>
        /// Checks if a file of same name already exists in specified location and removes any readonly accessors
        /// </summary>
        /// <param name="path">File path including the name of the potential file</param>
        private static void EnableFileForWriting(string path)
        {
            FileInfo fInfo = new FileInfo(path);
            if (fInfo.Exists) { fInfo.IsReadOnly = false; }
        }
        
        /// <summary>
        /// Saves polygon to an XML file to a specified folder and filename.
        /// </summary>
        /// <param name="p">Polygon to be saved</param>
        /// <param name="path">File path including the name of the output file</param>
        public static void Save(this Polygon p, string path)
        {
            EnableFileForWriting(path);
            using (StreamWriter stream = new StreamWriter(path))
            {
                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(stream, writerSettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Polygon");

                    writer.WriteElementString(NAME, p.Name);
                    writer.WriteElementString(COLOR, p.OutlineColor.ToArgb().ToString());
                    foreach (var vertex in p.ShiftedToCenter(new Point(0, 0)))
                    {
                        writer.WriteStartElement(VERTEX);
                        writer.WriteElementString("X", vertex.X.ToString());
                        writer.WriteElementString("Y", vertex.Y.ToString());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    writer.Close();
                }
                //set created file as readonly
                new FileInfo(path).Attributes = FileAttributes.ReadOnly;
            }
        }

        /// <summary>
        /// Save <see cref="Polygon"/> as .xml to the application's default shapes saving folder
        /// </summary>
        /// <param name="p">Polygon to save</param>
        public static void SaveToDefaultFolder(this Polygon p)
        {
            string path = Utils.PolygonPaths.SaveXmlPath(p.Name);
            Save(p, path);
        }

        /// <summary>
        /// Load a <see cref="Polygon"/> from an XML file
        /// </summary>
        /// <param name="uriPath">Path to desired XML file</param>
        /// <returns>The object created from the XML file</returns>
        public static Polygon Load(string uriPath)
        {
            try
            {
                XElement main = XElement.Load(uriPath);

                string name = main.Descendants(NAME).First().Value;
                Color outlineColor = Color.FromArgb(Int32.Parse(main.Descendants(COLOR).First().Value));
                var vertexElements = main.Elements(VERTEX).ToList();
                List<Point> vertices = new List<Point>();
                foreach (var element in vertexElements)
                {
                    int x = int.Parse(element.Element("X").Value);
                    int y = int.Parse(element.Element("Y").Value);
                    vertices.Add(new Point(x, y));
                }
                return new Polygon(vertices, outlineColor, name);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Oops, looks like something is wrong with the file!", ex);
            }
        }

        private const string COLOR = "PolygonColor";
        private const string NAME = "Name";
        private const string VERTEX = "Vertex";
    }
}
