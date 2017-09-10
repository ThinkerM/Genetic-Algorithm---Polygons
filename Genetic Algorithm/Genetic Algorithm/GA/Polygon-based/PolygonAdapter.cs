using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Randomization;
using System.Drawing;
using Genetic_Algorithm.GA.Generics;

namespace Genetic_Algorithm.GA.Polygon_based
{
    /// <summary>
    /// <see cref="GeneticAlgorithmAdapter{PolygonIndividual, IPolygonGene}"/> which contains the logic for crossover of the <see cref="PolygonIndividual"/>s
    /// </summary>
    class PolygonAdapter : GeneticAlgorithmAdapter<PolygonIndividual, IPolygonGene>
    {
        public PolygonAdapter(IFitnessCalculator<PolygonIndividual, IPolygonGene> fitnessCalculator) : base(fitnessCalculator)
        {
        }

        public override PolygonIndividual CrossOver(PolygonIndividual parent1, PolygonIndividual parent2)
        {
            var parent1AngleOrderedGenome = parent1.Genome.OrderBy(g => g.AngleRelativeToCentroid.Radians).ToList();
            var parent2AngleOrderedGenome = parent2.Genome.OrderBy(g => g.AngleRelativeToCentroid.Radians).ToList();
            if (parent1.Genome.Count == parent2.Genome.Count)
            {
                var newGenome = new List<IPolygonGene>();

                var zippedGenomes = parent1.Genome.Zip(parent2.Genome, (first, second)
                    => new {gene1 = first, gene2 = second });
                foreach (var genePair in zippedGenomes)
                {
                    var geneToAdd = UniqueRandom.HalfProbability() ? genePair.gene1 : genePair.gene2;
                    newGenome.Add(geneToAdd);
                }

                Color childColor = GetChildColor(parent1.Polygon.OutlineColor, parent2.Polygon.OutlineColor);

                return new PolygonIndividual(
                    newGenome,
                    ChildName(parent1.Name, parent2.Name),
                    childColor);
            }
            else
            { throw new Exception($"Incompatible genomes:{System.Environment.NewLine}{parent1.Name}: Length {parent1.Genome.Count}{System.Environment.NewLine}{parent2.Name}: Length {parent2.Genome.Count}"); }
        }

        private string ChildName(string p1, string p2)
        {
            int shortestParentLength = Math.Min(p1.Length, p2.Length);
            int longestParentLength = Math.Max(p1.Length, p2.Length);
            StringBuilder sb = new StringBuilder(longestParentLength);
            for (int i = 0; i < shortestParentLength; i++)
            {
                if (UniqueRandom.HalfProbability())
                { sb.Append(p1[i]); }
                else
                { sb.Append(p2[i]); }
            }
            int lengthToFill = Math.Min(longestParentLength, 15); //prevent too long names to avoid this becoming a bottleneck
            for (int i = sb.Length;  i <= lengthToFill; i++)
            {
                sb.Append(RandomCharsAndStrings.RandomAlphanumericCharacter());
            }
            return sb.ToString();
        }

        private Color GetChildColor(Color p1, Color p2)
        {
            return RandomColors.RandomColor();
        }
    }
}
