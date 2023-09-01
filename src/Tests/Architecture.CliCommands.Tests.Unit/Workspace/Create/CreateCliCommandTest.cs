using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.Architecture.CliCommands.Workspace.Create;
using AggregateGroot.CliCommands;
using AggregateGroot.Templating;

namespace AggregateGroot.Architecture.CliCommands.Tests.Unit.Workspace.Create
{
    /// <summary>
    /// Unit tests for the <see cref="CreateCliCommand" /> class.
    /// </summary>
    public class CreateCliCommandTest
    {
        /// <summary>
        /// Tests that passing a null templateEngine argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Constructor_Should_Validate_Template_Engine()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new CreateCliCommand(Substitute.For<IConsole>(), Substitute.For<IPrompt>(), null!));

            Assert.Equal("templateEngine", exception.ParamName);
        }
        
        /// <summary>
        /// Tests that the docfx project template is invoked in the template engine.
        /// </summary>
        [Fact]
        public async Task Should_Invoke_DocFx_Project_Template()
        {
            ITemplateEngine templateEngine = Substitute.For<ITemplateEngine>();
            CreateCliCommand command = new (
                Substitute.For<IConsole>(),
                Substitute.For<IPrompt>(),
                templateEngine);
            
            WorkspaceTemplate? template = null;

            await templateEngine
                .RunAsync(Arg.Do<WorkspaceTemplate>(captured => template = captured));
   
            await command.OnExecuteAsync(new CommandLineApplication());

            Assert.NotNull(template);
            Assert.Equal("ag-architecture-workspace", template.Name);
        }
    }
}