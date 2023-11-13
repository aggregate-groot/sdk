using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.Architecture.Tools.DecisionRecords.Markdown;
using AggregateGroot.Architecture.Tools.Diagrams;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AggregateGroot.Architecture.Tools.Tests.Unit.ServiceCollectionExtensionsTests
{
    /// <summary>
    /// Specifies the behavior when adding architecture tools to a service collection.
    /// </summary>
    public class WhenAddingArchitectureTools
    {
        /// <summary>
        /// Creates a new instance of the <see cref="WhenAddingArchitectureTools"/> class.
        /// </summary>
        public WhenAddingArchitectureTools()
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
        public void Decision_Record_Reader_Is_Registered()
        {
            Assert.IsType<DecisionRecordReader>(
                _serviceProvider.GetRequiredService<IDecisionRecordReader>());
        }
        
        /// <summary>
        /// Tests that the <see cref="DecisionRecordWriter"/> is registered
        /// with the service collection.
        /// </summary>
        [Fact]
        public void Decision_Record_Writer_Is_Registered()
        {
            Assert.IsType<DecisionRecordWriter>(
                _serviceProvider.GetRequiredService<IDecisionRecordWriter>());
        }
        
        /// <summary>
        /// Tests that the <see cref="PuppeteerDiagramExporter"/> is registered with
        /// the service collection.
        /// </summary>
        [Fact]
        public void Diagram_Exporter_Is_Registered()
        {
            Assert.IsType<PuppeteerDiagramExporter>(
                _serviceProvider.GetRequiredService<IDiagramExporter>());
        }
        
        /// <summary>
        /// Tests that the <see cref="FileSystemDiagramTarget"/> is registered with
        /// the service collection.
        /// </summary>
        [Fact]
        public void Diagram_Target_Is_Registered()
        {
            Assert.IsType<FileSystemDiagramTarget>(
                _serviceProvider.GetRequiredService<IDiagramTarget>());
        }
        
        private readonly ServiceProvider _serviceProvider;
    }
}