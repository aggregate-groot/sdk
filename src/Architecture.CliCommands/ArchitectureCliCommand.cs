using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Architecture.CliCommands.DecisionRecords;
using AggregateGroot.Architecture.CliCommands.Workspace;
using AggregateGroot.CliCommands;

namespace AggregateGroot.Architecture.CliCommands
{
    /// <summary>
    /// Represents the root for architecture CLI commands.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "architecture", Description = "Root command for working with architecture tasks.")]
    [Subcommand(
        typeof(WorkspaceCliCommand),
        typeof(DecisionRecordCliCommand))]
    public class ArchitectureCliCommand : CliCommand
    {
    
    }
}