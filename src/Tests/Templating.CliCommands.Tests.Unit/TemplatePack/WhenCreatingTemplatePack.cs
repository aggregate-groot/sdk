using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.Templating.CliCommands.TemplatePack;

namespace AggregateGroot.Templating.CliCommands.Tests.Unit.TemplatePack
{
    /// <summary>
    /// Verifies the behavior when creating a template pack from the command line.
    /// </summary>
    public class WhenCreatingTemplatePack : TemplateCliCommandTest
    {
        /// <summary>
        /// Tests that the command line arguments are supplied to the template.
        /// </summary>
        [Fact]
        public async Task Template_Arguments_Are_Supplied_To_Template()
        {
            TemplatePackCliCommand command = new(
                Console,
                Prompt,
                TemplateEngine)
            {
                Author = "Some Author",
                PackageId = "Some.Template.Pack",
                Title = "Some Template Pack",
                Description = "THis is some template pack."
            };

            TemplatePackTemplate? template = null;
            
            TemplateEngine
                .RunAsync(
                    Arg.Do<TemplatePackTemplate>(t => template = t))
                .Returns(Task.CompletedTask);
            
            await command.OnExecuteAsync(new CommandLineApplication());

            Assert.NotNull(template);
            Assert.Equal("ag-template-pack", template.Name);
            Assert.Equal(command.Author, template.Author);
            Assert.Equal(command.PackageId, template.PackageId);
            Assert.Equal(command.Title, template.Title);
            Assert.Equal(command.Description, template.Description);
        }
    }
}