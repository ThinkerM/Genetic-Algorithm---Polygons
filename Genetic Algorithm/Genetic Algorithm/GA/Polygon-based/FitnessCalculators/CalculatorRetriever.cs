using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genetic_Algorithm.GA.Generics;

namespace Genetic_Algorithm.GA.Polygon_based.FitnessCalculators
{
    /// <summary>
    /// Provides a centralised access to fitness calculators intended for <see cref="PolygonIndividual"/>s
    /// </summary>
    static class CalculatorRetriever
    {
        public static IEnumerable<IFitnessCalculator<PolygonIndividual, IPolygonGene>> GetAllCalculators()
        {
            yield return new BasicSymmetryFitnessCalculator();
            yield return new SymmetryIntersectionPenaltyFitnessCalculator();
            
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
