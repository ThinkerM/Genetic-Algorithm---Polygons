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
            double baseResult = base.IndividualFitness(individual);
            int intersectionCount = GetEdgeIntersectionCount(individual.Genome.Select(g => g.Decode()));
            double result = intersectionCount > 0 ? baseResult / intersectionCount : baseResult;
            individual.Fitness = result;
            return individual.Fitness;
        }

        private double GeneFitness(IPolygonGene evaluatedGene, PolygonIndividual individual)
        {
            Point centroid = individual.Polygon.Centroid;
            if (evaluatedGene.X == centroid.X) { return 0; } //points directly on symmetry axis don't need to look for mirrored relatives

            Point perfectRelative = TheoreticalPerfectlyMirroredRelative(evaluatedGene, centroid);
            IPolygonGene closest = individual.Genome
                .OrderBy(gene => OnSameAxisSide(evaluatedGene, gene)) //vertices on opposite side of axis have priority, OnSameAxisSide()=="false"(0) go first, "true"(1) second
                .ThenBy(gene => GeometryExtensions.Distance(perfectRelative, gene.Decode()))
                .First();

            return GeometryExtensions.Distance(perfectRelative, new Point(closest.X, closest.Y));
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

        private Point TheoreticalPerfectlyMirroredRelative(IPolygonGene gene, Point centroid)
            => new Point(centroid.X - gene.X, gene.Y);

        private bool OnSameAxisSide(IPolygonGene a, IPolygonGene b)
        {
            if (a.X < 0)
            { return b.X < 0; }
            else
            { return b.X > 0; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
