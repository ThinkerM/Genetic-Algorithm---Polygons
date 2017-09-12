using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Polygons;
using Genetic_Algorithm.GA.Generics;

namespace Genetic_Algorithm.GA.Polygon_based
{
    /// <summary>
    /// <see cref="IIndividual{IPolygonGene}"/> which introduces the structure of <see cref="IPolygon"/> into a genetic algorithm
    /// </summary>
    class PolygonIndividual : IIndividual<IPolygonGene>
    {
        private void CommonInitialization()
        {
            Polygon.ShiftCentroid(new Point(0, 0)); //normalize polygon's position
            Point polygonCentroid = Polygon.Centroid;
            foreach (var vertex in Polygon.Vertices)
            {
                Genome.Add(new SimplePolygonGene(vertex, polygonCentroid));
            }
        }

        public PolygonIndividual()
        {
            Polygon = Polygons.Polygons.RandomPolygon(SettingsAccessor.PolygonsVertices);
            CommonInitialization();
        }

        public PolygonIndividual(Polygon p)
        {
            Polygon = p;
            CommonInitialization();
        }

        public PolygonIndividual(IEnumerable<IPolygonGene> genome, string name, Color color)
        {
            List<Point> vertices = new List<Point>();
            foreach (var gene in genome)
            { vertices.Add(gene.Decode()); }
            Polygon = new Polygon(vertices, color, name);
            CommonInitialization();
        }

        public Polygon Polygon { get; private set; }
        public ICollection<IPolygonGene> Genome { get; private set; } = new List<IPolygonGene>();

        public void InvalidateFitness() => Fitness = InvalidFitnessIndicator;
        public static double InvalidFitnessIndicator { get { return double.NaN; } }
        public double Fitness { get; set; } = InvalidFitnessIndicator;

        public void Mutate(double mutationProbability)
        {
            List<Point> newVertices = new List<Point>();
            List<SimplePolygonGene> newGenome = new List<SimplePolygonGene>();
            //perform mutations
            foreach (var gene in Genome)
            {
                if (GeneShouldMutate(mutationProbability))
                { gene.Mutate(); }
                newVertices.Add(gene.Decode());
            }

            //reconstruct individual after mutations
            Polygon = new Polygon(newVertices, Polygon.OutlineColor, Polygon.Name);
            Point newCentroid = Polygon.Centroid;
            foreach (var gene in Genome)
            {
                gene.UpdateAngularRepresentation(newCentroid);
            }
            InvalidateFitness();
        }

        public string Name { get { return Polygon.Name; } }

        private bool GeneShouldMutate(double mutationProbability)
            => UniqueRandom.Instance.NextDouble() <= mutationProbability;

        public bool Equals(IIndividual<IPolygonGene> other)
        {
            PolygonIndividual compared = other as PolygonIndividual;
            return (compared?.Polygon == this.Polygon && compared?.Name == this.Name);
        }

        public bool IsElite { get; set; }
    }
}
