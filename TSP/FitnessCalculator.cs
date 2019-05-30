using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class FitnessCalculator
    {
        public int[] CalculateFitnessForIndividual(int[,] distanceMatrix, int[][] inputPopulation)
        {
            int[] individualsFitness = new int[inputPopulation.Length];
            int currentFitness;

            for (int individualId = 0; individualId < inputPopulation.Length; individualId++)
            {
                currentFitness = 0;
                for (int individualGeneId = 0; individualGeneId < inputPopulation[individualId].Length; individualGeneId++)
                {
                    if (individualGeneId == inputPopulation[individualId].Length - 1)
                    {
                        currentFitness += distanceMatrix[inputPopulation[individualId][individualGeneId], inputPopulation[individualId][0]];
                    }
                    else
                    {
                        currentFitness += distanceMatrix[inputPopulation[individualId][individualGeneId], inputPopulation[individualId][individualGeneId + 1]];
                    }
                }
                individualsFitness[individualId] = currentFitness;
            }
            return individualsFitness;
        }
    }
}