using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticAlgorithm.Utils;

namespace GeneticAlgorithm.GA.Generics
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
        private int CurrentGenerationNumber { get; set; }
        private readonly Population<TIndividual, TGene> initialPopulation;
        private Population<TIndividual, TGene> currentGeneration;
        private Population<TIndividual, TGene> nextGeneration;

        /// <summary>
        /// Handles logic of breeding, selecting, mutating, etc.
        /// </summary>
        private readonly IGeneticAlgorithmAdapter<TIndividual, TGene> adapter;

        /// <summary>
        /// Creates an instance of GA with a random initial population sample
        /// </summary>
        /// <param name="adapter">GA Adapter to be used by the algorithm</param>
        public GeneticAlgorithm(IGeneticAlgorithmAdapter<TIndividual, TGene> adapter)
        { 
            initialPopulation = new Population<TIndividual, TGene>(SettingsAccessor.PopulationSize, SettingsAccessor.PopulationSize);
            currentGeneration = new Population<TIndividual, TGene>(initialPopulation);
            nextGeneration = new Population<TIndividual, TGene>(desiredSize: SettingsAccessor.PopulationSize);
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
        public GeneticAlgorithm(IGeneticAlgorithmAdapter<TIndividual, TGene> adapter, ICollection<TIndividual> include)
        {
            int possibleToInclude = Math.Min(include.Count, SettingsAccessor.PopulationSize);
            int randomIndividualsRequired = SettingsAccessor.PopulationSize - possibleToInclude;
            initialPopulation = new Population<TIndividual, TGene>(randomIndividualsRequired, SettingsAccessor.PopulationSize);
            initialPopulation.AddRange(include.Take(possibleToInclude).ToArray());

            currentGeneration = new Population<TIndividual, TGene>(initialPopulation);
            nextGeneration = new Population<TIndividual, TGene>(desiredSize: SettingsAccessor.PopulationSize);
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
                adapter.MutatePopulation(nextGeneration, SettingsAccessor.MutationProbability);

                CurrentGenerationNumber++;
                currentGeneration = new Population<TIndividual, TGene>(nextGeneration);

                OnGenerationComplete(new GaEventArgs<TIndividual, TGene>(currentGeneration, CurrentGenerationNumber));
            }
        }

        private void PopulateNextGeneration()
        {
            nextGeneration.Clear();
            if (SettingsAccessor.Elitism)
            { nextGeneration.Add(adapter.GetEliteIndividual(currentGeneration)); }
            switch (SettingsAccessor.Selection)
            {
                case SelectionType.Roulette:
                    RoulettePopulateNextGeneration();
                    break;

                case SelectionType.SteadyState:
                    nextGeneration.AddRange
                        (adapter.SelectSteadyStateSurvivors(currentGeneration, SettingsAccessor.SteadyStateSurvivalRate, SettingsAccessor.Elitism).ToArray());
                    RoulettePopulateNextGeneration();
                    break;

                default:
                    throw new InvalidEnumArgumentException($"Unexpected SelectionType in switch statement: {SettingsAccessor.Selection.ToString()}");
            }
        }

        private void RoulettePopulateNextGeneration()
        {
            while (!nextGeneration.FilledDesiredSize)
            {
                TIndividual parent1 = adapter.SelectForRouletteBreeding(currentGeneration);
                if (adapter.CrossoverShouldOccur(SettingsAccessor.CrossoverProbability))
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
