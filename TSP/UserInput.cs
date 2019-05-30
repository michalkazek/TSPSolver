using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class UserInput : UserInterface
    {
        private string inputFileNameFromUser;
        public string GetUserInputForFile()
        {
            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+@"\Data\";
            var allFilesInDirectory = Directory.EnumerateFiles(filePath, "*txt", SearchOption.AllDirectories).Select(Path.GetFileName);
            PrintFileList(allFilesInDirectory);
            inputFileNameFromUser = Console.ReadLine();
            return filePath+inputFileNameFromUser;
        }
        public string ReturnInputFileName()
        {
            return inputFileNameFromUser;
        }

        public int GetUserInput(int minRange, int maxRange, string parameterName)
        {
            int inputValueFromUser = 0;
            while(inputValueFromUser < minRange || inputValueFromUser > maxRange)
            {
                try
                {
                    PrintInfoAboutSpecificParameter(parameterName, minRange, maxRange);
                    inputValueFromUser = int.Parse(Console.ReadLine());
                    if(inputValueFromUser < minRange || inputValueFromUser > maxRange)
                    {
                        PrintValueOutOfRangeMessage();
                    }                    
                } 
                catch
                {
                    PrintIncorrectValueExceptionMessage();
                }               
            }
            return inputValueFromUser;
        }

        public float GetUserInput(float minRange, int maxRange)
        {
            float inputValueFromUser = 0;
            while (inputValueFromUser < minRange || inputValueFromUser > maxRange)
            {
                try
                {
                    PrintInfoAboutSpecificParameter(minRange, maxRange);
                    inputValueFromUser = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    if (inputValueFromUser < minRange || inputValueFromUser > maxRange)
                    {
                        PrintValueOutOfRangeMessage();
                    }
                } catch
                {
                    PrintIncorrectValueExceptionMessage();
                }
            }
            return inputValueFromUser;
        }
    }
}
