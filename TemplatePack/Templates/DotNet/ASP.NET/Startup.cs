using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using _RootNamespace_.Api.Middleware;

namespace _RootNamespace_.Api
{
    /// <summary>
    /// Runs the start process for the API.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// Required configuration containing all the settings for the service.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration for the service.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services for the API.
        /// </summary>
        /// <param name="services">
        /// Required collection of services to configure.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();
            services.AddApiHealthChecks();
        }

        /// <summary>
        /// Configures the API.
        /// </summary>
        /// <param name="app">
        /// Required application builder to configure.
        /// </param>
        /// <param name="env">
        /// Required environment to containing information about the host.
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapApiHealthChecks();
            });
        }
    }
}