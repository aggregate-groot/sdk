using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.CliCommands;
using AggregateGroot.DocFx.CliCommands.NewProject;
using AggregateGroot.Templating;

namespace AggregateGroot.DocFx.CliCommands.Tests.Unit.NewProject
{
    /// <summary>
    /// Unit tests for the <see cref="NewProjectCliCommand" /> class.
    /// </summary>
    public class NewProjectCliCommandTest
    {
        /// <summary>
        /// Tests that passing a null templateEngine argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Constructor_Should_Validate_Template_Enginen()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new NewProjectCliCommand(Substitute.For<IConsole>(), Substitute.For<IPrompt>(), null!));

            Assert.Equal("templateEngine", exception.ParamName);
        }
        
        /// <summary>
        /// Tests that the docfx project template is invoked in the template engine.
        /// </summary>
        [Fact]
        public async Task Should_Invoke_DocFx_Project_Template()
        {
            ITemplateEngine templateEngine = Substitute.For<ITemplateEngine>();
            NewProjectCliCommand command = new (
                Substitute.For<IConsole>(),
                Substitute.For<IPrompt>(),
                templateEngine);
            
            NewProjectTemplate? template = null;

            await templateEngine
                .RunAsync(Arg.Do<NewProjectTemplate>(captured => template = captured));
   
            await command.OnExecuteAsync(new CommandLineApplication());

            Assert.NotNull(template);
            Assert.Equal("ag-docfx-project", template.Name);
        }
    }
}