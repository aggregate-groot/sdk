using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;

namespace AggregateGroot.Templating.CliCommands.DotNetNew
{
    /// <summary>
    /// CLI command for creating a new 'dotnet new' template.
    /// </summary>
    [Command(Name = "dotnet-new-template", Description = "Creates a new 'dotnet new' template.")]
    public class DotNetNewCliCommand : TemplateCliCommand
    {
        /// <inheritdoc />
        public DotNetNewCliCommand(IConsole console, IPrompt prompt, ITemplateEngine templateEngine)
            : base(console, prompt, templateEngine)
        { }
        
        /// <summary>
        /// Gets or initializes the name of the template in the "dotnet new" registry..
        /// </summary>
        [Option(
            "-n|--name",
            CommandOptionType.SingleValue, 
            Description = "The name of the template to create.")]
        [Prompt("Template name")]
        public string TemplateName { get; init; } = null!;

        /// <summary>
        /// Gets or initializes the author of the template.
        /// </summary>
        [Option(
            "-a|--author",
            CommandOptionType.SingleValue, 
            Description = "The author of the template.")]
        [Prompt("Author")]
        public string Author { get; init; } = null!;
        
        /// <summary>
        /// Gets or initializes the author of the template.
        /// </summary>
        [Option(
            "-c|--classification",
            CommandOptionType.SingleValue, 
            Description = "The template classification.")]
        [Prompt("Classification")]
        public string Classification { get; init; } = null!;

        /// <summary>
        /// Gets or initializes the identity of the template.
        /// </summary>
        [Option(
            "-id|--identity",
            CommandOptionType.SingleValue,
            Description = "The identity of the template.")]
        [Prompt("Identity (ex: CompanyName.Domain.TemplateName)")]
        public string Identity { get; init; } = null!;

        /// <summary>
        /// Gets or initializes the short name for the template.
        /// </summary>
        [Option(
            "-s|--shortName",
            CommandOptionType.SingleValue,
            Description = "The short name for the template.")]
        [Prompt("Template Short Name")]
        public string ShortName { get; init; } = null!;
        
        /// <summary>
        /// Gets or initializes the author of the template.
        /// </summary>
        [Option(
            "-t|--type",
            CommandOptionType.SingleValue, 
            Description = "The type of template to create (project or item).")]
        [Prompt("Type (project or item)")]
        public string Type { get; init; } = null!;

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            Prompt.PromptForAllOptions(this);

            DotNetNewTemplate template = new()
            {
                Author = Author,
                Classification = Classification,
                Identity = Identity,
                ShortName = ShortName,
                Type = Type,
                TemplateName = TemplateName
            };

            await TemplateEngine.RunAsync(template);
            
            return 1;
        }
    }
}