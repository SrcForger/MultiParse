using System;
using Xunit;

namespace MultiParse.Tests
{
    public class ParserTest
    {
        [Theory]
        [InlineData("(3+cos(9.0f/2)*2f)/(3+2)", "0.515681680227688")]
        [InlineData("(3+sin(9.0f/2)*2)/(3+2)", "0.208987952933961")]
        [InlineData("3+sqrt(2)", "4.414213562373095")]
        [InlineData("true", "True")]
        [InlineData("false", "False")]
        [InlineData("(byte)3+(sbyte)5+(char)65", "73")]
        [InlineData("(long)51+(long)634", "685")]
        [InlineData("(ulong)151*(ulong)61", "9211")]
        [InlineData("(short)1+(ushort)2+(int)3+(uint)4+(decimal)7", "17")]
        public void TestSimple(string input, string output)
        {
            var e = new Expression();
            var result = e.Evaluate(input);
            var text = result.ToString();
            text = text?.Replace(',', '.').Substring(0, Math.Min(text.Length, 17));
            Assert.Equal(output, text);
        }
    }
}