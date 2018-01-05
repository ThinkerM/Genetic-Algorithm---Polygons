using System;

namespace GeneticAlgorithm.GA.Generics
{
    public delegate void GenerationCompleteEventHandler<TIndividual, TGene>(GaEventArgs<TIndividual, TGene> ge)
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene;

    public delegate void GaInitialisedEventHandler<TIndividual, TGene>(GaEventArgs<TIndividual, TGene> ge)
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene;

    /// <summary>
    /// Store relevant information for genetic algoritms to be passed for Ga event handlers
    /// </summary>
    /// <typeparam name="TIndividual">Type of the used <see cref="IIndividual{IGene}"/> in the event population</typeparam>
    /// <typeparam name="TGene">Type of the <see cref="IGene"/> in the event population</typeparam>
    public class GaEventArgs<TIndividual, TGene> : EventArgs
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene
    {
        /// <summary>
        /// A collection of individuals with additional information about their generation's number within the running GA and the best individual within the population
        /// </summary>
        public NumberedPopulation<TIndividual, TGene> SavedPopulation { get; }

        /// <summary>
        /// Create a <see cref="GaEventArgs{TIndividual, TGene}"/> instance
        /// </summary>
        /// <param name="eventPopulation">Current generation for the event</param>
        /// <param name="populationNumber">Current number of the generation</param>
        public GaEventArgs(Population<TIndividual, TGene> eventPopulation, int populationNumber)
        {
            SavedPopulation = new NumberedPopulation<TIndividual, TGene>(eventPopulation, populationNumber);
        }
    }    
}
