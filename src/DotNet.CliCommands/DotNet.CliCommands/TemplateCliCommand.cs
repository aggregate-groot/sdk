using System;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.Templating;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands
{
    /// <summary>
    /// Base class for CLI commands that execute templates.
    /// </summary>
    public abstract class TemplateCliCommand : InteractiveCliCommand
    {
        /// <inheritdoc />
        /// <param name="templateEngine">
        /// Required type responsible for executing the template.
        /// </param>
        protected TemplateCliCommand(IConsole console, IPrompt prompt, ITemplateEngine templateEngine) 
            : base(console, prompt)
        {
            _templateEngine = templateEngine
                              ?? throw new ArgumentNullException(nameof(templateEngine));
        }

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            Prompt.PromptForAllOptions(this);

            ISourceTemplate template = BindSourceTemplate();

            await _templateEngine.RunAsync(template);
            
            return 1;
        }

        /// <summary>
        /// Binds the command options to a source template.
        /// </summary>
        protected abstract ISourceTemplate BindSourceTemplate();
        
        private readonly ITemplateEngine _templateEngine;
    }
}