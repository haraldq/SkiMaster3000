using SkiMaster3000.Domain;
using SkiMaster3000.Services;
using Xunit;

namespace SkiMaster3000.Tests
{
    public class SkiLengthCalculatorTests
    {
        [Theory]
        [InlineData(TestData.Barn0_4, TestData.L‰ngdUnderMax, SkiStyle.FreeStyle, TestData.L‰ngdUnderMax, TestData.L‰ngdUnderMax, "")]
        public void Should_calculate_correct_ski_length(string age, string length, SkiStyle skistyle,
            int expectedSkiLengthMax, int expectedSkiLengthMin, string expectedComment)
        {
            var result = new SkiLengthCalculator().Calculate(age, length, skistyle);
            Assert.Equal(expectedSkiLengthMax, result.SkiLength.Max);
            Assert.Equal(expectedSkiLengthMin, result.SkiLength.Min);
            Assert.Equal(expectedComment, result.Comment);
        }

        static class TestData
        {
            public const int Barn0_4 = 4;
            public const int Barn5_8 = 5;
            public const int L‰ngdUnderMax = 206;
            public const int L‰ngd÷verMax = 208;
        }
    }
}
