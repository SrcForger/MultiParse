using System;
using Xunit;

namespace MultiParse.Tests
{
    public class ParserTest
    {
        [Theory]
        [InlineData("(3+cos(9.0f/2)*2f)/(3+2)", "0.51568168022768")]
        [InlineData("(3+sin(9.0f/2)*2)/(3+2)", "0.20898795293396")]
        [InlineData("3+sqrt(2)", "4.41421356237309")]
        [InlineData("true", "True")]
        [InlineData("false", "False")]
        [InlineData("(byte)3+(sbyte)5+(char)65", "73")]
        [InlineData("(long)51+(long)634", "685")]
        [InlineData("(ulong)151*(ulong)61", "9211")]
        [InlineData("(short)1+(ushort)2+(int)3+(uint)4+(decimal)7", "17")]
        [InlineData("\"Hello World\"", "Hello World")]
        [InlineData("(float)51/(double)634", "0.08044164037854")]
        [InlineData("(1.78+2.6)-(4.3*6.1)/(7%8.2)", "0.63285714285714")]
        [InlineData("24<=848", "True")]
        [InlineData("24>=848", "False")]
        [InlineData("24<848", "True")]
        [InlineData("24>848", "False")]
        [InlineData("24==848", "False")]
        [InlineData("24!=848", "True")]
        public void TestSimple(string input, string output)
        {
            var e = new Expression();
            var result = e.Evaluate(input);
            var text = result.ToString();
            text = text?.Replace(',', '.').Substring(0, Math.Min(text.Length, 16));
            Assert.Equal(output, text);
        }
    }
}