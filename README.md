# TSPSolver
TSPSolver is a console application developed in C# language, which is used to solve a salesman's problem using a genetic algorithm.

## Table of contents
* [Project description](#project-description)
  * [Travelling salesman problem](#travelling-salesman-problem)
  * [Genetic algorithm](#genetic-algorithm)
  * [Initial population](#initial-population)
  * [Fitness function](#fitness-function)
  * [Selection](#selection)
  * [Crossover](#crossover)
  * [Mutation](#mutation)
  * [The effect of the programme](#the-effect-of-the-programme)
  * [Input parameters](#input-parameters)
  * [Notes](#notes)
  * [Example input sets](#example-input-sets) 
* [Technologies](#technologies)
* [Author](#author)

## Project description

### Travelling salesman problem
>The salesman's problem is an optimization problem, consisting in finding the minimum Hamilton cycle in a complete graph. 


The main task of the program is to find the shortest route for n-cities (loaded from an input file) using a genetic algorithm.

### Genetic algorithm
> Genetic algorithm is a kind of heuristic (a method of searching for solutions without a guarantee of finding an optimal solution), searching the space for alternative solutions to the problem in order to find the best solutions. 

Below is a list of basic concepts, with their reference to their role in TSPSolver:

* **gene** - a particle that builds up each individual, representing one city number,
* **an individual** - represents one set of cities (genes) that a salesman has to visit in the given order. Each inidivudal consists of n unique genes (where n is the number of cities),
* **population** - a specific set of individuals. Each population has the same number of individuals,
* **iteration** - one iteration defines a full set of operations (selection, crossover, mutation, fitness function) performed on the current population. 

More about genetic algorthims avaliable [here](https://en.wikipedia.org/wiki/Genetic_algorithm).
### Initial population
The initial population is a group of randomly generated individuals. Each individual must have unique genes (they must not be repeated), but two or more individuals may be the same. The role of creating an initial population is to provide the first random solutions to the problem, which will then be modified. Such a population will be generated only once during the program's lifetime.
### Fitness function
The fitness function is designed to evaluate each individual according to a specific criterion. 
In a salesman's problem, the measure of usefulness is the distance needed to cover the path defined by the individual (which he has coded in genes). The lower the rating, the shorter the path is, so the individual is considered to be better. The assessment of an individual's quality is made after each iteration (population).
### Selection
During the selection process, a part of the existing population is exchanged for better quality individuals. The TSPSolver program uses **tournament selection**, because it gives a variety of effects (gives a chance to weaker solutions but also rewards better ones). At the beginning there is a parameter that tells how many players will compete in one duel. As a result, two (or more) participants are randomly selected from the current population. The individual with the best suitability is transferred to the new population. The duels are repeated until the creation of a whole new population, equal in size to the existing one, is completed.
### Crossover
Crossover is the operation of pairing two individuals and exchanging them with certain genes. In the TSPSolver program, the **PMX crossover** is implemented. The probability of crossing is given by the user. If a given individual is selected for crossover, he will wait for the second one to be exchanged. When this happens, two different intersection points are randomly selected. Then the genes between the intersection points will be changed for both individuals. The remaining genes will be filled in as follows: the first child will be attempted to be assigned a gene from the first parent. If the gene is not yet present in the offspring, it will be copied. Otherwise, the algorithm will check what the corresponding gene is in the second child and try to assign it. The operation is performed until the first child does not have the gene. The second child is filled in similarly.
### Mutation
Mutation is an operation based on random modification of genes of a specific individual. The probability of a mutation occurring is given by the user. If a particular individual is selected for a mutation, then, as in the case of a crossover, two intersection points will be drawn. Genes between them will be reversed (**inversion mutation**).
### The effect of the programme
The effect of the programme will be a specific number of iterations (given at the beginning), which will try to generate better results. When the last iteration ends program displays the result in the console and saves this data to the result.log file together with the start parameters.
Please note that each start of the program will give completely different results, even if you enter exactly the same input parameters. This happens because of the randomness present in genetic algorithms. These algorithms do not always find the optimal solution. Example output of the program in console:

![result](/result.PNG)
### Input parameters ####
When you start the program, you will be prompted to enter the following parameters:

* **population size** - how many individuals there will be in each population,
* **number of individuals in each duel** - how many individuals will take part in a one-time duel during the selection,
* **crossover probability** - how high is the chance that a particular individual will be crossed,
* **mutation probability** - how high is the chance that a particular individual will be mutated,
* **number of iterations** - during the program's operation.
* **input file** - can be selected from a list of predefined files or attached to Data folder (must meet the requirements described below)

Input files must be saved in .txt format. The first line must contain a number representing the number of cities. The following lines must contain the distance saved in the matrix format (see example files).

### Notes ####
Selecting the right parameters is key to achieving better results. Giving too high (or too low) values may lead to premature algorithm convergence or, on the contrary, to a much too slow population change to a new one. This may result in a poor final result. I strongly encourage you to enter your combinations of parameters and observations on how the results for each file change. 

### Example input sets ####
The data are presented in the following form:
>input file, population size, number of individuals in each duel, crossover probability, mutation probability, number of iterations

* a280 - 50/6/75/0.8/250000
* berlin52 - 40/4/85/0.3/400000
* ch150 - 15/4/70/1.0/200000
* eil76 - 20/3/75/0.2/250000
* kroC100 - 25/4/85/0.1/240000
* pt76 - 35/3/75/0.4/250000

## Technologies
* .NET Framework 4.5.2

## Author
Created by Michał Kazek.
