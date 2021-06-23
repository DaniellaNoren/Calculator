using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Calculator.tests
{
    public class CalculatorTests
    {

        [Theory]
        [MemberData(nameof(CalculatorClassData.TwoDoublesTestData), MemberType = typeof(CalculatorClassData))]
        public void AddTwoNumbers(double nr1, double nr2)
        {
            Assert.Equal(nr1 + nr2, Calculator.Add(nr1, nr2));
        }

        [Theory]
        [MemberData(nameof(CalculatorClassData.AddTestData), MemberType = typeof(CalculatorClassData))]
        public void AddMultipleNumbers(double[] numbers, double expected)
        {
            double sum = Calculator.Add(numbers);
            Assert.Equal(expected, sum);
        }

        [Theory]
        [MemberData(nameof(CalculatorClassData.TwoDoublesTestData), MemberType = typeof(CalculatorClassData))]
        public void SubtractTwoNumbers(double nr1, double nr2)
        {
            Assert.Equal(nr1 - nr2, Calculator.Subtract(nr1, nr2));

        }

        [Theory]
        [MemberData(nameof(CalculatorClassData.SubtractTestData), MemberType = typeof(CalculatorClassData))]
        public void SubtractMultipleNumbers(double[] numbers, double expected)
        {
            double difference = Calculator.Subtract(numbers);
            Assert.Equal(expected, difference, precision: 3);
        }

        [Theory]
        [MemberData(nameof(CalculatorClassData.TwoDoublesTestData), MemberType = typeof(CalculatorClassData))]
        public void MultiplyTwoNumbers(double nr1, double nr2)
        {
            Assert.Equal(nr1 * nr2, Calculator.Multiply(nr1, nr2));
        }


        [Theory]
        [MemberData(nameof(CalculatorClassData.MultiplyTestData), MemberType = typeof(CalculatorClassData))]
        public void MultiplyMultipleNumbers(double[] numbers, double expected)
        {
            double product = Calculator.Multiply(numbers);
            Assert.Equal(expected, product, precision: 3);
        }

        [Theory]
        [MemberData(nameof(CalculatorClassData.TwoDoublesTestData), MemberType = typeof(CalculatorClassData))]
        public void DivideTwoNumbers(double nr1, double nr2)
        {
            Assert.Equal(nr1 / nr2, Calculator.Divide(nr1, nr2));

        }

        [Fact]
        public void DivideTwoNumbers_ShouldThrowDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(3, 0));
        }

        [Theory]
        [InlineData(new double[] { 2, 0 })]
        [InlineData(new double[] { 2, 6, 0, 9 })]
        [InlineData(new double[] { 2, 900, 1, 0 })]
        public void DivideMultipleNumbers_ShouldThrowDivideByZeroException(double[] numbers)
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(numbers));
        }

        [Theory]
        [MemberData(nameof(CalculatorClassData.TwoDoublesTestData), MemberType = typeof(CalculatorClassData))]
        [InlineData(6, 0)]
        public void ExponentationTwoNumbers(double nr1, double nr2)
        {
            Assert.Equal(Math.Pow(nr1, nr2), Calculator.ThePowerOf(nr1, nr2));
        }

        [Theory]
        [InlineData(new double[] { 2, 2 }, 4)]
        [InlineData(new double[] { 2, 2, 3 }, 64)]
        [InlineData(new double[] { 1 }, 1)]
        [InlineData(new double[] { 2, 9, 1}, 512)]
        public void ExponentationMultipleNumbers(double[] numbers, double expected)
        {
            Assert.Equal(expected, Calculator.ThePowerOf(numbers));
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(0.4, true)]
        [InlineData(6.0, false)]
        [InlineData(100.000001, true)]
        public void CheckIfNrIsDecimal(double nr, bool expected)
        {
            Assert.Equal(expected, Calculator.NumberIsADecimal(nr));
        }


    }

    public class CalculatorClassData
    {
        private static readonly List<object[]> AddTestInlineData = new List<object[]>
        {  new object[] { new double[] { 2, 3, 4 }, 9 },
           new object[] { new double[] { 2 }, 2 },
           new object[] { new double[] { 20.1, 3.5, 5 }, 28.6 },
           new object[] { new double[] { 1000, -1000, -1 }, -1 },
           new object[] { new double[] {5.2, 33.001, 1 }, 39.201 }
        };

        private static readonly List<object[]> SubtractTestInlineData = new List<object[]>
        {  new object[] { new double[] { 2, 3, 4 }, -5 },
           new object[] { new double[] { 2 }, 2 },
           new object[] { new double[] { 20.1, 3.5, 5 }, 11.6 },
           new object[] { new double[] { 1000, -1000, -1 }, 2001 },
           new object[] { new double[] {5.2, 33.001, 1 }, -28.801 }
        };

        private static readonly List<object[]> MultiplyTestInlineData = new List<object[]>
        {  new object[] { new double[] { 2, 3, 4 }, 24 },
           new object[] { new double[] { 2 }, 2 },
           new object[] { new double[] { 20.1, 3.5, 5 },  351.75},
           new object[] { new double[] { 1000, -1000, -1 }, 1000000 },
           new object[] { new double[] {5.2, 33.001, 1 }, 171.6052 }
        };

        private static readonly List<object[]> TwoDoubles = new List<object[]>
        {
            new object[] { 2, 3 },
            new object[] { -4, -4 },
            new object[] { -2, 3.2 },
            new object[] {0.46, 0.001},
            new object[] {1000.01, 0.00001}
        };

        public static IEnumerable<object[]> AddTestData => AddTestInlineData;
        public static IEnumerable<object[]> TwoDoublesTestData => TwoDoubles;
        public static IEnumerable<object[]> SubtractTestData => SubtractTestInlineData;
        public static IEnumerable<object[]> MultiplyTestData => MultiplyTestInlineData;

    }
}
