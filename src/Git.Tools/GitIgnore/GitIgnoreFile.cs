using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            ArgumentNullException.ThrowIfNull(contents, nameof(contents));
        
            string gitIgnoreFile = Path.Combine(_path, ".gitignore");

            List<string> newContents = await MergeContents(contents);

            await File.WriteAllLinesAsync(gitIgnoreFile, newContents);
        }
        
        /// <summary>
        /// Merges the provided <paramref name="contents"/> with the current contents of the file.
        /// </summary>
        /// <param name="contents">
        /// Required contents to merge.
        /// </param>
        /// <returns>
        /// The provided <paramref name="contents"/> merged with the current contents of the file.
        /// </returns>
        private async Task<List<string>> MergeContents(string[] contents)
        {
            string[] currentContents = await ReadAllLinesAsync();
        
            List<string> newContents = new ();
            newContents.AddRange(contents);

            foreach (var entry in currentContents.ToList().Where(entry => !newContents.Contains(entry)))
            {
                newContents.Add(entry);
            }

            return newContents;
        }
        
        private readonly string _path;
    }
}