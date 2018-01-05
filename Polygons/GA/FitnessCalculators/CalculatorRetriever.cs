using System.Collections.Generic;
using Genetic_Algorithm.GA.Generics;

namespace Polygons.GA.FitnessCalculators
{
    /// <summary>
    /// Provides a centralised access to fitness calculators intended for <see cref="PolygonIndividual"/>s
    /// </summary>
    public static class CalculatorRetriever
    {
        /// <summary>
        /// Access all defined calculators
        /// </summary>
        /// <returns></returns>
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
