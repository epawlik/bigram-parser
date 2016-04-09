namespace BigramParsingProblem
{
    /// <summary>
    /// Enumeration defining exit codes for the application.
    /// </summary>
    public enum ExitCode : int
    {
        /// <summary>
        /// The program ran successfully and is terminating normally.
        /// </summary>
        Success = 0,

        /// <summary>
        /// Invalid arguments were supplied.
        /// </summary>
        InvalidArguments = 1,

        /// <summary>
        /// Unknown result for the program
        /// </summary>
        Unknown = 3
    }
}
