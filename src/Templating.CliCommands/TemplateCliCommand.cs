using System;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;

namespace AggregateGroot.Templating.CliCommands
{
    /// <summary>
    /// Base class for CLI commands that provide templating.
    /// </summary>
    public abstract class TemplateCliCommand : InteractiveCliCommand
    {
        /// <inheritdoc />
        /// <param name="console">
        /// Required type responsible for console input and output.
        /// </param>
        /// <param name="prompt">
        /// Required type responsible for prompting the user for input.
        /// </param>
        /// <param name="templateEngine">
        /// Required type used to generate the template output.
        /// </param>
        protected TemplateCliCommand(
            IConsole console,
            IPrompt prompt,
            ITemplateEngine templateEngine) 
            : base(console, prompt)
        {
            ArgumentNullException.ThrowIfNull(templateEngine, nameof(templateEngine));
            TemplateEngine = templateEngine;
        }
        
        protected ITemplateEngine TemplateEngine { get; }
    }
}