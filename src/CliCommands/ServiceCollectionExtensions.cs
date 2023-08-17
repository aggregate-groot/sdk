using Microsoft.Extensions.DependencyInjection;

namespace AggregateGroot.CliCommands
{
    /// <summary>
    /// Extension methods for adding CLI command support to a service collection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds CLI command support to the provided <paramref name="services"/>
        /// </summary>
        /// <param name="services">
        /// Required instance of a service collection to add CLI command support to.
        /// </param>
        /// <returns>
        /// The provided <paramref name="services"/> with project CLI command support added.
        /// </returns>
        public static IServiceCollection AddCliCommands(this IServiceCollection services)
        {
            services
                .AddSingleton<ICliProvider, WrappedCliProvider>()
                .AddSingleton<IPrompt, ConsolePrompt>();
            
            return services;
        }
    }
}