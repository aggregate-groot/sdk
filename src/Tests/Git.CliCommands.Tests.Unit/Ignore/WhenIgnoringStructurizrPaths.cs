using NSubstitute;
using Xunit;
using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Git.CliCommands.Ignore.Definitions;
using AggregateGroot.Git.Tools.GitIgnore;

namespace Git.CliCommands.Tests.Unit.Ignore
{
    /// <summary>
    /// Specifies the behavior when ignoring Structurizr paths.
    /// </summary>
    public class WhenIgnoringStructurizrPaths
    {
        /// <summary>
        /// Tests that the expected Structurizr paths are written to the .gitignore file.
        /// </summary>
        [Fact]
        public async Task Expected_Structurizr_Paths_Are_Written_To_GitIgnore()
        {
            IGitIgnoreFile gitIgnoreFile = Substitute.For<IGitIgnoreFile>();

            string[] capturedLines = [];

            await gitIgnoreFile.WriteLinesAsync(Arg.Do<string[]>(
                lines => capturedLines = lines
            ));

            StructurizrCliCommand command = new(gitIgnoreFile);
            await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.Contains(".structurizr/", capturedLines);
        }
    }
}