using System;
using System.IO;
using System.Threading.Tasks;

namespace AggregateGroot.Git.Tools.GitIgnore
{
    /// <summary>
    /// Represents a .gitignore file
    /// </summary>
    public class GitIgnoreFile : IGitIgnoreFile
    {
        /// <summary>
        /// Creates a new instance of the <see cref="GitIgnoreFile" />.
        /// </summary>
        public GitIgnoreFile(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(
                    "Value cannot be null or whitespace.", nameof(path));
            }

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException(
                    $"The specified path({path}) does not exist.");
            }

            _path = path;
        }
        
        /// <inheritdoc />
        public Task<string[]> ReadAllLinesAsync()
        {
            string gitIgnoreFile = Path.Combine(_path, ".gitignore");
            if(!File.Exists(gitIgnoreFile))
            {
                return Task.FromResult(Array.Empty<string>());
            }
        
            return File.ReadAllLinesAsync(gitIgnoreFile);
        }

        /// <inheritdoc />
        public async Task WriteLinesAsync(string[] contents)
        {

        }
        
        private readonly string _path;
    }
}