using System.Collections.Generic;
using System.Linq;
using Genetic_Algorithm.Utils;

namespace Genetic_Algorithm.GA.Generics
{
    /// <inheritdoc />
    ///  <summary>
    /// Provides methods for manipulating populations in GA to produce new generations
    /// </summary>
    /// <typeparam name="TIndividual">Class implementing GA Individual</typeparam>
    /// <typeparam name="TGene">Class implementing GA IGene</typeparam>
    public abstract class GeneticAlgorithmAdapter<TIndividual, TGene> : IGeneticAlgorithmAdapter<TIndividual, TGene>
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene
    {
        protected readonly IFitnessCalculator<TIndividual, TGene> FitnessCalculator;

        /// <inheritdoc />
        protected GeneticAlgorithmAdapter(IFitnessCalculator<TIndividual, TGene> fitnessCalculator)
        {
            FitnessCalculator = fitnessCalculator;
        }

        /// <inheritdoc />
        public abstract TIndividual CrossOver(TIndividual parent1, TIndividual parent2);

        /// <inheritdoc />
        public bool CrossoverShouldOccur(double crossoverProbability)
            => UniqueRandom.Instance.NextDouble() <= crossoverProbability;

        /// <inheritdoc />
        public TIndividual GetEliteIndividual(Population<TIndividual,TGene> population)
        {
            var eliteIndividual = population.GetFittest(FitnessCalculator);
            eliteIndividual.IsElite = true;
            return eliteIndividual;
        }

        /// <inheritdoc />
        public void Mutate(TIndividual individual, double mutationProbability)
            => individual.Mutate(mutationProbability);

        /// <inheritdoc />
        public void MutatePopulation(Population<TIndividual, TGene> population, double mutationProbability)
        {
            foreach (var individual in population)
            {
                if (!individual.IsElite)
                { individual.Mutate(mutationProbability); }
                else
                { individual.IsElite = false; } //revert individual's elite property to normal for the next generation
            }
        }

        /// <inheritdoc />
        public bool MutationShouldOccur(TIndividual individual) => individual.IsElite;

        /// <inheritdoc />
        public TIndividual SelectForRouletteBreeding(Population<TIndividual, TGene> sourcePopulation, TIndividual forbiddenForBreeding = default(TIndividual))
        {
            double populationFitnessSum = PopulationFitnessSum(sourcePopulation);
            //repeat in case forbiddenIndividual happens to be last and happens to be chosen
            while (true)
            {
                double rouletteSumReached = 0;
                double randomRouletteSelectionPoint = UniqueRandom.Instance.NextDouble() * populationFitnessSum;
                foreach (var individual in sourcePopulation)
                {
                    rouletteSumReached += FitnessCalculator.IndividualFitness(individual);
                    if (ExceededSelectionPoint(rouletteSumReached, randomRouletteSelectionPoint, populationFitnessSum))
                    {
                        if (forbiddenForBreeding == null || forbiddenForBreeding.Equals(default(TIndividual)))
                        { return individual; }
                        else
                        {
                            if (!forbiddenForBreeding.Equals(individual))
                            { return individual; }
                        }
                    }
                }
            }            
        }
        private static bool ExceededSelectionPoint(double currentValue, double selectionPoint, double populationFitnessSum)
            => (currentValue <= populationFitnessSum && currentValue >= selectionPoint)
            || (currentValue >= populationFitnessSum && currentValue <= selectionPoint);

        /// <inheritdoc />
        public IEnumerable<TIndividual> SelectSteadyStateSurvivors(Population<TIndividual, TGene> sourcePopulation, double survivalRatio, bool elitism)
        {
            TIndividual eliteIndividual = default(TIndividual);
            if (elitism)
            { eliteIndividual = sourcePopulation.GetFittest(FitnessCalculator); }

            int survivorCount = (int)(sourcePopulation.Count * survivalRatio);
            survivorCount = elitism ? survivorCount - 1 : survivorCount; //if elitism is on, reduce survivors by one (elite is guaranteed to survive)
            //get remaining survivors
            foreach (var survivor in sourcePopulation
                .Where(indiv => !indiv.Equals(eliteIndividual)) //do not include elite individual in selection, elite is guaranteed to be added by GA
                .OrderByDescending(RandomWeightedFitness)
                .Take(survivorCount))
                yield return survivor;
        }
        private double RandomWeightedFitness(TIndividual indiv)
            => FitnessCalculator.IndividualFitness(indiv) * UniqueRandom.Instance.NextDouble();

        private double PopulationFitnessSum(Population<TIndividual, TGene> population)
            => population.Select(i => FitnessCalculator.IndividualFitness(i)).Sum();
    }
}
