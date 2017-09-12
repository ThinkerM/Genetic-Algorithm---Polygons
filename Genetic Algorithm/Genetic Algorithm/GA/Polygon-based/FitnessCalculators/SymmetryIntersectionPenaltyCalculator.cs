using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CustomExtensions.Geometry;
using MoreLinq;
using CustomExtensions.Collections;

namespace Genetic_Algorithm.GA.Polygon_based.FitnessCalculators
{
    /// <summary>
    /// <seealso cref="BasicSymmetryFitnessCalculator"/>
    /// Additonally reduces fitness for every intersecting edge pair in the polygon
    /// </summary>
    class SymmetryIntersectionPenaltyFitnessCalculator : BasicSymmetryFitnessCalculator
    {
        public override string Name { get { return "Symmetry (Intersection penalty) FitnessCalculator"; } }

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
        
        private int GetEdgeIntersectionCount(IEnumerable<Point> vertices)
        {
            var polygonEdges = vertices.
                AdjacentPairs((x, y) => new { edgeStart = x, edgeEnd = y }).
                Concat(new { edgeStart = vertices.First(), edgeEnd = vertices.Last() }); //connect first and last elements of vertices (those also form an edge)
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

        public override string ToString()
        {
            return Name;
        }
    }
}
