using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class TournamentSelection
    {
        public int[][] PerformTournamentSelection(Random randomNumber, int[][] inputPopulation, int[] individualsFitness, int roundsInEachDuelNumber)
        {
            int[][] victoriousIndividuals = new int[inputPopulation.Length][];
            int winnerId, rivalId;

            for (int duelId = 0; duelId < inputPopulation.Length; duelId++)
            {
                winnerId = randomNumber.Next(inputPopulation.Length);
                for (int opponentNumber = 0; opponentNumber < roundsInEachDuelNumber; opponentNumber++)
                {
                    rivalId = randomNumber.Next(inputPopulation.Length);
                    if (individualsFitness[winnerId] > individualsFitness[rivalId])
                    {
                        winnerId = rivalId;
                    }
                }
                victoriousIndividuals[duelId] = inputPopulation[winnerId];
            }
            return victoriousIndividuals;
        }
    }
}