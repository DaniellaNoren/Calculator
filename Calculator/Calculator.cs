using System;

namespace Calculator
{
    public class Calculator
    {

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Add(double[] numberArray)
        {
            double sum = 0;

            for (int i = 0; i < numberArray.Length; i++)
            {
                sum += numberArray[i];
            }

            return sum;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Subtract(double[] numberArray)
        {
            double difference = numberArray[0];

            for (int i = 1; i < numberArray.Length; i++)
            {
                difference -= numberArray[i];
            }

            return difference;
        }


        public static double Multiply(double[] numberArray)
        {
            double product = numberArray[0];

            for (int i = 1; i < numberArray.Length; i++)
            {
                product *= numberArray[i];
            }

            return product;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double[] numberArray)
        {
           
            double product = numberArray[0];

            for (int i = 1; i < numberArray.Length; i++)
            {
                if (numberArray[i] == 0)
                    throw new DivideByZeroException("Cannot divide by zero");

                product /= numberArray[i];
            }

            return product;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");

            return a / b;
        }

        public static double ThePowerOf(double a, double b)
        {
            if (NumberIsADecimal(b))
                return Math.Pow(a, b);

            double power = 1;
            double positiveExponent;

            if (b >= 0)
                positiveExponent = b;
            else
                positiveExponent = b * -1;

                for (double i = 0; i < positiveExponent; i++)
                {
                    power *= a;
                }
            
         
           

            if (b < 0)
                power = Divide(1, power);

            return power;
        }

        public static bool NumberIsADecimal(double nr)
        {
            if (nr < 1 && nr > -1)
                return true;

            return (double) nr % (int)nr > 0;
        }

        public static double ThePowerOf(double[] numbers)
        {
            double exponentSum = 0;

            if (numbers.Length > 1)
                exponentSum = numbers[1];

            for (int i = 2; i < numbers.Length; i++)
            {
                exponentSum *= numbers[i];
            }

            return ThePowerOf(numbers[0], exponentSum);

        }
    }
}
