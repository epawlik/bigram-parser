namespace BigramParsingProblem
{
    using System;
    using System.IO;

    public partial class Program
    {
        /// <summary>
        /// Entry point for the program.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>An exit code defining why the program ended.</returns>
        public static int Main(string[] args)
        {
            string filePath = args == null || args.Length <= 0 ? null : args[0];
            if (!IsValidFilePath(filePath))
            {
                Console.WriteLine();
                Console.WriteLine("Usage: BigramParsingProglem 'absolute/path/to/file'");
                Console.WriteLine();
                return (int)ExitCode.InvalidArguments;
            }

            try
            {
                // run the program
                /* NOTE: In a real program we'd probably want to use
                 *      the factory and/or strategy patterns to determine the
                 *      correct method for processing the file.  For this simple
                 *      excercise we know the file will be a text file, as specified
                 *      in the requirements
                */
                IFileProcessor processor = new TextFileProcessor();
                var program = new Program(processor);
                program.RunBigramSimulation(filePath);
            }
            catch (Exception ex)
            {
                // for this simple excercise we'll just write out the exception to the console
                Console.WriteLine(ex.ToString());

                // something went wrong.
                return (int)ExitCode.Unknown;
            }

            return (int)ExitCode.Success;
        }

        /// <summary>
        /// Determines whether the file path provided
        /// is a valid path for the program.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <returns><c>true</c> if the file is valid; otherwise, <c>false</c>.</returns>
        private static bool IsValidFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine(string.Format("The file path \"{0}\" is invalid.", filePath));
                return false;
            }

            string extension = Path.GetExtension(filePath);
            if (string.IsNullOrWhiteSpace(extension) ||
                !extension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(string.Format("The file should be a file with the \".txt\" extension. The file extension \"{0}\" is invalid.", extension));
                return false;
            }

            return true;
        }
    }
}
