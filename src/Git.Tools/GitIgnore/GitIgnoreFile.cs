using System;
using System.IO;

namespace AggregateGroot.Git.Tools.GitIgnore
{
    /// <summary>
    /// Represents a .gitignore file
    /// </summary>
    public class GitIgnoreFile
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
        
        private readonly string _path;
    }
}