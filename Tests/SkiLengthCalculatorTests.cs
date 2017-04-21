using Xunit;

namespace SkiMaster3000.Tests
{
    public class SkiLengthCalculatorTests
    {
        [Theory]
        [InlineData(TestData.Barn0_4, TestData.L‰ngdUnderMax, TestData.Fristil)]
        public void Should_calculate_correct_ski_length()
        {

        }

        static class TestData
        {
            public const int Barn0_4 = 4;
            public const int Barn5_8 = 5;
            public const string Klassisk = "Klassisk";
            public const string Fristil = "Fristil";
            public const int L‰ngdUnderMax = 206;
            public const int L‰ngd÷verMax = 208;
        }
    }
}
