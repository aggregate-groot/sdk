using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AggregateGroot.Templating.Tests.Unit
{
    /// <summary>
    /// Unit tests for the AddProjectTemplating method of the <see cref="TemplateExtensions" /> class.
    /// </summary>
    public class AddProjectTemplatingTest
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AddProjectTemplatingTest"/> class.
        /// </summary>
        public AddProjectTemplatingTest()
        {
            ServiceCollection services = new();
            services.AddProjectTemplating();

            _serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Tests that the <see cref="WrappedDotNetCli"/> is registered with the service collection.
        /// </summary>
        [Fact]
        public void Should_Register_DotNetCli()
        {
            Assert.IsType<WrappedDotNetCli>(
                _serviceProvider.GetRequiredService<IDotNetCli>());
        }

        /// <summary>
        /// Tests that the <see cref="DotNetTemplateEngine"/> is registered with the service collection.
        /// </summary>
        [Fact]
        public void Should_Register_TemplateEngine()
        {
            Assert.IsType<DotNetTemplateEngine>(
                _serviceProvider.GetRequiredService<ITemplateEngine>());
        }
        
        private readonly ServiceProvider _serviceProvider;
    }
}