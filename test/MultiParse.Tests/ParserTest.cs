using Xunit;

namespace MultiParse.Tests
{
    public class ParserTest
    {
        [Theory]
        [InlineData("(3+cos(9.0f/2)*2f)/(3+2)", "0.515681680227688")]
        [InlineData("(3+sin(9.0f/2)*2)/(3+2)", "0.208987952933961")]
        [InlineData("3+sqrt(2)", "4.414213562373095")]
        public void TestSimple(string input, string output)
        {
            var e = new Expression();
            var result = e.Evaluate(input);
            var text = result.ToString().Replace(',', '.').Substring(0, 17);
            Assert.Equal(output, text);
        }
    }
}