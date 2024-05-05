using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;

namespace AggregateGroot.Git.CliCommands
{
    /// <summary>
    /// Root command for interacting with Git.
    /// </summary>
    [Command("git", Description = "Wraps specialized git commands.")]
    public class GitCliCommand : CliCommand
    {
    }
}