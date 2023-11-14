using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Architecture.CliCommands.Workspace.Create;
using AggregateGroot.Architecture.CliCommands.Workspace.ExportDiagrams;
using AggregateGroot.CliCommands;

namespace AggregateGroot.Architecture.CliCommands.Workspace
{
    /// <summary>
    /// Represents the command for working with architecture workspaces.
    /// </summary>
    [Command(Name = "workspace", Description = "Work with architecture workspaces.")]
    [Subcommand(typeof(CreateCliCommand))]
    [Subcommand(typeof(ExportDiagramsCliCommand))]
    public class WorkspaceCliCommand : CliCommand
    {
    }
}