using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.Git.CliCommands.Ignore.Definitions;

namespace AggregateGroot.Git.CliCommands.Ignore
{
    /// <summary>
    /// CLI command to ignore files in the current repository.
    /// </summary>
    [Command("ignore", Description = "Ignore paths in the current repository.")]
    [Subcommand(typeof(RiderCliCommand))]
    [Subcommand(typeof(VisualStudioCliCommand))]
    [Subcommand(typeof(StructurizrCliCommand))]
    public class GitIgnoreCliCommand : CliCommand
    {
        
    }
}