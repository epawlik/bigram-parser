namespace BigramParsingProblem.Tests
{
    using System.Collections.Generic;
    using Xunit;

    /// <summary>
    /// Tests for the Bigram Parser.
    /// </summary>
    public class BigramParserTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Should_Return_Empty_Dictionary_When_Null_Or_Empty_Argument_Provided(string text)
        {
            // act
            IDictionary<string, int> result = BigramParser.ParseBigrams(text);

            // assert
            Assert.Empty(result);
        }

        [Theory]
        // single words cannot create a bigram
        [InlineData("singleWord")]
        // strings of punctuation cannot be considered a word
        [InlineData(".? ! , :;- [] {} () \"")]
        public void Should_Return_Empty_Dictionary_When_Invalid_Text_Argument_Provided(string text)
        {
            // act
            IDictionary<string, int> result = BigramParser.ParseBigrams(text);

            // assert
            Assert.Empty(result);
        }

        [Theory]
        // single line of data should be good
        [InlineData("The quick brown fox and the quick blue hare.")]
        // multiple lines of data should be good
        [InlineData("The quick brown fox\r\nand the quick blue hare.")]
        public void Should_Return_Histogram_When_Good_Text_Is_Provided(string text)
        {
            // act
            IDictionary<string, int> result = BigramParser.ParseBigrams(text);

            // assert
            VerifyQuickBrownFoxResultsAreAsExpected(result);
        }

        [Theory]
        // single line of data should be good
        [InlineData("The (quick) 'brown' [fox] {and} \"\" the, quick blue hare.")]
        // multiple lines of data should be good
        [InlineData("The \"quick\" brown fox\r\nand the (quick) blue hare.")]
        public void Should_Return_Histogram_When_Good_Text_With_Punctuation_Is_Provided(string text)
        {
            // act
            IDictionary<string, int> result = BigramParser.ParseBigrams(text);

            // assert
            VerifyQuickBrownFoxResultsAreAsExpected(result);
        }

        /// <summary>
        /// Verifies the quick brown fox results are as expected.
        /// Simple method to remove some duplicated logic from the tests
        /// </summary>
        /// <param name="result">The result.</param>
        private static void VerifyQuickBrownFoxResultsAreAsExpected(IDictionary<string, int> result)
        {
            Assert.Equal(7, result.Count);
            Assert.Collection(
                result,
                item =>
                {
                    Assert.Equal("the quick", item.Key);
                    Assert.Equal(2, item.Value);
                },
                item =>
                {
                    Assert.Equal("quick brown", item.Key);
                    Assert.Equal(1, item.Value);
                },
                item =>
                {
                    Assert.Equal("brown fox", item.Key);
                    Assert.Equal(1, item.Value);
                },
                item =>
                {
                    Assert.Equal("fox and", item.Key);
                    Assert.Equal(1, item.Value);
                },
                item =>
                {
                    Assert.Equal("and the", item.Key);
                    Assert.Equal(1, item.Value);
                },
                item =>
                {
                    Assert.Equal("quick blue", item.Key);
                    Assert.Equal(1, item.Value);
                },
                item =>
                {
                    Assert.Equal("blue hare", item.Key);
                    Assert.Equal(1, item.Value);
                });
        }
    }
}
