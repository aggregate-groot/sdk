using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.New.AspNet;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.New
{
    /// <summary>
    /// Represents the CLI command for creating a new .NET project.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "new", Description = "Create a new .NET project.")]
    [Subcommand(typeof(AspNetProjectCliCommand))]
    public class NewCliCommand : CliCommand
    {
    }
}