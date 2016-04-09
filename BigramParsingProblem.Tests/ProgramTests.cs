namespace BigramParsingProblem.Tests
{
    using NSubstitute;
    using System;
    using Xunit;

    /// <summary>
    /// Tests for the program class.
    /// </summary>
    public class ProgramTests
    {
        /// <summary>
        /// Tests for the Main method.
        /// </summary>
        public class MainTests
        {
            [Fact]
            public void Should_Return_InvalidArguments_ExitCode_When_Null_Arguments_Provided()
            {
                // arrange
                string[] args = null;

                // act
                ExitCode actualExitCode = (ExitCode)Program.Main(args);

                // assert
                Assert.Equal(ExitCode.InvalidArguments, actualExitCode);
            }

            [Fact]
            public void Should_Return_InvalidArguments_ExitCode_When_Empty_Arguments_Provided()
            {
                // arrange
                string[] args = new string[] { };

                // act
                ExitCode actualExitCode = (ExitCode)Program.Main(args);

                // assert
                Assert.Equal(ExitCode.InvalidArguments, actualExitCode);
            }

            [Fact]
            public void Should_Return_InvalidArguments_ExitCode_When_Blank_File_Path_Provided()
            {
                // arrange
                string[] args = new string[] { "" };

                // act
                ExitCode actualExitCode = (ExitCode)Program.Main(args);

                // assert
                Assert.Equal(ExitCode.InvalidArguments, actualExitCode);
            }

            [Fact]
            public void Should_Return_InvalidArguments_ExitCode_When_Invalid_File_Path_Provided()
            {
                // arrange
                string[] args = new string[] { "c:/testFilePath/fileName.ext" };

                // act
                ExitCode actualExitCode = (ExitCode)Program.Main(args);

                // assert
                Assert.Equal(ExitCode.InvalidArguments, actualExitCode);
            }
        }

        /// <summary>
        /// Tests for the program constructor.
        /// </summary>
        public class ConstructorTests
        {
            [Fact]
            public void Should_Throw_ArgumentNullException_With_Null_Argument()
            {
                // arrange
                IFileProcessor arg = null;

                // act and assert
                Assert.Throws<ArgumentNullException>(() => new Program(arg));
            }

            [Fact]
            public void Should_Complete_When_Valid_Arguments_Provided()
            {
                // arrange
                IFileProcessor processor = Substitute.For<IFileProcessor>();

                // act
                var program = new Program(processor);

                // assert
                Assert.NotNull(program);
            }
        }
    }
}
