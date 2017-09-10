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
        {
            get
            {
                if (instance == null) { instance = new UniqueRandom(); }
                return instance;
            }
        }

        private UniqueRandom() { }
    }
}
