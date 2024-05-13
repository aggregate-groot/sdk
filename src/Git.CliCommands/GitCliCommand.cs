using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.Git.CliCommands.Ignore;

namespace AggregateGroot.Git.CliCommands
{
    /// <summary>
    /// Root command for interacting with Git.
    /// </summary>
    [Command("git", Description = "Wraps specialized git commands.")]
    [Subcommand(typeof(GitIgnoreCliCommand))]
    public class GitCliCommand : CliCommand
    {
    }
}