using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.Add.DirectoryBuildProperties;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.Add
{
    /// <summary>
    /// Represents the CLI command for adding new items to a project.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "add", Description = "Add an item to a .NET project.")]
    [Subcommand(typeof(DirectoryBuildPropertiesCliCommand))]
    public class AddCliCommand : CliCommand
    {
    }
}