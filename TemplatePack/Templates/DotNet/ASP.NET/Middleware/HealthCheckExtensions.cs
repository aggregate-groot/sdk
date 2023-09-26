using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace _RootNamespace_.Api.Middleware
{
    /// <summary>
    /// Extension methods for adding health checks to the application.
    /// </summary>
    public static class HealthCheckExtensions
    {
        /// <summary>
        /// Adds health checks to ensure the API in an operational and ready state.
        /// </summary>
        /// <param name="services">
        /// Required service collection to add the health checks to.
        /// </param>
        public static IServiceCollection AddApiHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();

            return services;
        }
        
        /// <summary>
        /// Maps endpoints to allow health check monitoring.
        /// </summary>
        /// <param name="endpoints">
        /// Required endpoint builder to map the health check endpoints to.
        /// </param>
        public static IEndpointRouteBuilder MapApiHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints
                .MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true
                });
            
            endpoints.Map("/liveness", context =>
                {
                    context.Response.StatusCode = (int) HttpStatusCode.OK;
                    return Task.CompletedTask;
                });;

            return endpoints;
        }
    }
}