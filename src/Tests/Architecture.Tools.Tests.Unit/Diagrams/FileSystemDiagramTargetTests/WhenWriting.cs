using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Architecture.Tools.Diagrams;

namespace AggregateGroot.Architecture.Tools.Tests.Unit.Diagrams.FileSystemDiagramTargetTests
{
    /// <summary>
    /// Specifies the behavior when writing a diagram to the file system.
    /// </summary>
    public class WhenWriting
    {
        /// <summary>
        /// Tests that attempting to write a null diagram is rejected.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public async Task Null_Diagram_Is_Rejected()
        {
            FileSystemDiagramTarget target = new ();
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => target.WriteAsync(null!, "path"));

            Assert.Equal("diagram", exception.ParamName);
        }

        /// <summary>
        /// Tests that attempting to write a diagram to a null or whitespace path is rejected.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [ExcludeFromCodeCoverage]
        public async Task Null_Path_IsRejected(string? path)
        {
            FileSystemDiagramTarget target = new ();
            Diagram diagram = new()
            {
                Content = new byte[] {},
                Name = "test"
            };
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(
                () => target.WriteAsync(diagram, path!));

            Assert.Equal("path", exception.ParamName);
        }
        
        /// <summary>
        /// Tests the expected diagram file is written to the file system.
        /// </summary>
        [Fact]
        public async Task Diagram_Is_Written_To_Png_File()
        {
            string directoryName = Guid.NewGuid().ToString();
            Directory.CreateDirectory(directoryName);
            
            Diagram diagram = new()
            {
                Content = new byte[] { 0x01, 0x02, 0x03 },
                Name = "test"
            };
            
            FileSystemDiagramTarget target = new ();
            await target.WriteAsync(diagram, directoryName);

            Assert.True(File.Exists(Path.Combine(directoryName, "test.png")));
            
            Directory.Delete(directoryName, true);
        }
    }
}