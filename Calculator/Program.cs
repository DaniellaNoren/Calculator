using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                choice = (int) GetNumberFromUser();
                ChooseMenuOption(choice);
            } while (choice != 9);
        }


        static void PrintMenu()
        {
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exponentiation");
            Console.WriteLine("9. Exit");
        }

        static void ChooseMenuOption(int choice)
        {
            switch (choice)
            {
                case 1: Addition(); break;
                case 2: Subtraction(); break;
                case 3: Multiplication(); break;
                case 4: Division(); break;
                case 5: Exponentiation(); break;    
                case 9: break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }

        static double GetNumberFromUser()
        {
            bool correctInput = false;
            double number = 0;

            while (!correctInput)
            {
                correctInput = Double.TryParse(Console.ReadLine().Replace(".", ","), out number);
                if (!correctInput)
                {
                    Console.WriteLine("Invalid number! Try again: ");
                }
            }

            return number;
        }

        public static double[] GetTwoNumbers()
        {
            Console.WriteLine("Insert two numbers: ");
            double[] twoNumbers = { GetNumberFromUser(), GetNumberFromUser() };
            return twoNumbers;
        }

        public static void Addition()
        {
            var numbers = GetTwoNumbers();
            double sum = AddTwoNumbers(numbers[0], numbers[1]);
     
            Console.WriteLine("{0} + {1} = {2}", numbers[0], numbers[1], sum);
        }

        public static double AddTwoNumbers(double a, double b)
        {
            return a + b;
        }

        public static void Subtraction()
        {
            var numbers = GetTwoNumbers();
            double difference = SubtractNumbers(numbers[0], numbers[1]);

            Console.WriteLine("{0} - {1} = {2}", numbers[0], numbers[1], difference);
        }
        public static double SubtractNumbers(double a, double b)
        {
            return a - b;
        }

        public static void Multiplication()
        {
            var numbers = GetTwoNumbers();
            double product = MultiplyNumbers(numbers[0], numbers[1]);

            Console.WriteLine("{0} * {1} = {2}", numbers[0], numbers[1], product);
        }

        public static double MultiplyNumbers(double a, double b)
        {
            return a * b;
        }

        public static void Division()
        {
            var numbers = GetTwoNumbers();

            while(numbers[1] == 0)
            {
                Console.WriteLine("Cannot divide by zero, enter another number: ");
                numbers[1] = GetNumberFromUser();
            }
            
            double product = DivideTwoNumbers(numbers[0], numbers[1]);

            Console.WriteLine("{0} / {1} = {2}", numbers[0], numbers[1], product);
        }

        public static double DivideTwoNumbers(double a, double b)
        {
            return a / b;
        }

        public static void Exponentiation()
        {
            var numbers = GetTwoNumbers();
            var power = NumberToThePowerOf(numbers[0], numbers[1]);

            Console.WriteLine("{0}^{1} = {2}", numbers[0], numbers[1], power);
        }

        public static double NumberToThePowerOf(double a, double b)
        {
            double power = 1;
            double positiveExponent;

            if (b >= 0)
                positiveExponent = b;
            else
                positiveExponent = b * -1;

            for (int i = 0; i < positiveExponent; i++)
            {
                power *= a;
            }

            if (b < 0)
                power = DivideTwoNumbers(1, power);

            return power;
        }
    }
}
