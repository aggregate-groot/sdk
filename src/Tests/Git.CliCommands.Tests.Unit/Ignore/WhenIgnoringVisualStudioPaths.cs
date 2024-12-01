using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.Git.CliCommands.Ignore.Definitions;
using AggregateGroot.Git.Tools.GitIgnore;

namespace Git.CliCommands.Tests.Unit.Ignore
{
    /// <summary>
    /// Specifies the behavior when ignoring Visual Studio paths.
    /// </summary>
    public class WhenIgnoringVisualStudioPaths
    {
        /// <summary>
        /// Tests that the expected Visual Studio paths are added to the .gitignore file.
        /// </summary>
        [Fact]
        public async Task Expected_VisualStudio_Paths_Are_Added_To_GitIgnore()
        {
            
            IGitIgnoreFile gitIgnoreFile = Substitute.For<IGitIgnoreFile>();
            
            string[] capturedLines = [];
            
            await gitIgnoreFile.WriteLinesAsync(Arg.Do<string[]>(
                lines => capturedLines = lines
            ));
            
            VisualStudioCliCommand command = new (gitIgnoreFile);
            await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.Multiple(() =>
                {
                    Assert.Contains("bin/", capturedLines);
                    Assert.Contains("obj/", capturedLines);
                    Assert.Contains(".vs/", capturedLines);
                }
            );
        }
    }
}