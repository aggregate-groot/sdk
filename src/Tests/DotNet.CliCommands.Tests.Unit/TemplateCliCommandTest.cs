using McMaster.Extensions.CommandLineUtils;
using NSubstitute;

using AggregateGroot.CliCommands;
using AggregateGroot.Templating;

namespace DotNet.CliCommands.Tests.Unit
{
    /// <summary>
    /// Base class for testing template CLI commands.
    /// </summary>
    public abstract class TemplateCliCommandTest
    {
        /// <summary>
        /// Gets the mock implementation of a console used for testing.
        /// </summary>
        protected IConsole Console { get; } = Substitute.For<IConsole>();

        /// <summary>
        /// Gets the mock implementation of a prompt used for testing.
        /// </summary>
        protected IPrompt Prompt { get; } = Substitute.For<IPrompt>();

        /// <summary>
        /// Gets the mock implementation of a template engine used for testing.
        /// </summary>
        protected ITemplateEngine TemplateEngine { get; } = Substitute.For<ITemplateEngine>();
    }
}