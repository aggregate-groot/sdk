using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.Templating.CliCommands.DotNetNew;

namespace AggregateGroot.Templating.CliCommands.Tests.Unit.DotNetNew
{
    /// <summary>
    /// Verifies the behavior when creating a 'dotnet new' template from the command line.
    /// </summary>
    public class WhenCreatingDotNetNewTemplate : TemplateCliCommandTest
    {
        /// <summary>
        /// Tests that the command line arguments are supplied to the template.
        /// </summary>
        [Fact]
        public async Task Template_Arguments_Are_Supplied_To_Template()
        {
            DotNetNewCliCommand command = new(
                Console,
                Prompt,
                TemplateEngine)
            {
                Author = "Some Author",
                Classification = "Classy",
                Identity = "Some.Template",
                ShortName = "s-t",
                Type = "item",
                TemplateName = "SomeFakeTemplate"
            };

            DotNetNewTemplate? template = null;
            
            TemplateEngine
                .RunAsync(
                    Arg.Do<DotNetNewTemplate>(t => template = t))
                .Returns(Task.CompletedTask);
            
            await command.OnExecuteAsync(new CommandLineApplication());

            Assert.NotNull(template);
            Assert.Equal("ag-dotnet-new-template", template.Name);
            Assert.Equal(command.Author, template.Author);
            Assert.Equal(command.Classification, template.Classification);
            Assert.Equal(command.Identity, template.Identity);
            Assert.Equal(command.ShortName, template.ShortName);
            Assert.Equal(command.TemplateName, template.TemplateName);
            Assert.Equal(command.Type, template.Type);
        }
    }
}