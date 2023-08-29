using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AggregateGroot.Templating
{
    /// <summary>
    /// DotNet CLI implementation of the <see cref="ITemplateEngine"/> interface.
    /// </summary>
    public class DotNetTemplateEngine : ITemplateEngine
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DotNetTemplateEngine"/> class.
        /// </summary>
        /// <param name="dotNetCli"></param>
        public DotNetTemplateEngine(IDotNetCli dotNetCli)
        {
            _dotNetCli = dotNetCli 
                ?? throw new ArgumentNullException(nameof(dotNetCli));
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="template"/> is not provided.
        /// </exception>
        public async Task RunAsync(ISourceTemplate template)
        {
            if (template == null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            await ConfirmTemplateInstallationAsync(template.Name);
            
            string argumentText = BuildArgumentText(template);

            await _dotNetCli.RunCommandAsync($"new {template.Name}{argumentText}");
        }
        
        /// <summary>
        /// Determines if the provided <paramref name="templateName"/> is installed .
        /// </summary>
        /// <param name="templateName">
        /// Required name of the template to check.
        /// </param>
        /// <returns>
        /// True if the template is installed, otherwise false.
        /// </returns>
        private async Task ConfirmTemplateInstallationAsync(string templateName)
        {
            string result = await _dotNetCli.RunCommandAsync($"new list {templateName}");

            if (result.Contains("No templates found")) {
                throw new InvalidOperationException($"The template '{templateName}' is not installed.");
            }
        }
        
        /// <summary>
        /// Builds the argument text string for passing to dotnet new.
        /// </summary>
        /// <param name="template">
        /// Required template containing the arguments to capture.
        /// </param>
        private static string BuildArgumentText(ISourceTemplate template)
        {
            StringBuilder builder = new();
            var properties = template.GetType().GetProperties();
            
            foreach (PropertyInfo property in properties)
            {
                TemplateArgumentAttribute? templateArgument 
                    = property.GetCustomAttribute<TemplateArgumentAttribute>();
                
                if (templateArgument == null)
                {
                    continue;
                }
                
                builder.Append($" --{ templateArgument.Name } \"{ property.GetValue(template) }\"");
            }
            
            return builder.ToString();
        }

        private readonly IDotNetCli _dotNetCli;
    }
}