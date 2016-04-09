namespace BigramParsingProblem
{
    using System.IO;

    /// <summary>
    /// Implementation of the <see cref="IFileProcessor"/>
    /// used to process text files.
    /// </summary>
    public class TextFileProcessor : IFileProcessor
    {
        /// <summary>
        /// Processes the file at the specified path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>
        /// The string of text from the file.
        /// </returns>
        public string Process(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                /* NOTE: In a real app we'd probably want to throw an exception here.
                 *      For this simple app we'll just return an empty string and let
                 *      the bigram parser handle it.
                */
                return string.Empty;
            }

            if (!File.Exists(filePath))
            {
                /* NOTE: In a real app we'd probably want to throw an exception here.
                 *      For this simple app we'll just return an empty string and let
                 *      the bigram parser handle it.
                */
                return string.Empty;
            }

            // return the text of the file
            // NOTE: In a real app we'd want to wrap this in a try/catch for file IO errors
            return File.ReadAllText(filePath);
        }
    }
}
