using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CustomExtensions.Geometry;
using MoreLinq;
using CustomExtensions.Collections;

namespace Polygons.GA.FitnessCalculators
{
    /// <inheritdoc cref="BasicSymmetryFitnessCalculator"/>
    /// <summary>
    /// <seealso cref="BasicSymmetryFitnessCalculator"/>
    /// Additonally reduces fitness for every intersecting edge pair in the polygon
    /// </summary>
    public class SymmetryIntersectionPenaltyFitnessCalculator : BasicSymmetryFitnessCalculator
    {
        /// <inheritdoc />
        protected override string Name => "Symmetry (Intersection penalty) FitnessCalculator";

        /// <summary>
        /// Use base calculation from <see cref="BasicSymmetryFitnessCalculator"/> and additionally reduces fitness for each edge intersection
        /// </summary>
        /// <param name="individual"></param>
        /// <returns></returns>
        public override double IndividualFitness(PolygonIndividual individual)
        {
            if (individual.Fitness.Equals(PolygonIndividual.InvalidFitnessIndicator))
            {
                double baseResult = base.IndividualFitness(individual);
                int intersectionCount = GetEdgeIntersectionCount(individual.Genome.Select(g => g.Decode())) - individual.Polygon.VerticesCount;
                double result = intersectionCount > 0 ? baseResult / intersectionCount : baseResult;
                individual.Fitness = result;
            }
            return individual.Fitness;
        }
        
        private static int GetEdgeIntersectionCount(IEnumerable<Point> vertices)
        {
            var verticesList = vertices as IList<Point> ?? vertices.ToList();
            var polygonEdges = verticesList.
                AdjacentPairs((x, y) => new { edgeStart = x, edgeEnd = y }).
                Concat(new { edgeStart = verticesList.First(), edgeEnd = verticesList.Last() }); //connect first and last elements of vertices (those also form an edge)
            var edgePairs = polygonEdges.Subsets(2);

            int resultCount = 0;
            foreach (var pair in edgePairs)
            {
                var edge1 = pair.First();
                var edgeEquation1 = new LineEquation(edge1.edgeStart, edge1.edgeEnd);

                var edge2 = pair.Last();
                var edgeEquation2 = new LineEquation(edge2.edgeStart, edge2.edgeEnd);

                if (edgeEquation1.GetSegmentIntersectionWithOtherSegment(edgeEquation2) != null)
                { resultCount++; }
            }
            return resultCount;
        }

        /// <inheritdoc cref="object.ToString()"/>
        public override string ToString()
        {
            return Name;
        }
    }
}
