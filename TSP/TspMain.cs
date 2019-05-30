using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class TspMain
    {
        private int globalBestFitnessValue;
        private int[] globalBestPath;
        private int populationSize;
        private int numberOfIterations;
        private int roundsInEachDuelNumber;
        private int crossoverProbability;
        private float mutationProbability;

        public void Run()
        {          
            UserInterface userInterface = new UserInterface();
            UserInput userInput = new UserInput();
            Random randomNumber = new Random();
            CrossPointsGenerator crossPointsGenerator = new CrossPointsGenerator();
            IFileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();
            InitialPopulation initialPopulation = new InitialPopulation();
            FitnessCalculator fitnessCalculator = new FitnessCalculator();
            TournamentSelection selection = new TournamentSelection();
            PMXCrossover crossover = new PMXCrossover();
            InversionMutation mutation = new InversionMutation();

            userInterface.PrintGreeting();
            SetProgramProperties(userInput);

            int[,] distanceMatrix = fileReader.CreateDistanceMatrix(userInput);
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[][] currentPopulation = initialPopulation.GenerateInitialPopulation(randomNumber, fileReader.GetMatrixSize(), populationSize);
            int[] currentFitnessForPopulation = fitnessCalculator.CalculateFitnessForIndividual(distanceMatrix, currentPopulation);
            GetBestFitnessValue(currentFitnessForPopulation, currentPopulation);

            for (int i = 0; i < numberOfIterations; i++)
            {
                currentPopulation = selection.PerformTournamentSelection(randomNumber, currentPopulation, currentFitnessForPopulation, roundsInEachDuelNumber);
                currentPopulation = crossover.PerformPMXCrossover(randomNumber, crossPointsGenerator, currentPopulation, crossoverProbability);
                currentPopulation = mutation.PerformInversionMutation(randomNumber, crossPointsGenerator, currentPopulation, mutationProbability);
                currentFitnessForPopulation = fitnessCalculator.CalculateFitnessForIndividual(distanceMatrix, currentPopulation);
                GetBestFitnessValue(i, currentFitnessForPopulation, currentPopulation, userInterface);
            }

            stopwatch.Stop();
            fileWriter.SaveResultIntoFile(globalBestFitnessValue, globalBestPath, populationSize, roundsInEachDuelNumber, crossoverProbability, mutationProbability, numberOfIterations, userInput.ReturnInputFileName());
            userInterface.PrintProgramResult(globalBestFitnessValue, globalBestPath, stopwatch);
        }

        public void SetProgramProperties(UserInput userInput)
        {
            populationSize = userInput.GetUserInput(1, 100000, "populationSize");
            roundsInEachDuelNumber = userInput.GetUserInput(2, 1000, "tournamentSelection");
            crossoverProbability = userInput.GetUserInput(1, 100, "crossingProbability");
            mutationProbability = userInput.GetUserInput(0.1f, 100);
            numberOfIterations = userInput.GetUserInput(1, 100000000, "numberOfIterations");
        }

        public void GetBestFitnessValue(int i, int[] currentFitnessForPopulation, int[][] currentPopulation, UserInterface userInterface)
        {
            int localBestFitnessValue = currentFitnessForPopulation.Min();
            if (localBestFitnessValue < globalBestFitnessValue)
            {
                globalBestFitnessValue = localBestFitnessValue;
                int bestIndividualIndex = Array.IndexOf(currentFitnessForPopulation, globalBestFitnessValue);
                globalBestPath = currentPopulation[bestIndividualIndex];
                userInterface.PrintCurrentBestPath(i, globalBestFitnessValue);                
            }
        }

        public void GetBestFitnessValue(int[] currentFitnessForPopulation, int[][] currentPopulation)
        {
            globalBestFitnessValue = currentFitnessForPopulation.Min();
            int bestIndividualIndex = Array.IndexOf(currentFitnessForPopulation, globalBestFitnessValue);
            globalBestPath = currentPopulation[bestIndividualIndex];
        }
    }
}