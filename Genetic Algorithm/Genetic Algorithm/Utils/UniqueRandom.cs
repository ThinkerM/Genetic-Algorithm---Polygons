using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm
{
    internal sealed class UniqueRandom : Random
    {
        private static UniqueRandom instance;

        public static UniqueRandom Instance
        {
            get
            {
                if (instance == null) { instance = new UniqueRandom(); }
                return instance;
            }
        }

        public static bool HalfProbability()
        {
            return Instance.NextDouble() <= 0.5;
        }

        private UniqueRandom() { }
    }
}
