using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.Tools.Tests.Unit.GitIgnore.GitIgnoreFileTests
{
    /// <summary>
    /// Specifies the behavior when writing contents to a <see cref="GitIgnoreFile" />.
    /// </summary>
    public class WhenWritingContents : GitIgnoreFileTest
    {
        /// <summary>
        /// Tests that attempting to pass a null contents argument is rejected.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public async Task Null_Contents_Is_Rejected()
        {
            string path = CreateTestDirectory();
            GitIgnoreFile file = new (path);
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => file.WriteLinesAsync(null!));

            Assert.Equal("contents", exception.ParamName);
            
            Directory.Delete(path, true);
        }
        
        /// <summary>
        /// Tests that writing contents to a file that does not exist creates the file.
        /// </summary>
        [Fact]
        public async Task No_File_Creates_File()
        {
            string path = CreateTestDirectory();
            
            string gitIgnoreFile = Path.Combine(path, ".gitignore");
            Assert.False(File.Exists(gitIgnoreFile));
            
            GitIgnoreFile file = new (path);
            
            string[] contents =
            {
                "bin/"
            };
            await file.WriteLinesAsync(contents);
            
            Assert.True(File.Exists(gitIgnoreFile));
            
            Directory.Delete(path, true);
        }
        
        /// <summary>
        /// Tests that the contents are written to the file.
        /// </summary>
        [Fact]
        public async Task Contents_Are_Written_To_File()
        {
            string path = CreateTestDirectory();
            GitIgnoreFile file = new (path);
            
            string[] newContents =
            {
                "bin/", 
                "obj/", 
                "packages/", 
                ".vs/"
            };
            await file.WriteLinesAsync(newContents);
            
            string gitIgnoreFile = Path.Combine(path, ".gitignore");
            string[] readContents = await File.ReadAllLinesAsync(gitIgnoreFile);
            
            Assert.Equal(newContents, readContents);
            
            Directory.Delete(path, true);
        }
        
        /// <summary>
        /// Tests that the write operation is idempotent. Each entry should only be
        /// written once.
        /// </summary>
        [Fact]
        public async Task Operation_Is_Idempotent()
        {
            string path = CreateTestDirectory();
            GitIgnoreFile file = new (path);
            
            string[] newContents =
            {
                "bin/", 
                "obj/", 
                "packages/", 
                ".vs/"
            };
            await file.WriteLinesAsync(newContents);
            
            string gitIgnoreFile = Path.Combine(path, ".gitignore");
            string[] readContents = await File.ReadAllLinesAsync(gitIgnoreFile);
            
            Assert.Equal(newContents, readContents);
            
            await file.WriteLinesAsync(newContents);
            
            readContents = await File.ReadAllLinesAsync(gitIgnoreFile);
            
            Assert.Equal(newContents, readContents);
            
            Directory.Delete(path, true);
        }
    }
}