using System.IO;

using Microsoft.Extensions.DependencyInjection;

using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.Architecture.Tools.DecisionRecords.Markdown;

namespace AggregateGroot.Architecture.Tools
{
    /// <summary>
    /// Extension methods for adding architecture features to a service collection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds architecture tools support to the provided <paramref name="services"/>
        /// </summary>
        /// <param name="services">
        /// Required instance of a service collection to add architecture tools support to.
        /// </param>
        /// <returns>
        /// The provided <paramref name="services"/> with project architecture tools support added.
        /// </returns>
        public static IServiceCollection AddArchitectureTools(this IServiceCollection services)
        {
            services
                .AddTransient<IDecisionRecordReader>(
                    _ => new DecisionRecordReader(Directory.GetCurrentDirectory()))
                .AddTransient<IDecisionRecordWriter>(
                    _ => new DecisionRecordWriter(Directory.GetCurrentDirectory()));
            
            return services;
        }
    }
}