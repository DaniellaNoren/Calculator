using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class CalculatorProgram
    {

        private static readonly InputAndOutputHandler InputAndOutputHandler = new InputAndOutputHandler();
        private static readonly StringBuilder StringBuilder = new StringBuilder();

        static void Main(string[] args)
        {
            CalculatorProgram Program = new CalculatorProgram();

            Program.StartProgram();
        }

        public void StartProgram()
        {
            int choice = 0;
            bool tryAgain = true;

            do
            {
               PrintMenu();

                while (tryAgain) {

                    try
                    {
                        choice = (int) InputAndOutputHandler.GetNumberFromString(GetUserInput());
                        tryAgain = false;
                    }
                    catch (InvalidInputException e)
                    {
                        InputAndOutputHandler.HandleOutput(e.Message);
                    }

                }
    
               ChooseMenuOption(choice);
               tryAgain = true;

            } while (choice != 9);

            InputAndOutputHandler.HandleOutput("Goodbye!");

        }

        public void PrintMenu()
        {
            string menu = "1. Add\n" +
                          "2. Subtract\n" +
                          "3. Multiplication\n" +
                          "4. Division\n" +
                          "5. Exponentiation\n" +
                          "9. Exit";

            InputAndOutputHandler.HandleOutput(menu);
        }

        public string GetUserInput()
        {
            return InputAndOutputHandler.GetUserInput();
        }

        public void ChooseMenuOption(int choice)
        {
            
                switch (choice)
                {
                    case 1: Addition(); break;
                    case 2: Subtraction(); break;
                    case 3: Multiplication(); break;
                    case 4: Division(); break;
                    case 5: Exponentiation(); break;
                    case 9: break;
                    default: InputAndOutputHandler.HandleOutput("Invalid input, try again: "); break;
                }   

        }

        public double[] GetNumbers()
        {
            List<double> numbers = InputAndOutputHandler.GetNumbersFromUser();

            if (numbers.Count == 0)
            {
                throw new NoInputException("No numbers entered");
            }

            return numbers.ToArray();
        }

        public void Addition()
        {
            double[] numbers;

            try
            {
                numbers = GetNumbers();
            }
            catch (NoInputException)
            {
                return;
            }

            double sum = Calculator.Add(numbers);

            InputAndOutputHandler.HandleOutput(GetResultString(numbers, sum, '+'));

        }

        public void Subtraction()
        {
            double[] numbers;

            try
            {
                numbers = GetNumbers();
            }
            catch (NoInputException)
            {
                return;
            }

            double difference = Calculator.Subtract(numbers);

            InputAndOutputHandler.HandleOutput(GetResultString(numbers, difference, '-'));
        }

        public void Multiplication()
        {
            double[] numbers;

            try
            {
                numbers = GetNumbers();
            }
            catch (NoInputException)
            {
                return;
            }

            double product = Calculator.Multiply(numbers);

            InputAndOutputHandler.HandleOutput(GetResultString(numbers, product, '*'));
        }

        public void Division()
        {
            double[] numbers;

            try
            {
                numbers = GetNumbers();
            }
            catch (NoInputException)
            {
                return;
            }

            if (ArrayContainsZero(numbers, 1))
            {
                InputAndOutputHandler.HandleOutput("Cannot divide by zero, try again");
                return;
            }

            double product = Calculator.Divide(numbers);

            InputAndOutputHandler.HandleOutput(GetResultString(numbers, product, '/'));
        }

        private bool ArrayContainsZero(double[] nrs, int startIndex)
        {
            for(int i = startIndex; i < nrs.Length; i++)
            {
                if (nrs[i] == 0) return true;
            }

            return false;
        }

        public void Exponentiation()
        {
            double[] numbers = new double[0];
            bool validInput = false;
            double power;

            while (!validInput)
            {
                try
                {
                    numbers = GetNumbers();
                    validInput = true;
                }
                catch (NoInputException)
                {
                    return;
                }

                if (numbers.Length == 1)
                {
                    InputAndOutputHandler.HandleOutput("Need at least two numbers, try again");
                }
                
            }

            if (numbers.Length > 2)
                power = Calculator.ThePowerOf(numbers);
            else
                power = Calculator.ThePowerOf(numbers[0], numbers[1]);

            InputAndOutputHandler.HandleOutput(GetResultString(numbers, power, '^'));
        }

        public string GetResultString(double[] numbers, double result, char mathSign)
        {
            StringBuilder.Clear();

            foreach (double nr in numbers)
            {
                StringBuilder.Append(nr).Append(" ");
                StringBuilder.Append(mathSign).Append(" ");
            }

            StringBuilder.Remove(StringBuilder.Length - 2, 2);
            StringBuilder.Append("= ").Append(result);

            return StringBuilder.ToString();
        }

    }

        public class NoInputException : Exception
        {
            public NoInputException(string message) : base(message) { }
        }
}
