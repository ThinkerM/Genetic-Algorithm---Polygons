﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Genetic_Algorithm.GA.Generics
{ 
    /// <summary>
    /// Main driver class to handle logic of the genetic algorithm
    /// </summary>
    /// <typeparam name="TIndividual"></typeparam>
    /// <typeparam name="TGene"></typeparam>
    class GeneticAlgorithm<TIndividual, TGene>
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene
    {
        private int CurrentGenerationNumber { get; set; }
        private int PopulationSize => SettingsAccessor.PopulationSize;
        private bool Elitism => SettingsAccessor.Elitism;
        private double SteadyStateSurvivorRatio => SettingsAccessor.SteadyStateSurvivalRate;
        private double CrossoverChance => SettingsAccessor.CrossoverProbability;
        private double MutationChance => SettingsAccessor.MutationProbability;
        private SelectionType Selection => SettingsAccessor.Selection;

        protected Population<TIndividual, TGene> initialPopulation;
        public Population<TIndividual, TGene> InitialPopulation { get { return initialPopulation; } }
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

        private GenerationCompleteEventHandler<TIndividual, TGene> _generationComplete;
        public event GenerationCompleteEventHandler<TIndividual, TGene> GenerationComplete
        {
            add { _generationComplete += value; }
            remove { _generationComplete -= value; }
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
                adapter.MutatePopulation(nextGeneration, MutationChance);
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
                        (adapter.SelectSteadyStateSurvivors(currentGeneration, SteadyStateSurvivorRatio, Elitism).ToArray());
                    RoulettePopulateNextGeneration();
                    break;

                default:
                    throw new Exception($"Unexpected SelectionType in switch statement: {Selection.ToString()}");
            }
        }

        private void RoulettePopulateNextGeneration()
        {
            while (!nextGeneration.FilledDesiredSize())
            {
                TIndividual parent1 = adapter.SelectForRouletteBreeding(currentGeneration);
                if (adapter.CrossoverShouldOccur(CrossoverChance))
                {
                    TIndividual parent2 = adapter.SelectForRouletteBreeding(currentGeneration, parent1);
                    nextGeneration.Add(adapter.CrossOver(parent1, parent2));
                }
                else
                { nextGeneration.Add(parent1); }
            }
        }

        /// <summary>
        /// Invokes the <see cref="GenerationComplete"/> event
        /// </summary>
        /// <param name="ge">Information about the event population</param>
        protected virtual void OnGenerationComplete(GaEventArgs<TIndividual, TGene> ge)
        {
            _generationComplete?.Invoke(ge);
        }
        /// <summary>
        /// Raised when a <see cref="GeneticAlgorithm{TIndividual, TGene}"/> finishes its construction and initialisation
        /// </summary>
        public static event GaInitialisedEventHandler<TIndividual,TGene> Initialised;
    }
}