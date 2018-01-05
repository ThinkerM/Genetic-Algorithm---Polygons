using System;

namespace Polygons.Utils
{
    /// <summary>
    /// Provides methods for determining paths to various relevant locations and creating appropriate paths for specific files
    /// </summary>
    internal static class PolygonPaths
    {
        private const string GA_FOLDER = @"\Genetic Algorithm - Polygons";
        private const string SAVE_FOLDER = SAVE_FOLDER_NOSLASH + @"\";
        private const string SAVE_FOLDER_NOSLASH = GA_FOLDER + @"\SavedShapes";

        private static string AppDataFolder => System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        /// <summary>
        /// Folder where saved polygons are stored
        /// </summary>
        /// <returns>Path to save folder for polygons</returns>
        public static string PolygonSavedShapesFolder => AppDataFolder + SAVE_FOLDER;

        /// <summary>
        /// Folder where saved polygons are stored, final directory separator omitted
        /// </summary>
        /// <returns>Path to save folder for polygons without final directory separator</returns>
        public static string PolygonSavedShapesFolderNoBacklash => AppDataFolder + SAVE_FOLDER_NOSLASH;

        /// <summary>
        /// Constructs a whole path to a named file in given folder
        /// </summary>
        /// <param name="folderPath">Uri class representing the target folder</param>
        /// <param name="fileName">Name of the file (without path)</param>
        /// <returns></returns>
        private static string FileInFolderPath(Uri folderPath, string fileName)
            => $"{folderPath.LocalPath}{fileName}";

        /// <summary>
        /// Constructs a whole path to a named file in given folder
        /// </summary>
        /// <param name="folderPath">Path to folder to construct in</param>
        /// <param name="fileName">Name of the file (without path)</param>
        /// <returns></returns>
        private static string FileInFolderPath(string folderPath, string fileName)
            => $"{new Uri(folderPath).LocalPath}{fileName}";

        /// <summary>
        /// Whole path to a file with a given name
        /// </summary>
        /// <param name="fileName">Name of the file to construct a path to</param>
        /// <returns></returns>
        public static string SaveXmlPath(string fileName)
        {
            string resultPath = FileInFolderPath(new Uri(PolygonSavedShapesFolder), fileName);
            return fileName.EndsWith(".xml", true, System.Globalization.CultureInfo.CurrentCulture)
                ? resultPath
                : resultPath + ".xml";
        }
    }
}
