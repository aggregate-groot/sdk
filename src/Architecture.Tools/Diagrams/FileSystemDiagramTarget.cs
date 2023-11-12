using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace AggregateGroot.Architecture.Tools.Diagrams
{
    /// <summary>
    /// File system implementation of the <see cref="IDiagramTarget"/> interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FileSystemDiagramTarget : IDiagramTarget
    {
        /// <inheritdoc />
        public Task WriteAsync(Diagram diagram, string path)
        {
            ArgumentNullException.ThrowIfNull(diagram, nameof(diagram));
            
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(path));
            }
            
            string output = Path.Combine(path, diagram.Name);
            return File.WriteAllBytesAsync($"{output}.png", diagram.Content);
        }
    }
}