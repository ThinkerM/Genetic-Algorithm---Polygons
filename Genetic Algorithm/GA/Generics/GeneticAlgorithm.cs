using System;
using System.Collections.Generic;
using System.Linq;
using static Genetic_Algorithm.Utils.SettingsAccessor;
using Genetic_Algorithm.Utils;

namespace Genetic_Algorithm.GA.Generics
{ 
    /// <summary>
    /// Main driver class to handle logic of the genetic algorithm
    /// </summary>
    /// <typeparam name="TIndividual"></typeparam>
    /// <typeparam name="TGene"></typeparam>
    public class GeneticAlgorithm<TIndividual, TGene>
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene
    {
        protected int CurrentGenerationNumber { get; set; }
        protected Population<TIndividual, TGene> initialPopulation;
        protected Population<TIndividual, TGene> currentGeneration;
        protected Population<TIndividual, TGene> nextGeneration;

        /// <summary>
        /// Handles logic of breeding, selecting, mutating, etc.
        /// </summary>
        protected IGeneticAlgorithmAdapter<TIndividual, TGene> adapter;

        /// <summary>
        /// Creates an instance of GA with a random initial population sample
        /// </summary>
        /// <param name="adapter">GA Adapter to be used by the algorithm</param>
        /// <param name="desiredSize"></param>
        public GeneticAlgorithm(IGeneticAlgorithmAdapter<TIndividual, TGene> adapter, int desiredSize)
        { 
            initialPopulation = new Population<TIndividual, TGene>(PopulationSize, PopulationSize);
            currentGeneration = new Population<TIndividual, TGene>(initialPopulation);
            nextGeneration = new Population<TIndividual, TGene>(desiredSize: PopulationSize);
            this.adapter = adapter;
            CurrentGenerationNumber = 1;

            Initialised?.Invoke(new GaEventArgs<TIndividual, TGene>(initialPopulation, CurrentGenerationNumber));
        }

        /// <summary>
        /// Creates an instance of GA whose initial population contains certain individuals 
        /// (+ additional random individuals if desired population size is larger than number of defined ones)
        /// </summary>
        /// <param name="adapter">GA Adapter to be used by the algorithm</param>
        /// <param name="include">Set of individuals to be included in the initial population</param>
        /// <param name="desiredSize"></param>
        public GeneticAlgorithm(IGeneticAlgorithmAdapter<TIndividual, TGene> adapter, ICollection<TIndividual> include, int desiredSize)
        {
            int possibleToInclude = Math.Min(include.Count, PopulationSize);
            int randomIndividualsRequired = PopulationSize - possibleToInclude;
            initialPopulation = new Population<TIndividual, TGene>(randomIndividualsRequired, PopulationSize);
            initialPopulation.AddRange(include.Take(possibleToInclude).ToArray());

            currentGeneration = new Population<TIndividual, TGene>(initialPopulation);
            nextGeneration = new Population<TIndividual, TGene>(desiredSize: PopulationSize);
            this.adapter = adapter;
            CurrentGenerationNumber = 1;

            Initialised?.Invoke(new GaEventArgs<TIndividual, TGene>(initialPopulation, CurrentGenerationNumber));
        }

        /// <summary>
        /// Perform necessary logic on a specified number of generations, then pause
        /// </summary>
        /// <param name="n">Number of generations to run</param>
        public void RunGenerations(int n)
        {
            for (int i = 0; i < n; i++)
            {
                PopulateNextGeneration();
                adapter.MutatePopulation(nextGeneration, MutationProbability);
                OnGenerationComplete(new GaEventArgs<TIndividual, TGene>(currentGeneration, CurrentGenerationNumber));

                CurrentGenerationNumber++;
                currentGeneration = new Population<TIndividual, TGene>(nextGeneration);
            }
        }

        private void PopulateNextGeneration()
        {
            nextGeneration.Clear();
            if (Elitism)
            { nextGeneration.Add(adapter.GetEliteIndividual(currentGeneration)); }
            switch (Selection)
            {
                case SelectionType.Roulette:
                    RoulettePopulateNextGeneration();
                    break;

                case SelectionType.SteadyState:
                    nextGeneration.AddRange
                        (adapter.SelectSteadyStateSurvivors(currentGeneration, SteadyStateSurvivalRate, Elitism).ToArray());
                    RoulettePopulateNextGeneration();
                    break;

                default:
                    throw new InvalidOperationException($"Unexpected SelectionType in switch statement: {Selection.ToString()}");
            }
        }

        private void RoulettePopulateNextGeneration()
        {
            while (!nextGeneration.FilledDesiredSize())
            {
                TIndividual parent1 = adapter.SelectForRouletteBreeding(currentGeneration);
                if (adapter.CrossoverShouldOccur(CrossoverProbability))
                {
                    TIndividual parent2 = adapter.SelectForRouletteBreeding(currentGeneration, parent1);
                    nextGeneration.Add(adapter.CrossOver(parent1, parent2));
                }
                else
                { nextGeneration.Add(parent1); }
            }
        }

        #region GA Events
        /// <summary>
        /// Occurs whenever a generation is crossed over, fully populated and mutated
        /// </summary>
        public event GenerationCompleteEventHandler<TIndividual, TGene> GenerationComplete;
        /// <summary>
        /// Invokes the <see cref="GenerationComplete"/> event
        /// </summary>
        /// <param name="ge"><see cref="GaEventArgs{TIndividual, TGene}"/> for the completed generation</param>
        protected virtual void OnGenerationComplete(GaEventArgs<TIndividual, TGene> ge)
        {
            GenerationComplete?.Invoke(ge);
        }

        /// <summary>
        /// Invokes the <see cref="Initialised"/> event
        /// </summary>
        protected virtual void OnInitialised()
        {
            Initialised?.Invoke(new GaEventArgs<TIndividual, TGene>(initialPopulation, 1));
        }
        /// <summary>
        /// Raised when a <see cref="GeneticAlgorithm{TIndividual, TGene}"/> finishes its construction and initialisation
        /// </summary>
        public static event GaInitialisedEventHandler<TIndividual,TGene> Initialised;
        #endregion
    }
}
