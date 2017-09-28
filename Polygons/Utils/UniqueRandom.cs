using System;

namespace Polygons.Utils
{
    /// <summary>
    /// Thread-safe, non-lazy singleton
    /// </summary>
    internal sealed class UniqueRandom : Random
    {
        public static UniqueRandom Instance { get; } = new UniqueRandom();

        public static bool HalfProbability() 
            => Instance.NextDouble() <= 0.5;

        static UniqueRandom() { }

        private UniqueRandom() { }
    }
}
