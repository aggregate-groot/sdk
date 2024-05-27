using System;
using System.Threading.Tasks;
using AggregateGroot.CliCommands;

using AggregateGroot.Git.Tools.GitIgnore;
using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Git.CliCommands.Ignore.Definitions
{
    /// <summary>
    /// CLI command for adding Structurizr paths to a .gitignore file.
    /// </summary>
    [Command("structurizr", Description = "Ignore paths in the current repository for Structurizr.")]
    public class StructurizrCliCommand : CliCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="StructurizrCliCommand" />.
        /// </summary>
        /// <param name="gitIgnoreFile">
        /// Required git ignore file to write the Structurizr paths to.
        /// </param>
        public StructurizrCliCommand(IGitIgnoreFile gitIgnoreFile)
        {
            ArgumentNullException.ThrowIfNull(gitIgnoreFile, nameof(gitIgnoreFile));
            _gitIgnoreFile = gitIgnoreFile;
        }

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            await _gitIgnoreFile.WriteLinesAsync(GitIgnoreCatalog.Structurizr);
            return 0;
        }

        private readonly IGitIgnoreFile _gitIgnoreFile;
    }
}