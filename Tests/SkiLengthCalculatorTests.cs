using SkiMaster3000.Domain;
using SkiMaster3000.Services;
using Xunit;

namespace SkiMaster3000.Tests
{
    public class SkiLengthCalculatorTests
    {
        [Fact]
        public void Children_under_4_with_classic_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 3, length: 50, skistyle: SkiStyle.Classic, 
                expectedSkiLengthMax: 70, expectedSkiLengthMin: 70, expectedComment: "");
        }

        [Fact]
        public void Children_under_4_with_freestyle_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 3, length: 50, skistyle: SkiStyle.FreeStyle,
                expectedSkiLengthMax: 60, expectedSkiLengthMin: 65, expectedComment: "");
        }
        [Fact]
        public void Long_children_under_4_with_classic_ski_should_get_max_ski_length()
        {
            TestWithParameters(age: 3, length: 188, skistyle: SkiStyle.Classic,
                expectedSkiLengthMax: 207, expectedSkiLengthMin: 207, expectedComment: "Klassiska skidor tillverkas bara till längder upp till 207cm.");
        }

        [Fact]
        public void Children_between_5_and_8_with_classic_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 6, length: 80, skistyle: SkiStyle.Classic,
                expectedSkiLengthMax: 110, expectedSkiLengthMin: 120, expectedComment: "");
        }
        [Fact]
        public void Children_between_5_and_8_with_freestyle_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 6, length: 80, skistyle: SkiStyle.Classic,
                expectedSkiLengthMax: 100, expectedSkiLengthMin: 115, expectedComment: "");
        }

        private static void TestWithParameters(int age, int length, SkiStyle skistyle,
            int expectedSkiLengthMax, int expectedSkiLengthMin, string expectedComment)
        {
            var result = new SkiLengthCalculator().Calculate(age, length, skistyle);
            Assert.Equal(expectedSkiLengthMax, result.SkiLength.Max);
            Assert.Equal(expectedSkiLengthMin, result.SkiLength.Min);
            Assert.Equal(expectedComment, result.Comment);
        }
    }
}
