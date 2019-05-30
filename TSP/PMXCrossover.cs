using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class PMXCrossover
    {
        private int[][] offspringPopulation;
        private int crossPoint1, crossPoint2;
        private int[][] inputPopulation;

        public int[][] PerformPMXCrossover(Random randomNumber, CrossPointsGenerator crossPointsGenerator, int[][] inputPopulation, int crossingProbability)
        {
            this.inputPopulation = inputPopulation;
            offspringPopulation = new int[this.inputPopulation.Length][];

            int[] sequenceCrossingIndividuals = Enumerable.Range(0, this.inputPopulation.Length).OrderBy(value => randomNumber.Next()).ToArray();
            int individualId1 = 0, individualId2 = 0, matchedIndividuals = 0, drawnValue;

            for (int i = 0; i < this.inputPopulation.Length; i++)
            {
                individualId1 = sequenceCrossingIndividuals[i];
                drawnValue = randomNumber.Next(100);

                if (drawnValue < crossingProbability)
                {
                    offspringPopulation[individualId1] = Enumerable.Repeat(-1, this.inputPopulation[i].Length).ToArray();
                    matchedIndividuals++;
                    if (matchedIndividuals == 2)
                    {
                        var crossPoints = crossPointsGenerator.GenerateCrossPoints(this.inputPopulation[i].Length, randomNumber);
                        crossPoint1 = crossPoints.Item1;
                        crossPoint2 = crossPoints.Item2;
                        for (int geneId = crossPoint1; geneId <= crossPoint2; geneId++)
                        {
                            offspringPopulation[individualId1][geneId] = this.inputPopulation[individualId2][geneId];
                            offspringPopulation[individualId2][geneId] = this.inputPopulation[individualId1][geneId];
                        }
                        FillInUncrossedGenes(individualId1, individualId2, i);
                        FillInUncrossedGenes(individualId2, individualId1, i);
                        matchedIndividuals = 0;
                    }
                    else
                    {
                        individualId2 = individualId1;
                    }
                }
                else
                {
                    offspringPopulation[individualId1] = this.inputPopulation[individualId1];
                }
            }
            CheckDoesAloneIndividualExist(matchedIndividuals, individualId2);
            return offspringPopulation;
        }

        public void FillInUncrossedGenes(int individualId1, int individualId2, int i)
        {
            int gene;
            for (int geneId = 0; geneId < inputPopulation[i].Length; geneId++)
            {
                if (geneId < crossPoint1 || geneId > crossPoint2)
                {
                    gene = inputPopulation[individualId1][geneId];
                    while (offspringPopulation[individualId1].Contains(gene))
                    {
                        int geneIndex = Array.IndexOf(offspringPopulation[individualId1], gene);
                        gene = offspringPopulation[individualId2][geneIndex];
                    }
                    offspringPopulation[individualId1][geneId] = gene;
                }
            }
        }

        public void CheckDoesAloneIndividualExist(int matchedIndividuals, int aloneIndividualId)
        {
            if (matchedIndividuals == 1)
            {
                offspringPopulation[aloneIndividualId] = inputPopulation[aloneIndividualId];
            }
        }
    }
}