using System.Collections.Generic;

namespace GeneticAlgorithm.GA.Generics
{
    /// <summary>
    /// Evaluates <see cref="IIndividual{IGene}"/>s and sets + returns their calculated fitness score
    /// </summary>
    /// <typeparam name="TIndividual"></typeparam>
    /// <typeparam name="TGene"></typeparam>
    public interface IFitnessCalculator<in TIndividual, TGene> : IComparer<TIndividual>
        where TIndividual : IIndividual<TGene>
        where TGene : IGene
    {
        /// <summary>
        /// Calculate fitness value for the individual
        /// </summary>
        /// <param name="individual">GA Individual to calculate for</param>
        /// <returns>Fitness score</returns>
        double IndividualFitness(TIndividual individual);

        /// <summary>
        /// Name of the calculator to be used in calculators selection (improved readability)
        /// </summary>
        string ToString();
    }
}
