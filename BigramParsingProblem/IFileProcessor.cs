namespace BigramParsingProblem
{
    /// <summary>
    /// Simple interface for a class that can process a file.
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Processes the file at the specified path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The string of text from the file.</returns>
        string Process(string filePath);
    }
}

