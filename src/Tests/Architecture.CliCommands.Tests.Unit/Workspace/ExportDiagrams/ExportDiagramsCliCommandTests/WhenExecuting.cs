using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.Architecture.CliCommands.Workspace.ExportDiagrams;
using AggregateGroot.Architecture.Tools.Diagrams;

namespace AggregateGroot.Architecture.CliCommands.Tests.Unit.Workspace.ExportDiagrams.ExportDiagramsCliCommandTests
{
    /// <summary>
    /// Specifies the behavior when executing the <see cref="ExportDiagramsCliCommand"/> command.
    /// </summary>
    public class WhenExecuting : ExportDiagramsCliCommandTest
    {
        /// <summary>
        /// Tests that passing a null or whitespace outputDirectory argument will result
        /// in an <see cref="ArgumentException" /> being thrown.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [ExcludeFromCodeCoverage]
        public async Task Null_OutputDirectory_Should_Throw_Exception(string outputDirectory)
        {
            ExportDiagramsCliCommand command = CreateCommand();
            command.Port = 1234;
            command.OutputDirectory = outputDirectory;
            
            int result = await command.OnExecuteAsync(new CommandLineApplication());

            Assert.True(result > 1);
            await Console.Error.WriteLineAsync("Please provide the output directory (-o).");
        }
        
        /// <summary>
        /// Tests that each diagram in the workspace is exported.
        /// </summary>
        [Fact]
        public async Task Each_Diagram_Is_Exported()
        {
            const ushort port = 8080;
            
            List<Diagram> diagrams = new()
            {
                new Diagram()
                {
                    Content = new byte[] { 2, 4, 8 },
                    Name = "Diagram1"
                },
                new Diagram()
                {
                    Content = new byte[] { 16, 32, 64 },
                    Name = "Diagram2"
                }
            };

            DiagramExporter.ExportAllAsync(port).Returns(diagrams);
            
            ExportDiagramsCliCommand command = CreateCommand();
            command.Port = port;
            command.OutputDirectory = "/some/path";
            
            await command.OnExecuteAsync(new CommandLineApplication());

            await DiagramTarget
                .Received(1)
                .WriteAsync(diagrams[0], command.OutputDirectory);
            await DiagramTarget
                .Received(1)
                .WriteAsync(diagrams[1], command.OutputDirectory);
        }
    }
}