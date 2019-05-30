using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class UserInterface
    {
        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to TSPSolver. ");
            Console.WriteLine("This tool allows you to solve a salesman problem using a genetic algorithm. In a moment you will be asked for additional parameters.");
            Console.WriteLine("Remember, the results may vary for each runtime and it is a natural process, because some components of the program are generated randomly.");
            Console.WriteLine("Let's get started!\n");
        }
        protected void PrintFileList(IEnumerable<string> allFilesInDirectory)
        {
            Console.WriteLine("\nPlease select the input file from the list and type it's name.");
            foreach (string fileName in allFilesInDirectory)
            {
                Console.WriteLine(fileName);
            }
            Console.WriteLine();
        }
        public void PrintCurrentBestPath(int i, int globalBestFitnessValue)
        {
            Console.WriteLine("Iteration: {0} : fitness: {1}", i, globalBestFitnessValue);
        }
        public void PrintProgramResult(int globalBestFitnessValue, int[] globalBestPath, Stopwatch stopwatch)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nBest fitness value: {0}", globalBestFitnessValue);
            Console.Write("For path: ");
            globalBestPath.ToList().ForEach(value => Console.Write(value + " "));
            Console.WriteLine("\nIn time: {0} ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("\nResult saved into result.log file.");
            Console.ReadLine();
        }
        protected void PrintInfoAboutSpecificParameter(string parameterName, int minRange, int maxRange)
        {
            switch (parameterName)
            {
                case "populationSize":
                    Console.WriteLine("Please enter the population size ({0}-{1}), recommended 20-100.", minRange, maxRange);
                    break;
                case "tournamentSelection":
                    Console.WriteLine("Please enter how many rounds in each duel would you like to create? ({0}-{1}), recommended 8-12% of popualtion size.", minRange, maxRange);
                    break;
                case "crossingProbability":
                    Console.WriteLine("Please enter the probability of crossing ({0}-{1}), recommended 65-90.", minRange, maxRange);
                    break;
                case "numberOfIterations":
                    Console.WriteLine("Please enter how many iterations would you like to create? ({0}-{1}), recommended 200000-600000", minRange, maxRange);
                    break;
            }
        }
        protected void PrintInfoAboutSpecificParameter(float minRange, int maxRange)
        {
            Console.WriteLine("Please enter the probability of mutation ({0}-{1}), recommended 0.1-2.", minRange, maxRange);
        }
        protected void PrintValueOutOfRangeMessage()
        {
            Console.WriteLine("Entered value is beyond the required range. Please enter correct value.");
        }
        protected void PrintIncorrectValueExceptionMessage()
        {
            Console.WriteLine("Entered value is incorrect. Please enter correct value.");
        }       
    }
}
