using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions.Geometry;
using System.Drawing;
using Genetic_Algorithm.GA.Generics;

namespace Polygons.GA.FitnessCalculators
{
    /// <inheritdoc />
    /// <summary>
    /// For every <see cref="T:Polygons.GA.IPolygonGene" />, finds its closest Y axis mirrored relative and decreases fitness based on the distance difference from an ideal relative's position
    /// </summary>
    public class BasicSymmetryFitnessCalculator : IFitnessCalculator<PolygonIndividual, IPolygonGene>
    {
        /// <summary>
        /// Well-readable identifier
        /// </summary>
        protected virtual string Name { get; } = "Basic Symmetry FitnessCalculator";

        /// <summary>
        /// Evaluate fitness of a <see cref="PolygonIndividual"/> based on its symmetry
        /// </summary>
        /// <param name="individual"></param>
        /// <returns></returns>
        public virtual double IndividualFitness(PolygonIndividual individual)
        {
            double fitness = 0;
            if (individual.Fitness.Equals(PolygonIndividual.InvalidFitnessIndicator))
            {
                foreach (var gene in individual.Genome)
                {
                    fitness -= GeneFitness(gene, individual);
                }
                var normalizedResult = fitness == 0 ? Double.MaxValue : -1000 / fitness;
                individual.Fitness = normalizedResult;
            }
            return individual.Fitness;
        }

        private static double GeneFitness(IPolygonGene evaluatedGene, PolygonIndividual individual)
        {
            Point centroid = individual.Polygon.Centroid;
            if (evaluatedGene.X == centroid.X) { return 0; } //points directly on symmetry axis don't need to look for mirrored relatives

            Point perfectRelative = TheoreticalPerfectlyMirroredRelative(evaluatedGene, centroid);
            IPolygonGene closest = individual.Genome
                .OrderBy(gene => OnSameAxisSide(evaluatedGene, gene)) //vertices on opposite side of axis have priority, OnSameAxisSide()=="false"(0) go first, "true"(1) second
                .ThenBy(gene => GeometryExtensions.Distance(perfectRelative, gene.Decode()))
                .First(); //.First(gene => gene != evaluatedGene); 
                          //considering whether evaluatedGene itself can be chosen as closest relative (usually happens when it is fairly close to symmetry axis)

            return GeometryExtensions.Distance(perfectRelative, new Point(closest.X, closest.Y));
        }

        private static Point TheoreticalPerfectlyMirroredRelative(IPolygonGene gene, Point centroid)
            => new Point(centroid.X - gene.X, gene.Y);

        private static bool OnSameAxisSide(IPolygonGene a, IPolygonGene b)
        {
            if (a.X < 0)
            { return b.X < 0; }
            else
            { return b.X > 0; }
        }

        /// <inheritdoc />
        public int Compare(PolygonIndividual x, PolygonIndividual y)
            => IndividualFitness(x).CompareTo(IndividualFitness(y));

        /// <inheritdoc cref="object.ToString" />
        public override string ToString() => Name;
    }
}
