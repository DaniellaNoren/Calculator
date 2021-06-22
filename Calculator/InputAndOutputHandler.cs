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

        public List<double> GetNumbersFromUser(string keyToStop = "S")
        {
            string input;
            List<double> numbers = new List<double>();

            while (true)
            {
                input = GetUserInput();

                if (keyToStop.Equals(input)) return numbers;

                TryToAddNumber(ref numbers, input.Replace('.', ','));
                
            }
        }


        private bool TryToAddNumber(ref List<double> nrList, string nrString)
        {
            try
            {
                double nr = GetNumberFromString(nrString);
                nrList.Add(nr);
            }
            catch (InvalidInputException)
            {
                return false;
            }

            return true;

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
