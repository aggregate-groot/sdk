using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.Templating.CliCommands.TemplatePack;

namespace AggregateGroot.Templating.CliCommands
{
    /// <summary>
    /// Represents the root for template CLI commands.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "template", Description = "Root command for working with source templates.")]
    [Subcommand(
        typeof(TemplatePackCliCommand))]
    public class RootTemplateCliCommand : CliCommand
    {
        
    }
}