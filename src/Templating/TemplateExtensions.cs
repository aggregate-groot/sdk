using Microsoft.Extensions.DependencyInjection;

namespace AggregateGroot.Templating
{
    /// <summary>
    /// Extension methods for adding template support to a service collection.
    /// </summary>
    public static class TemplateExtensions
    {
        /// <summary>
        /// Adds templating support to the provided <paramref name="services"/>
        /// </summary>
        /// <param name="services">
        /// Required instance of a service collection to add support to.
        /// </param>
        /// <returns>
        /// The provided <paramref name="services"/> with project templating support added.
        /// </returns>
        public static IServiceCollection AddProjectTemplating(this IServiceCollection services)
        {
            services
                .AddSingleton<IDotNetCli, WrappedDotNetCli>()
                .AddSingleton<ITemplateEngine, DotNetTemplateEngine>();
            return services;
        }
    }
}