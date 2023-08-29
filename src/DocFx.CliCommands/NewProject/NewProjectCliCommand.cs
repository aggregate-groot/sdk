using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using AggregateGroot.CliCommands;
using AggregateGroot.Templating;
using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.DocFx.CliCommands.NewProject
{
    /// <summary>
    /// Represents the command for creating a new DocFx project.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command(Name = "new-project", Description = "Creates a new DocFx project.")]
    public class NewProjectCliCommand : InteractiveCliCommand
    {
        /// <inheritdoc />
        public NewProjectCliCommand(IConsole console, IPrompt prompt, ITemplateEngine templateEngine) 
            : base(console, prompt)
        {
            _templateEngine = templateEngine 
                ?? throw new ArgumentNullException(nameof(templateEngine));
        }

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            NewProjectTemplate template = new();

            await _templateEngine.RunAsync(template);
            
            return 1;
        }

        private readonly ITemplateEngine _templateEngine;
    }
}