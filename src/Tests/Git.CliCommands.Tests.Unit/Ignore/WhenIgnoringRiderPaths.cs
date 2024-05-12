using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.Git.CliCommands.Definitions;
using AggregateGroot.Git.Tools.GitIgnore;

namespace Git.CliCommands.Tests.Unit.Ignore
{
    /// <summary>
    /// Specifies the behavior when adding files to the ignore list for Rider.
    /// </summary>
    public class WhenIgnoringRiderPaths
    {
        /// <summary>
        /// Tests that the expected Rider paths are added to the .gitignore file.
        /// </summary>
        [Fact]
        public async Task Expected_Rider_Paths_Are_Added_To_GitIgnore()
        {
            IGitIgnoreFile gitIgnoreFile = Substitute.For<IGitIgnoreFile>();
            
            string[] capturedLines = [];
            
            await gitIgnoreFile.WriteLinesAsync(Arg.Do<string[]>(
                lines => capturedLines = lines
            ));
            
            RiderCliCommand command = new (gitIgnoreFile);
            await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.Multiple(() =>
                {
                    Assert.Contains("bin/", capturedLines);
                    Assert.Contains("obj/", capturedLines);
                    Assert.Contains(".idea/", capturedLines);
                }
            );
        }
    }
}