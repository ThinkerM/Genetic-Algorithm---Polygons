using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Genetic_Algorithm.GA.Generics;

namespace Genetic_Algorithm.GA.Polygon_based.FitnessCalculators
{
    /// <summary>
    /// Provides a centralised access to fitness calculators intended for <see cref="PolygonIndividual"/>s
    /// </summary>
    static class PolygonfitnessCalculators
    {
        public static List<IFitnessCalculator<PolygonIndividual, IPolygonGene>> GetAllCalculators()
        {
            return new List<IFitnessCalculator<PolygonIndividual, IPolygonGene>>
            {
                new BasicSymmetryFitnessCalculator(),
                new SymmetryIntersectionPenaltyFitnessCalculator()
            };
            
            //would be nice with reflection but harder to make work properly
            /*  var subclasses = typeof(PolygonfitnessCalculators).GetNestedTypes().ToList();
            var calculators = subclasses
                .Where(subclass => subclass.GetInterfaces()
                    .Contains(typeof(IFitnessCalculator<PolygonIndividual, IPolygonGene>)))
                .ToArray();
            var resultList = new List<object>();
            foreach (var calculator in calculators)
            {
                resultList.Add(calculator);
            }
            return resultList;*/
        }
    }
}
