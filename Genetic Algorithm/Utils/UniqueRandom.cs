using System;

namespace GeneticAlgorithm.Utils
{
    internal sealed class UniqueRandom : Random
    {
        private static readonly UniqueRandom instance =null;
        private static readonly object Lock = new object();

        public static UniqueRandom Instance
        {
            get
            {
                lock (Lock)
                {
                    return instance ?? new UniqueRandom();
                }
            }
        }

        public bool HalfProbability() 
            => NextDouble() <= 0.5;

        private UniqueRandom() { }
    }
}
