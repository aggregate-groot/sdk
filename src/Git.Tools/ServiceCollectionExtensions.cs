using System.IO;

using Microsoft.Extensions.DependencyInjection;

using AggregateGroot.Git.Tools.GitIgnore;

namespace AggregateGroot.Git.Tools
{
    /// <summary>
    /// Extension methods for adding git tooling to a service collection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds git tooling to the provided <paramref name="services" />.
        /// </summary>
        /// <param name="services">
        /// Required service collection to add git tooling to.
        /// </param>
        /// <returns>
        /// Provided <paramref name="services" /> with git tooling added.
        /// </returns>
        public static IServiceCollection AddGitTooling(this IServiceCollection services)
        {
            services
                .AddSingleton<IGitIgnoreFile>(new GitIgnoreFile(Directory.GetCurrentDirectory()));
            return services;
        }
    }
}