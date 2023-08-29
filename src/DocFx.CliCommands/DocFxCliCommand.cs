using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.DocFx.CliCommands.NewProject;

namespace AggregateGroot.DocFx.CliCommands
{
    /// <summary>
    /// Represents the root for DocFx CLI commands.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "docfx", Description = "Root command for working with DocFx.")]
    [Subcommand(typeof(NewProjectCliCommand))]
    public class DocFxCliCommand : CliCommand
    {
        
    }
}