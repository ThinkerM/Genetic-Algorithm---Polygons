using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm.GA.Generics
{
    /// <summary>
    /// Extended population with additional information about its number as a generation in GA and the highest fitness value achieved
    /// </summary>
    /// <typeparam name="TIndividual">Type of <see cref="IIndividual{IGene}"/> in the population</typeparam>
    /// <typeparam name="TGene">Type of <see cref="IGene"/> in the population</typeparam>
    class SavedNumberedPopulation<TIndividual, TGene> : Population<TIndividual, TGene>
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene
    {
        /// <summary>
        /// Ordinal number of the generation stored in the population
        /// </summary>
        public int Number { get; }
        public double TopFitness { get; private set; } = double.NaN;

        /// <summary>
        /// Create a population with additional GA information
        /// </summary>
        /// <param name="population">Individuals to store</param>
        /// <param name="number">N-th generation in a GA</param>
        public SavedNumberedPopulation(Population<TIndividual, TGene> population, int number) : base(population)
        {
            Number = number;
            TopFitness = individuals.Select(i => i.Fitness).Max();
        }

        /// <summary>
        /// Only allows to set <see cref="TopFitness"/> if it hasn't been initialised yet (in case top fitness couldn't be acquired during construction)
        /// </summary>
        /// <param name="value"></param>
        public void TrySetFitness(double value) { if (TopFitness.Equals(double.NaN)) TopFitness = value; }
        public override string ToString() => $"Generation {Number} : Top fitness {TopFitness}";
    }

    /// <summary>
    /// Collection of individuals in a genetic algorithm
    /// </summary>
    /// <typeparam name="TIndividual">Type of the individual in the population</typeparam>
    /// <typeparam name="TGene">Type of the gene encoded in individual's genome</typeparam>
    class Population<TIndividual, TGene> : IList<TIndividual>
        where TIndividual : IIndividual<TGene>, new()
        where TGene : IGene
    {
        protected List<TIndividual> individuals = new List<TIndividual>();

        /// <summary>
        /// Number of individuals in population which need to be achieved for a complete generation
        /// </summary>
        public int DesiredSize { get; }

        /// <summary>
        /// Construct a population of random individuals
        /// </summary>
        /// <param name="randomIndividuals">Number of individuals to add</param>
        /// <param name="desiredSize">Size of the population which needs to be reached to be considered "adequately filled"</param>
        public Population(int randomIndividuals = 0, int desiredSize = 0)
        {
            for (int i = 0; i < randomIndividuals; i++)
            {
                individuals.Add(new TIndividual());
            }
            DesiredSize = desiredSize;
        }

        public static Population<TIndividual, TGene> EmptyPopulation()
        {
            return new Population<TIndividual, TGene>();
        }

        /// <summary>
        /// Construct a new population as a copy of another population
        /// </summary>
        /// <param name="template">Population to copy</param>
        public Population(Population<TIndividual,TGene> template)
        {
            individuals = new List<TIndividual>(template);
            DesiredSize = template.DesiredSize;
        }

        public bool Empty 
            => individuals.Count == 0;

        /// <summary>
        /// Indicates whether the population's size has reached or exceeded the set <see cref="DesiredSize"/>
        /// </summary>
        /// <returns></returns>
        public bool FilledDesiredSize() 
            => Count >= DesiredSize;

        public void Clear()
            => individuals.Clear();

        public TIndividual Find(string name) => individuals.Find(i => i.Name == name);

        public void Replace(TIndividual toReplace, TIndividual replaceWith)
        {
            int replacementPosition = individuals.IndexOf(individuals.Find(i => i.Name == toReplace.Name));
            individuals[replacementPosition] = replaceWith;
        }

        public int Count 
            => ((ICollection<TIndividual>)individuals).Count;

        public int Capacity 
            => individuals.Capacity;

        public bool IsReadOnly 
            => ((ICollection<TIndividual>)individuals).IsReadOnly;

        public TIndividual this[int index]
        {
            get { return ((IList<TIndividual>)individuals)[index]; }
            set { ((IList<TIndividual>)individuals)[index] = value; }
        }

        public virtual TIndividual GetIndividual(int index)
        {
            if (index >= individuals.Count)
            { return default(TIndividual); }

            return individuals[index];
        }

        public virtual IEnumerable<TIndividual> GetFittest(IFitnessCalculator<TIndividual, TGene> fitnessCalculator, int n)
            => individuals.OrderByDescending(indiv => fitnessCalculator.IndividualFitness(indiv)).Take(n);

        public virtual TIndividual GetFittest(IFitnessCalculator<TIndividual, TGene> fitnessCalculator)
            => individuals.OrderByDescending(indiv => fitnessCalculator.IndividualFitness(indiv)).FirstOrDefault();

        public void Add(TIndividual item)
            => ((ICollection<TIndividual>)individuals).Add(item);

        public void AddRange(IEnumerable<TIndividual> items)
            => individuals.AddRange(items);

        public void Sort(IFitnessCalculator<TIndividual, TGene> fitnessCalculator)
            => individuals.Sort(fitnessCalculator);

        public bool Contains(TIndividual item)
            => ((ICollection<TIndividual>)individuals).Contains(item);

        public void CopyTo(TIndividual[] array, int arrayIndex)
            => ((ICollection<TIndividual>)individuals).CopyTo(array, arrayIndex);

        public bool Remove(TIndividual item)
            => ((ICollection<TIndividual>)individuals).Remove(item);

        public IEnumerator<TIndividual> GetEnumerator()
            => ((ICollection<TIndividual>)individuals).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ((ICollection<TIndividual>)individuals).GetEnumerator();

        public int IndexOf(TIndividual item)
            => ((IList<TIndividual>)individuals).IndexOf(item);

        public void Insert(int index, TIndividual item)
            => ((IList<TIndividual>)individuals).Insert(index, item);

        public void RemoveAt(int index)
            => ((IList<TIndividual>)individuals).RemoveAt(index);
    }
}
