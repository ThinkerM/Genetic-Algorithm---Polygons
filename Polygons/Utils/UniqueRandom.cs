using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
    internal sealed class UniqueRandom : Random
    {
        private static UniqueRandom instance;

        public static UniqueRandom Instance 
            => instance ?? (instance = new UniqueRandom());

        public static bool HalfProbability() 
            => Instance.NextDouble() <= 0.5;

        private UniqueRandom() { }
    }
}
