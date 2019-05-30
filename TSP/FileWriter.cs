using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class FileWriter
    {
        public void SaveResultIntoFile(int globalBestFitnessValue, int[] globalBestPath, int populationSize, int roundsInEachDuelNumber, int crossoverProbability, float mutationProbability, int numberOfIterations, string fileName)
        {
            using (StreamWriter outputFile = new StreamWriter(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Data\result.log", append: true))
            {
                outputFile.WriteLine("Generated {0}", DateTime.Now);
                outputFile.WriteLine("RESULT OF THE PROGRAM:");
                outputFile.WriteLine("Best fitness value: {0}", globalBestFitnessValue);
                outputFile.Write("For path:");
                globalBestPath.ToList().ForEach(value => outputFile.Write(value + " "));
                outputFile.WriteLine();              
                outputFile.WriteLine("INPUT PARAMETERES:");
                outputFile.WriteLine("Population size: {0}", populationSize);
                outputFile.WriteLine("Rounds in each duel number: {0}", roundsInEachDuelNumber);
                outputFile.WriteLine("Crossover probability: {0}%", crossoverProbability);
                outputFile.WriteLine("Mutation probability: {0}%", mutationProbability);
                outputFile.WriteLine("Number of iterations: {0}", numberOfIterations);
                outputFile.WriteLine("File name: {0}", fileName);
                outputFile.WriteLine();
            }
        }
    }
}
