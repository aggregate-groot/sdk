using System;
using System.Threading.Tasks;
using AggregateGroot.CliCommands;
using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.CliCommands.Ignore.Definitions
{
    /// <summary>
    /// CLI command for adding Visual Studio paths to a .gitignore file.
    /// </summary>
    [Command("visual-studio", Description = "Ignore paths in the current repository for Visual Studio.")]
    public class VisualStudioCliCommand : CliCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="VisualStudioCliCommand" />.
        /// </summary>
        /// <param name="gitIgnoreFile">
        /// Required git ignore file to write the Visual Studio paths to.
        /// </param>
        public VisualStudioCliCommand(IGitIgnoreFile gitIgnoreFile)
        {
            ArgumentNullException.ThrowIfNull(gitIgnoreFile, nameof(gitIgnoreFile));
            _gitIgnoreFile = gitIgnoreFile;
        }

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            await _gitIgnoreFile.WriteLinesAsync(GitIgnoreCatalog.VisualStudio);

            return 0;
        }

        private readonly IGitIgnoreFile _gitIgnoreFile;
    }
}