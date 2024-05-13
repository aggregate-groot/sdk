using Microsoft.Extensions.DependencyInjection;
using Xunit;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.Tools.Tests.Unit
{
    /// <summary>
    /// Specifies the behavior when adding git tooling to a service collection.
    /// </summary>
    public class WhenAddingGitTooling
    {
        /// <summary>
        /// Creates a new instance of the <see cref="WhenAddingGitTooling"/> class.
        /// </summary>
        public WhenAddingGitTooling()
        {
            ServiceCollection services = new();
            services.AddGitTooling();
            _serviceProvider = services.BuildServiceProvider();
        }
        
        /// <summary>
        /// Tests that the <see cref="IGitIgnoreFile"/> is registered with the service collection.
        /// </summary>
        [Fact]
        public void GitIgnore_File_Is_Registered()
        {
            Assert.IsType<GitIgnoreFile>(_serviceProvider.GetRequiredService<IGitIgnoreFile>());
        }
        
        private readonly ServiceProvider _serviceProvider;
    }
}