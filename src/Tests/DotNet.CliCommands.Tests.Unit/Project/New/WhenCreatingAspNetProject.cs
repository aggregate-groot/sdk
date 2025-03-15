using System.Threading.Tasks;

using Xunit;
using McMaster.Extensions.CommandLineUtils;
using NSubstitute;

using AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.New.AspNet;

namespace DotNet.CliCommands.Tests.Unit.Project.New
{
    /// <summary>
    /// Specifies the behavior when creating an ASP.NET project.
    /// </summary>
    public class WhenCreatingAspNetProject : TemplateCliCommandTest
    {
        /// <summary>
        /// Tests that the command line arguments are used as template values.
        /// </summary>
        [Fact]
        public async Task Command_Line_Arguments_Are_Used_As_Template_Values()
        {
            AspNetProjectCliCommand command = new (Console, Prompt, TemplateEngine)
            {
                RootNamespace = "Some.Namespace",
                DotNetVersion = "net8.0",
                ApiPort = 5000,
                ApiSslPort = 5001
            };
            
            AspNetProjectTemplate? template = null;
            
            await TemplateEngine.RunAsync(Arg.Do<AspNetProjectTemplate>(captured => template = captured));
            
            await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.NotNull(template);
            Assert.Equal("ag-web-api", template.Name);
            Assert.Equal(command.RootNamespace, template.RootNamespace);
            Assert.Equal(command.DotNetVersion, template.DotNetVersion);
            Assert.Equal(command.ApiPort, template.ApiPort);
            Assert.Equal(command.ApiSslPort, template.ApiSslPort);
        }
    }
}