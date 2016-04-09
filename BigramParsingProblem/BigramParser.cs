namespace BigramParsingProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parse bigrams from a string of text, and return
    /// a histogram of the bigrams.
    /// </summary>
    public static class BigramParser
    {
        /// <summary>
        /// Parses the bigrams from the <paramref name="text"/>.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>The histogram of the bigrams in the text.</returns>
        /// <remarks>
        /// One thing to note with this implementation is that we consider
        /// numbers (or a string of numbers) to be a word.  This may be incorrect,
        /// but given the requirements it was not entirely clear how they should
        /// be handled.  In a real project that would be a question that I would
        /// ask to clarify things.
        /// </remarks>
        public static IDictionary<string, int> ParseBigrams(string text)
        {
            // if the text is null or empty, just return an empty histogram (dictionary)
            if (string.IsNullOrWhiteSpace(text))
            {
                return new Dictionary<string, int>(0);
            }

            // simple array containing valid english punctuation characters
            char[] punctuation = new char[]{
                '.', '?', '!', ',', ':', ';', '-', '[', ']', '{', '}', '(', ')', '"', '\'', '\r', '\n'
            };

            // split the string into individual words
            string[] words = (from word in text.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                              let cleanedWord = word.Trim(punctuation).ToLowerInvariant()
                              where !string.IsNullOrWhiteSpace(cleanedWord)
                              select cleanedWord)
                              .ToArray();

            // if there are less than 2 words in the string we can just return an empty histogram
            if (words.Length <= 1)
            {
                return new Dictionary<string, int>(0);
            }

            // create the dictionary for our results
            IDictionary<string, int> results = new Dictionary<string, int>();

            // loop through the array of words
            int arrayEndingIndex = words.Length - 1;
            for (int i = 0; i < arrayEndingIndex; i++)
            {
                string bigramPair = words[i] + " " + words[i + 1];
                if (results.ContainsKey(bigramPair))
                {
                    results[bigramPair]++;
                }
                else
                {
                    results.Add(bigramPair, 1);
                }
            }

            return results;
        }
    }
}
