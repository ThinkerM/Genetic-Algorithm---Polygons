using System;
using System.Drawing;
using System.Text;

namespace Polygons.Utils
{
    /// <summary>
    /// Thread-safe, non-lazy singleton
    /// </summary>
    internal sealed class UniqueRandom : Random
    {
        public static UniqueRandom Instance { get; } = new UniqueRandom();

        public bool HalfProbability() 
            => Instance.NextDouble() <= 0.5;

        static UniqueRandom() { }

        private UniqueRandom() { }

        public Color RandomColor()
        {
            int a = Next(256);
            int r = Next(256);
            int g = Next(256);
            int b = Next(256);
            return Color.FromArgb(a, r, g, b);
        }

        public string RandomAlphanumericString(int length)
        {
            var result = new StringBuilder(length);
            const string Alphanumerics = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < length; i++)
            {
                result.Append(Alphanumerics[Next(Alphanumerics.Length)]);
            }
            return result.ToString();
        }
    }
}
