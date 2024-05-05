using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

using Xunit;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.Tools.Tests.Unit.GitIgnore.GitIgnoreFileTests
{
    /// <summary>
    /// Specifies the behavior when constructing a <see cref="GitIgnoreFile" />.
    /// </summary>
    public class WhenConstructing
    {
        /// <summary>
        /// Tests that passing a null or empty path to the constructor will be rejected.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [ExcludeFromCodeCoverage]
        public void Null_Or_Empty_Path_Is_Rejected(string path)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new GitIgnoreFile(path));

            Assert.Equal("path", exception.ParamName);
        }
        
        /// <summary>
        /// Tests that passing an invalid path to the constructor will be rejected.
        /// </summary>
        [Fact]
        public void Invalid_Path_Is_Rejected()
        {
            const string path = "invalid/path";
            
            DirectoryNotFoundException exception = Assert.Throws<DirectoryNotFoundException>(
                () => new GitIgnoreFile(path));
            
            Assert.Contains(path, exception.Message);
        }
    }
}