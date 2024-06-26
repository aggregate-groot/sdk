﻿using System;
using System.Threading.Tasks;
using AggregateGroot.CliCommands;
using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.CliCommands.Ignore.Definitions
{
    /// <summary>
    /// CLI command to ignore paths in the current repository for Jet Brains Rider.
    /// </summary>
    [Command("rider", Description = "Ignore paths in the current repository for Rider.")]
    public class RiderCliCommand : CliCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="RiderCliCommand" />.
        /// </summary>
        /// <param name="gitIgnoreFile">
        /// Required git ignore file to write the Rider paths to.
        /// </param>
        public RiderCliCommand(IGitIgnoreFile gitIgnoreFile)
        {
            ArgumentNullException.ThrowIfNull(gitIgnoreFile, nameof(gitIgnoreFile));
            _gitIgnoreFile = gitIgnoreFile;
        }
        
        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            await _gitIgnoreFile.WriteLinesAsync(GitIgnoreCatalog.Rider);

            return 0;
        }
        
        private readonly IGitIgnoreFile _gitIgnoreFile;
    }
}