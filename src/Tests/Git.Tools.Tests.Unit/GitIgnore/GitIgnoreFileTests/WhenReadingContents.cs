using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.Tools.Tests.Unit.GitIgnore.GitIgnoreFileTests
{
    /// <summary>
    /// Specifies the behavior when reading a <see cref="GitIgnoreFile" />.
    /// </summary>
    public class WhenReadingContents : GitIgnoreFileTest
    {
        /// <summary>
        /// Test that attempting to read a file that does not exist returns an
        /// empty collection.
        /// </summary>
        [Fact]
        public async Task No_File_Returns_Empty()
        {
            string path = CreateTestDirectory();
            GitIgnoreFile file = new (path);
            
            IEnumerable<string> contents = await file.ReadAllLinesAsync();
            
            Assert.Empty(contents);
            
            Directory.Delete(path, true);
        }
        
        /// <summary>
        /// Tests the the file is read and the contents are returned.
        /// </summary>
        [Fact]
        public async Task File_With_Contents_Returns_Contents()
        {
            string path = CreateTestDirectory();
            GitIgnoreFile file = new (path);
            
            string gitIgnoreFile = Path.Combine(path, ".gitignore");
            string[] contents =
            {
                "bin/", 
                "obj/", 
                "packages/", 
                ".vs/"
            };
            await File.WriteAllLinesAsync(gitIgnoreFile, contents);
            
            IEnumerable<string> readContents = await file.ReadAllLinesAsync();
            
            Assert.Multiple(() =>
            {
                Assert.NotEmpty(readContents);
                Assert.Equal(contents, readContents);
            });
            
            Directory.Delete(path, true);
        }
    }
}