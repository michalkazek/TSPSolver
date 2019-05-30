using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class InitialPopulation
    {
        public int[][] GenerateInitialPopulation(Random randomNumber, int individualSize, int populationSize)
        {
            int[][] initialPopulation = new int[populationSize][];            

            for (int individualId = 0; individualId < populationSize; individualId++)
            {
                int[] individualGenotype = Enumerable.Range(0, individualSize).OrderBy(value => randomNumber.Next()).ToArray();
                initialPopulation[individualId] = individualGenotype;
            }
            return initialPopulation;
        }
    }
}
