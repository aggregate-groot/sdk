using System.IO;
using McMaster.Extensions.CommandLineUtils;
using NSubstitute;

using AggregateGroot.Architecture.CliCommands.Workspace.ExportDiagrams;
using AggregateGroot.Architecture.Tools.Diagrams;

namespace AggregateGroot.Architecture.CliCommands.Tests.Unit.Workspace.ExportDiagrams.ExportDiagramsCliCommandTests
{
    /// <summary>
    /// Base class for testing the <see cref="ExportDiagramsCliCommand"/> class.
    /// </summary>
    public abstract class ExportDiagramsCliCommandTest
    {
        /// <summary>
        /// Gets the <see cref="IConsole"/> instance to support testing.
        /// </summary>
        protected IConsole Console { get; } = Substitute.For<IConsole>();
        
        /// <summary>
        /// Gets the <see cref="ExportDiagramsCliCommand"/> instance to support testing.
        /// </summary>
        protected IDiagramExporter DiagramExporter { get; } = Substitute.For<IDiagramExporter>();
        
        /// <summary>
        /// Gets the <see cref="ExportDiagramsCliCommand"/> instance to support testing.
        /// </summary>
        protected IDiagramTarget DiagramTarget { get; } = Substitute.For<IDiagramTarget>();
        
        protected ExportDiagramsCliCommand CreateCommand()
        {
            TextWriter errorWriter = Substitute.For<TextWriter>();
            Console.Error.Returns(errorWriter);
            
            return new ExportDiagramsCliCommand(Console, DiagramExporter, DiagramTarget);
        }
    }
}