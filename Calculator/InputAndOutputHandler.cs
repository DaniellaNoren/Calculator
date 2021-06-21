using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class InputAndOutputHandler 
    {
        public string GetUserInput()
        {
            return Console.ReadLine().Trim();
        }

        public void HandleOutput(string outputString)
        {
            Console.WriteLine(outputString);
        }

        public List<double> GetNumbersFromUser()
        {
            HandleOutput("Insert numbers, press S to stop: ");

            string input;
            List<double> numbers = new List<double>();

            while (true)
            {
                input = GetUserInput();

                if ("S".Equals(input)) return numbers;

                TryToAddNumber(ref numbers, input);
                
            }
        }


        private bool TryToAddNumber(ref List<double> nrList, string nrString)
        {
            try
            {
                double nr = GetNumberFromString(nrString);
                nrList.Add(nr);
            }
            catch (InvalidInputException e)
            {
                HandleOutput(e.Message);
                return false;
            }

            return true;

        }

        public double GetNumberFromString(string stringToParse)
        {
            double number;

            try
            {
                InputIsValidNumber(stringToParse);
                number = Double.Parse(stringToParse);

            }
            catch (InvalidInputException e)
            {
                throw e;
            }

            return number;
        }

        public bool InputIsValidNumber(string input)
        {
            if (Regex.IsMatch(input, @"^\d+(?:,\d+)?$"))
                return true;
            else
                throw new InvalidInputException("Input is not a valid number"); 
        }

    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }


}
