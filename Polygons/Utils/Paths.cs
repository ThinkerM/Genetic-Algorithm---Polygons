using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
    /// <summary>
    /// Provides methods for determining paths to various relevant locations and creating appropriate paths for specific files
    /// </summary>
    public static class Paths
    {
        //NOTE: some of these methods and their names are a mess. I managed to hook them well to different path requirements of various System.IO functionalities, but naming might be inaccurate.

        private const string GA_FOLDER = @"\Genetic Algorithm - Polygons";
        private const string SAVE_FOLDER = SAVE_FOLDER_NOSLASH + @"\";
        private const string SAVE_FOLDER_NOSLASH = GA_FOLDER + @"\SavedShapes";

        private static string AppDataFolder() => System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        /// <summary>
        /// Folder where saved polygons are stored
        /// </summary>
        /// <returns>Path to save folder for polygons</returns>
        public static string PolygonSavedShapesFolder() => AppDataFolder() + SAVE_FOLDER;

        /// <summary>
        /// Folder where saved polygons are stored, final directory separator omitted
        /// </summary>
        /// <returns>Path to save folder for polygons without final directory separator</returns>
        public static string PolygonSavedShapesFolderNoBacklash() => AppDataFolder() + SAVE_FOLDER_NOSLASH;

        /// <summary>
        /// Local-path representation of a uriPath
        /// </summary>
        /// <param name="uriPath">uriPath to construct local path from</param>
        /// <returns>Local-path representation of uriPath</returns>
        public static string LocalPath(string uriPath) => new Uri(uriPath).LocalPath;

        /// <summary>
        /// Whole path to a file with a given name
        /// </summary>
        /// <param name="fileName">Name of the file to construct a path to</param>
        /// <returns></returns>
        public static string SaveXmlPath(string fileName)
            => $"{LocalPath(PolygonSavedShapesFolder())}{fileName}.xml";
    }
}
