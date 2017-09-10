using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm.GA.Generics
{
    /// <summary>
    /// Provides methods for manipulating populations in GA to produce new generations
    /// </summary>
    /// <typeparam name="TIndividual">Class implementing GA Individual</typeparam>
    /// <typeparam name="TGene">Class implementing GA IGene</typeparam>
    interface IGeneticAlgorithmAdapter<TIndividual, TGene>
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene
    {
        /// <summary>
        /// Chooses an individual for further reproduction based on roulette-rules
        /// </summary>
        /// <param name="sourcePopulation">Population to choose from</param>
        /// <param name="forbiddenForBreeding"><para>Individuals which cannot be selected for breeding.</para>
        /// Use primarily if you want to prevent an individual from breeding with itself</param>
        /// <returns>Selected individual</returns>
        TIndividual SelectForRouletteBreeding(Population<TIndividual, TGene> sourcePopulation, TIndividual forbiddenForBreeding = default(TIndividual));

        /// <summary>
        /// Selects fittest part of the population to transfer into the next generation
        /// </summary>
        /// <param name="sourcePopulation">Population to choose from</param>
        /// <param name="survivalRatio">Proportion of individuals to keep alive</param>
        /// <param name="elitism">Indicates whether elitism is on/off</param>
        /// <returns></returns>
        IEnumerable<TIndividual> SelectSteadyStateSurvivors(Population<TIndividual, TGene> sourcePopulation, double survivalRatio, bool elitism);

        /// <summary>
        /// Creates a new child from the genomes of two parents
        /// </summary>
        /// <param name="parent1">First parent to cross over</param>
        /// <param name="parent2">Second parent to cross over</param>
        /// <returns>Crossed over child</returns>
        TIndividual CrossOver(TIndividual parent1, TIndividual parent2);

        /// <summary>
        /// Determines whether a crossover of genomes between individuals should occur based on crossover probability
        /// </summary>
        /// <param name="crossoverProbability">Percentage value indicating how likely crossover should be to occur</param>
        /// <returns>True to crossover, False to forbid crossover</returns>
        bool CrossoverShouldOccur(double crossoverProbability);

        /// <summary>
        /// Find the fittest individual and set its property to Elite
        /// </summary>
        /// <param name="population">Population to search in</param>
        TIndividual GetEliteIndividual(Population<TIndividual, TGene> population);

        /// <summary>
        /// Invoke mutation on an individual
        /// </summary>
        /// <param name="individual"></param>
        /// <param name="mutationProbability"></param>
        void Mutate(TIndividual individual, double mutationProbability);

        /// <summary>
        /// Invoke mutation on every non-elite member of population
        /// </summary>
        /// <param name="population">Population to perform mutation on</param>
        /// <param name="mutationProbability"></param>
        void MutatePopulation(Population<TIndividual, TGene> population, double mutationProbability);

        /// <summary>
        /// Determines whether individual is allowed to mutate based on its Elite property
        /// </summary>
        /// <param name="individual">Subject of decision</param>
        /// <returns>True to mutate, False not to mutate</returns>
        bool MutationShouldOccur(TIndividual individual);
    }
}
