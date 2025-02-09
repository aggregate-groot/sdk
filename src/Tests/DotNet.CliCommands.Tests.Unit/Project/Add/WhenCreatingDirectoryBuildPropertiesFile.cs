using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.Add.DirectoryBuildProperties;

namespace DotNet.CliCommands.Tests.Unit.Project.Add
{
    /// <summary>
    /// Specifies the behavior when creating a Directory.Build.props file.
    /// </summary>
    public class WhenCreatingDirectoryBuildPropertiesFile : TemplateCliCommandTest
    {
        /// <summary>
        /// Tests that the command line arguments are used as template values.
        /// </summary>
        [Fact]
        public async Task Command_Line_Arguments_Are_Used_As_Template_Values()
        {
            DirectoryBuildPropertiesCliCommand command = new (Console, Prompt, TemplateEngine)
            {
                DotNetVersion = "net9.0"
            };
            
            DirectoryBuildPropertiesTemplate? template = null;
            
            await TemplateEngine.RunAsync(Arg.Do<DirectoryBuildPropertiesTemplate>(captured => template = captured));
            
            await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.NotNull(template);
            Assert.Equal("izs-directory-build-props", template.Name);
            Assert.Equal(command.DotNetVersion, template.DotNetVersion);
        }
    }
}