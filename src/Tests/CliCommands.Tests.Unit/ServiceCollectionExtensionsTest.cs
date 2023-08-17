using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AggregateGroot.CliCommands.Tests.Unit
{
    /// <summary>
    /// Unit tests for the <see cref="ServiceCollectionExtensions" /> class.
    /// </summary>
    public class ServiceCollectionExtensionsTest
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ServiceCollectionExtensionsTest"/> class.
        /// </summary>
        public ServiceCollectionExtensionsTest()
        {
            ServiceCollection services = new();
            services.AddCliCommands();

            _serviceProvider = services.BuildServiceProvider();
        }
        
        /// <summary>
        /// Tests that the <see cref="WrappedCliProvider"/> is registered with the service collection.
        /// </summary>
        [Fact]
        public void Should_Register_CLIProvider()
        {
            Assert.IsType<WrappedCliProvider>(
                _serviceProvider.GetRequiredService<ICliProvider>());
        }
        
        /// <summary>
        /// Tests that the <see cref="ConsolePrompt"/> is registered with the service collection.
        /// </summary>
        [Fact]
        public void Should_Register_ConsolePrompt()
        {
            Assert.IsType<ConsolePrompt>(
                _serviceProvider.GetRequiredService<IPrompt>());
        }
        
        private readonly ServiceProvider _serviceProvider;
    }
}