using System;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.Templating;

namespace AggregateGroot.Architecture.CliCommands.Workspace.Create
{
    /// <summary>
    /// CLI command for creating a new architecture workspace.
    /// </summary>
    [Command(Name = "create", Description = "Create a new architecture workspace.")]
    public class CreateCliCommand : InteractiveCliCommand
    {
        /// <inheritdoc />
        public CreateCliCommand(IConsole console, IPrompt prompt, ITemplateEngine templateEngine)
            : base(console, prompt)
        {
            _templateEngine = templateEngine 
                ?? throw new ArgumentNullException(nameof(templateEngine));
        }

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            await _templateEngine.RunAsync(new WorkspaceTemplate());
            return 1;
        }
        
        private readonly ITemplateEngine _templateEngine;
    }
}