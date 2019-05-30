using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    interface IFileReader
    {
        int[,] CreateDistanceMatrix(UserInput userInput);
        int GetMatrixSize();
    }
}
