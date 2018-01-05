using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using MoreLinq;
using ThinkerExtensions.Geometry;

namespace Polygons.GA.FitnessCalculators
{
    /// <inheritdoc cref="BasicSymmetryFitnessCalculator"/>
    /// <summary>
    /// <seealso cref="BasicSymmetryFitnessCalculator"/>
    /// Additonally reduces fitness for every intersecting edge pair in the polygon
    /// </summary>
    public class SymmetryIntersectionPenaltyFitnessCalculator : BasicSymmetryFitnessCalculator
    {
        
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
            var verticesList = vertices as IList<Point> ?? vertices.ToList(); //avoid multiple enumeration
            IEnumerable<LineEquation> polygonEdges = verticesList
                .Zip(verticesList.Skip(1), (start, end) => new {start, end})
                .Select(vertexPair => new LineEquation(vertexPair.start, vertexPair.end))
                .Concat(new LineEquation(verticesList[0], verticesList[verticesList.Count - 1])); //add first and last vertices as an edge
            IEnumerable<IList<LineEquation>> edgePairs = polygonEdges.Subsets(2);

            return edgePairs.Count(pair => pair[0].GetSegmentIntersectionWithOtherSegment(pair[1]).HasValue);
        }
    }
}
