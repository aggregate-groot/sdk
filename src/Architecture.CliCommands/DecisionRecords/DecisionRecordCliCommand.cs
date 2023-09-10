using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Architecture.CliCommands.DecisionRecords.Create;
using AggregateGroot.CliCommands;

namespace AggregateGroot.Architecture.CliCommands.DecisionRecords
{
    /// <summary>
    /// Represents the command for working with architecture decision records.
    /// </summary>
    [Command(Name = "adr", Description = "Work with architecture decision records.")]
    [Subcommand(typeof(CreateDecisionRecordCliCommand))]
    public class DecisionRecordCliCommand : CliCommand
    {
    }
}