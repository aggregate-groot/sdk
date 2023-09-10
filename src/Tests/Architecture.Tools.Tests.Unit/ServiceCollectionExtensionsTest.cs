using Microsoft.Extensions.DependencyInjection;
using Xunit;

using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.Architecture.Tools.DecisionRecords.Markdown;

namespace AggregateGroot.Architecture.Tools.Tests.Unit
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
            services.AddArchitectureTools();

            _serviceProvider = services.BuildServiceProvider();
        }
        
        /// <summary>
        /// Tests that the <see cref="DecisionRecordReader"/> is registered
        /// with the service collection.
        /// </summary>
        [Fact]
        public void Should_Register_Decision_Record_Reader()
        {
            Assert.IsType<DecisionRecordReader>(
                _serviceProvider.GetRequiredService<IDecisionRecordReader>());
        }
        
        /// <summary>
        /// Tests that the <see cref="DecisionRecordWriter"/> is registered
        /// with the service collection.
        /// </summary>
        [Fact]
        public void Should_Register_Decision_Record_Writer()
        {
            Assert.IsType<DecisionRecordWriter>(
                _serviceProvider.GetRequiredService<IDecisionRecordWriter>());
        }
        
        private readonly ServiceProvider _serviceProvider;
    }
}