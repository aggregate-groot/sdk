using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;

namespace AggregateGroot.DocFx.CliCommands
{
    /// <summary>
    /// Represents the root for DocFx CLI commands.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "docfx", Description = "Root command for working with DocFx.")]
    public class DocFxCliCommand : CliCommand
    {
        
    }
}