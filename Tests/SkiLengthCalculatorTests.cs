using System;
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
                expectedSkiLengthMin: 70, expectedSkiLengthMax: 70, expectedComment: "");
        }

        [Fact]
        public void Children_under_4_with_freestyle_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 3, length: 50, skistyle: SkiStyle.FreeStyle,
                expectedSkiLengthMin: 60, expectedSkiLengthMax: 65, 
                expectedComment: "Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.");
        }
        [Fact]
        public void Long_children_under_4_with_classic_ski_should_get_max_ski_length()
        {
            TestWithParameters(age: 3, length: 188, skistyle: SkiStyle.Classic,
                expectedSkiLengthMin: 207, expectedSkiLengthMax: 207, 
                expectedComment: "Klassiska skidor tillverkas bara till längder upp till 207cm.");
        }

        [Fact]
        public void Children_between_5_and_8_with_classic_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 6, length: 80, skistyle: SkiStyle.Classic,
                expectedSkiLengthMin: 110, expectedSkiLengthMax: 120, expectedComment: "");
        }
        [Fact]
        public void Children_between_5_and_8_with_freestyle_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 6, length: 80, skistyle: SkiStyle.FreeStyle,
                expectedSkiLengthMin: 100, expectedSkiLengthMax: 115, 
                expectedComment: "Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.");
        }
        [Fact]
        public void Long_children_between_5_and_8_with_classic_ski_should_get_ski_length_max()
        {
            TestWithParameters(age: 6, length: 168, skistyle: SkiStyle.Classic,
                expectedSkiLengthMin: 198, expectedSkiLengthMax: 207, 
                expectedComment: "Klassiska skidor tillverkas bara till längder upp till 207cm.");
        }
        [Fact]
        public void Even_longer_children_between_5_and_8_with_classic_ski_should_get_ski_length_min_and_max()
        {
            TestWithParameters(age: 6, length: 178, skistyle: SkiStyle.Classic,
                expectedSkiLengthMin: 207, expectedSkiLengthMax: 207, 
                expectedComment: "Klassiska skidor tillverkas bara till längder upp till 207cm.");
        }
        [Fact]
        public void People_over_8_with_classic_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 50, length: 180, skistyle: SkiStyle.Classic,
                expectedSkiLengthMin: 200, expectedSkiLengthMax: 200, expectedComment: "");
        }
        [Fact]
        public void People_over_8_with_freestyle_ski_should_get_correct_ski_length()
        {
            TestWithParameters(age: 50, length: 180, skistyle: SkiStyle.FreeStyle,
                expectedSkiLengthMin: 190, expectedSkiLengthMax: 195, 
                expectedComment: "Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.");
        }
        [Fact]
        public void Long_people_over_8_with_classic_ski_should_get_correct_ski_length_max()
        {
            TestWithParameters(age: 50, length: 215, skistyle: SkiStyle.Classic,
                expectedSkiLengthMin: 207, expectedSkiLengthMax: 207,
                expectedComment: "Klassiska skidor tillverkas bara till längder upp till 207cm.");
        }

        [Fact]
        public void Years_below_0_should_throw_exception()
        {
            Assert.Throws<ArgumentException>(
                () => new SkiLengthCalculator().Calculate(-1, 50, SkiStyle.Classic));
        }
        [Fact]
        public void Age_below_0_should_throw_exception()
        {
            Assert.Throws<ArgumentException>(
                () => new SkiLengthCalculator().Calculate(5, -1, SkiStyle.Classic));
        }
        private static void TestWithParameters(int age, int length, SkiStyle skistyle,
            int expectedSkiLengthMin, int expectedSkiLengthMax, string expectedComment)
        {
            var result = new SkiLengthCalculator().Calculate(age, length, skistyle);
            Assert.Equal(expectedSkiLengthMin, result.SkiLength.Min);
            Assert.Equal(expectedSkiLengthMax, result.SkiLength.Max);
            Assert.Equal(expectedComment, result.Comment);
        }
    }
}
