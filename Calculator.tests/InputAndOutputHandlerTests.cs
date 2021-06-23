using Xunit;

namespace Calculator.tests
{
    public class InputAndOutputHandlerTests
    {
        private readonly InputAndOutputHandler sut;
        public InputAndOutputHandlerTests()
        {
            sut = new InputAndOutputHandler();
        }

        [Theory]
        [InlineData("6", true)]
        [InlineData("7,4", true)]
        [InlineData("0.0002", false)]
        [InlineData("0,0002", true)]
        [InlineData("G", false)]
        [InlineData("7.", false)]
        [InlineData("-", false)]
        [InlineData(" ", false)]
        public void RegexTest(string input, bool expected)
        {
            Assert.Equal(expected, sut.InputIsValidNumber(input));
        }
    }
}
