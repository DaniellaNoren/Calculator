using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class InputAndOutputHandler 
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public void HandleOutput(string outputString)
        {
            Console.WriteLine(outputString);
        }

        public int GetNumberFromUser()
        {
            int nr = 0;
            bool tryAgain = true;

            while (tryAgain)
            {

                try
                {
                    nr = (int) GetNumberFromString(GetUserInput().Trim());
                    tryAgain = false;
                }
                catch (InvalidInputException e)
                {
                    HandleOutput(e.Message);
                }

            }

            return nr;
        }

        public double[] GetNumbersFromUser()
        {
            string input = GetUserInput();
            string[] stringNumbers = input.Split(" ");
            double[] numbers = GetDoubleArrayFromStringArray(stringNumbers);

            return numbers;
        }

        public double[] GetDoubleArrayFromStringArray(string[] array)
        {

            int arrLength = array.Length;
            int arrLengthCopy = arrLength;
            double[] numbers = new double[arrLength];
            int numbersIndex = 0;

            for (int i = 0; i < arrLength; i++)
            {
                double nr;
                try
                {
                   nr = GetNumberFromString(array[i].Trim().Replace(".", ","));
                   numbers[numbersIndex] = nr;
                   numbersIndex++;
                }
                catch (InvalidInputException)
                {
                    arrLengthCopy--;
                    Array.Resize(ref numbers, arrLengthCopy);
                    continue;
                }
            }

            return numbers;
        }

        public double GetNumberFromString(string stringToParse)
        {
            double number;
           
            bool validInput = InputIsValidNumber(stringToParse);
            
            if (!validInput)
            {
                throw new InvalidInputException("Input is not a valid number");
            }

            number = Double.Parse(stringToParse);

            return number;
        }

        public bool InputIsValidNumber(string input)
        {
            return Regex.IsMatch(input, @"^\d+(?:,\d+)?$");
                
        }

    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }


}
