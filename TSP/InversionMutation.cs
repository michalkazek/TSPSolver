using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class InversionMutation
    {
        public int[][] PerformInversionMutation(Random randomNumber, CrossPointsGenerator crossPointsGenerator, int[][] inputPopulation, float mutationProbability)
        {
            int[][] offspringPopulation = new int[inputPopulation.Length][];
            int drawnValue, crossPointSubtraction;
            mutationProbability = Convert.ToInt32(mutationProbability * 10);

            for (int individualId = 0; individualId < inputPopulation.Length; individualId++)
            {
                offspringPopulation[individualId] = inputPopulation[individualId];
                drawnValue = randomNumber.Next(1000);
                if (drawnValue < mutationProbability)
                {
                    var crossPoints = crossPointsGenerator.GenerateCrossPoints(inputPopulation[individualId].Length, randomNumber);
                    crossPointSubtraction = (crossPoints.Item2 - crossPoints.Item1) + 1;
                    Array.Reverse(offspringPopulation[individualId], crossPoints.Item1, crossPointSubtraction);
                }
            }           
            return offspringPopulation;
        }
    }
}
