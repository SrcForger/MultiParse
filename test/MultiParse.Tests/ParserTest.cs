using Xunit;

namespace MultiParse.Tests
{
    public class ParserTest
    {
        [Theory]
        [InlineData("(3+cos(9.0f/2)*2f)/(3+2)", "0.515681680227688")]
        public void TestSimple(string input, string output)
        {
            var e = new Expression();
            var result = e.Evaluate(input);
            var text = result.ToString().Replace(',', '.').Substring(0, 17);
            Assert.Equal(output, text);
        }
    }
}