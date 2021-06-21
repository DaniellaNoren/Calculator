using System;
using System.Collections.Generic;
using System.Text;

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
                product /= numberArray[i];
            }

            return product;
        }

        public static double Divide(double a, double b)
        {
            return a / b;
        }

        public static double ThePowerOf(double a, double b)
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
                power = Divide(1, power);

            return power;
        }

        public static double ThePowerOf(double[] numbers)
        {
            double exponentSum = numbers[1];

            for (int i = 2; i < numbers.Length; i++)
            {
                exponentSum *= numbers[i];
            }

            return ThePowerOf(numbers[0], exponentSum);

        }
    }
}
