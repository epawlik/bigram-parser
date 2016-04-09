namespace BigramParsingProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* NOTE: This isn't entirely necessary, but it helps to keep the separation
        * of the actual program logic from the simple setup tasks performed by Main().
       */

    public partial class Program
    {
        private IFileProcessor _fileProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        /// <param name="fileProcessor">The file processor.</param>
        public Program(IFileProcessor fileProcessor)
        {
            if (fileProcessor == null)
            {
                throw new ArgumentNullException(nameof(fileProcessor));
            }

            this._fileProcessor = fileProcessor;
        }

        /// <summary>
        /// Runs the bigram simulation.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void RunBigramSimulation(string filePath)
        {
            string text = this._fileProcessor.Process(filePath);
            IDictionary<string, int> histogram = BigramParser.ParseBigrams(text);
            PrintHistogram(histogram);
        }

        /// <summary>
        /// Prints the histogram to the console window.
        /// </summary>
        /// <param name="histogram">The histogram.</param>
        private static void PrintHistogram(IDictionary<string, int> histogram)
        {
            foreach (var item in histogram ?? Enumerable.Empty<KeyValuePair<string, int>>())
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
