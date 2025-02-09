using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands
{
    /// <summary>
    /// Represents the root for architecture CLI commands.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "dotnet", Description = "Root command for working with .NET tasks.")]
    [Subcommand(typeof(ProjectCliCommand))]
    public class DotNetRootCliCommand : CliCommand
    {
    }
}