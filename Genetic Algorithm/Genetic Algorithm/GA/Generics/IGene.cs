using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm.GA.Generics
{
    /// <summary>
    /// Stores an encoded representation of any trait which can be mutated
    /// </summary>
    interface IGene
    {
        /// <summary>
        /// Change encoded values of the gene
        /// </summary>
        void Mutate();
    }

    /// <summary>
    /// Represents GA Gene with a specified encoded object
    /// </summary>
    /// <typeparam name="TEncoded">Encoded object type</typeparam>
    interface IGene<out TEncoded> : IGene
    {
        /// <summary>
        /// Revert gene back into the object it is encoding
        /// </summary>
        /// <returns>Object which was encoded in the gene</returns>
        TEncoded Decode();
    }
}
