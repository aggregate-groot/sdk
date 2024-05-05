using System;
using System.IO;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.Tools.Tests.Unit.GitIgnore.GitIgnoreFileTests
{
    /// <summary>
    /// Base class for testing the <see cref="GitIgnoreFile" /> class.
    /// </summary>
    public abstract class GitIgnoreFileTest
    {
        /// <summary>
        /// Creates a test directory.
        /// </summary>
        /// <returns>
        /// The path to the test directory that was created.
        /// </returns>
        protected string CreateTestDirectory()
        {
            string path = Path.Combine(
                nameof(GitIgnoreFileTest),
                Guid.NewGuid().ToString());
            
            Directory.CreateDirectory(path);

            return path;
        }
    }
}