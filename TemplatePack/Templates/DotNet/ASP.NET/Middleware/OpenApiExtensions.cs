using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace _RootNamespace_.Api.Middleware
{   
    /// <summary>
    /// Extension methods to add OpenAPI (Swagger) support to the application.
    /// </summary>
    public static class OpenApiExtensions
    {
        /// <summary>
        /// Adds OpenAPI (Swagger) to the provided <paramref name="services"/>
        /// </summary>
        /// <param name="services">
        /// Required service to add OpenAPI support to.
        /// </param>
        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_version, new OpenApiInfo
                {
                    Title = "API", 
                    Version = _version
                });
            });
            
            return services;
        }

        /// <summary>
        /// OpenAPI (Swagger) to the provided <paramref name="app"/>
        /// </summary>
        /// <param name="app">
        /// Required application builder to add OpenAPI support to.
        /// </param>
        public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => 
                options.SwaggerEndpoint("/swagger/v1/swagger.json", $"Api { _version }"));
            return app;
        }

        private const string _version = "v1";
    }
}