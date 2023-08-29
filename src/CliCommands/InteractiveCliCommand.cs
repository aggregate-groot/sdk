using System;
using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliCommands
{
    /// <summary>
    /// Base class for interactive CLI commands.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class InteractiveCliCommand : CliCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="InteractiveCliCommand"/> class.
        /// </summary>
        /// <param name="console">
        /// Required type responsible for console input and output.
        /// </param>
        /// <param name="prompt">
        /// Required type responsible for prompting the user for input.
        /// </param>
        protected InteractiveCliCommand(
            IConsole console,
            IPrompt prompt)
        {
            Console = console 
                ?? throw new ArgumentNullException(nameof(console));
            Prompt = prompt 
                ?? throw new ArgumentNullException(nameof(prompt));
        }
        
        /// <summary>
        /// Gets the console provided for this command.
        /// </summary>
        protected IConsole Console { get; }
        
        /// <summary>
        /// Gets the prompt provided for this command.
        /// </summary>
        protected IPrompt Prompt { get; }
    }
}