using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Algorithm.GA.Generics
{                
    /// <summary>
    /// Represents an organism/individual in a genetic algorithm
    /// </summary>
    public interface IIndividual<TGene> : IEquatable<IIndividual<TGene>>
        where TGene : IGene
    {
        ICollection<TGene> Genome { get; }

        double Fitness { get; set; }

        string Name { get; }

        /// <summary>
        /// Indicates whether the individual is currently the elite member of its generation.
        /// Elite individuals will be copied over to the next generation without any mutations.
        /// </summary>
        bool IsElite { get; set; }

        /// <summary>
        /// Allow for random alteration of the individual's genome
        /// </summary>
        /// <param name="mutationProbability">Likelihood for every single gene to mutate</param>
        void Mutate(double mutationProbability);
    }
}
