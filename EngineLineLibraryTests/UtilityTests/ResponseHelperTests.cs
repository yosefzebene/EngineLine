using EngineLineLibrary.Vehicle.Helpers;
using FluentAssertions;

namespace EngineLineTests.UtilityTests
{
    public class ResponseHelperTests
    {
        [Fact]
        public void SingleLineResponseToHexArray_ShouldReturnStringArray_WhenProvidedWithString()
        {
            var inputString = "ff ff ff";
            var expected = new[] { "ff", "ff", "ff" };

            var result = ResponseHelper.SingleLineResponseToHexArray(inputString);

            result.Length.Should().Be(expected.Length);
            result.Should().Contain(expected);
        }

        [Fact]
        public void MultiLineResponseToHexArray_ShouldSepearateEachLineAndEachHexOnTheLine_WhenProvidedWithMultiLineString()
        {
            var inputString = "aa aa aa\r\nbb bb bb\r\ncc cc cc";
            var expected = new[]
            {
                new[] { "aa", "aa", "aa" },
                new[] { "bb", "bb", "bb" },
                new[] { "cc", "cc", "cc" }
            };

            var result = ResponseHelper.MultiLineResponseToHexArray(inputString);

            result.Length.Should().Be(expected.Length);
            result[0].Should().Contain(expected[0]);
            result[1].Should().Contain(expected[1]);
            result[2].Should().Contain(expected[2]);
        }

        [Fact]
        public void MultiLineResponseToHexArray_ShouldSepearateEachLineAndEachHexOnTheLine_WhenProvidedWithSingleLineString()
        {
            var inputString = "aa aa aa";
            var expected = new[]
            {
                new[] { "aa", "aa", "aa" }
            };

            var result = ResponseHelper.MultiLineResponseToHexArray(inputString);

            result.Length.Should().Be(expected.Length);
            result[0].Should().Contain(expected[0]);
        }

        [Fact]
        public void HexToBoolArray_ShouldConvertHexValuesToBoolArray_WhenProvidedWithAnArrayOfHexString()
        {
            var expected = new bool[16];
            expected[0] = true;
            for (int i = 1; i < expected.Length; i++)
                expected[i] = !expected[i-1];

            var inputString = new[] { "aa", "aa"};


            var result = ResponseHelper.HexToBoolArray(inputString);

            result.Length.Should().Be(expected.Length);
            result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
    }
}
