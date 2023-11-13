using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

using AggregateGroot.Architecture.CliCommands.Workspace.ExportDiagrams;

namespace AggregateGroot.Architecture.CliCommands.Tests.Unit.Workspace.ExportDiagrams.ExportDiagramsCliCommandTests
{
    /// <summary>
    /// Specifies the behavior when constructing the <see cref="ExportDiagramsCliCommand"/> class.
    /// </summary>
    public class WhenConstructing : ExportDiagramsCliCommandTest
    {
        /// <summary>
        /// Tests that a new instance is in the expected state.
        /// </summary>
        [Fact]
        public void New_Instance_Is_In_Expected_State()
        {
            ExportDiagramsCliCommand command = new(Console, DiagramExporter, DiagramTarget);
            
            Assert.Equal(0, command.Port);
            Assert.Null(command.OutputDirectory);
        }

        /// <summary>
        /// Tests that attempting to pass a null console argument is rejected.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Console_Is_Rejected()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new ExportDiagramsCliCommand(null!, DiagramExporter, DiagramTarget));

            Assert.Equal("console", exception.ParamName);
        }

        /// <summary>
        /// Tests that attempting to pass a null diagramExporter argument is rejected.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_DiagramExporter_Is_Rejected()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new ExportDiagramsCliCommand(Console, null!, DiagramTarget));

            Assert.Equal("diagramExporter", exception.ParamName);
        }

        /// <summary>
        /// Tests that attempting to pass a null diagramTarget argument is rejected.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_DiagramTarget_Is_Rejected()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new ExportDiagramsCliCommand(Console, DiagramExporter, null!));

            Assert.Equal("diagramTarget", exception.ParamName);
        }
    }
}