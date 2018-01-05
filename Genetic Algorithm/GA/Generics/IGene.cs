namespace GeneticAlgorithm.GA.Generics
{
    /// <summary>
    /// Stores an encoded representation of any trait which can be mutated
    /// </summary>
    public interface IGene
    {
        /// <summary>
        /// Change encoded values of the gene
        /// </summary>
        void Mutate();
    }

    /// <summary>
    /// Represents a gene with a specified encoded object
    /// </summary>
    /// <typeparam name="TEncoded">Encoded object type</typeparam>
    public interface IGene<out TEncoded> : IGene
    {
        /// <summary>
        /// Revert gene back into the object it is encoding
        /// </summary>
        /// <returns>Object which was encoded in the gene</returns>
        TEncoded Decode();
    }
}
