using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;

namespace AggregateGroot.Templating.CliCommands.TemplatePack
{
    /// <summary>
    /// CLI command for creating a new template pack.
    /// </summary>
    [Command(Name = "template-pack", Description = "Creates a new template pack.")]
    public class TemplatePackCliCommand : TemplateCliCommand
    {
        /// <inheritdoc />
        public TemplatePackCliCommand(
            IConsole console,
            IPrompt prompt,
            ITemplateEngine templateEngine)
            : base(console, prompt, templateEngine)
        { }

        /// <summary>
        /// Gets or initializes unique identifier of the template package.
        /// </summary>
        [Option(
            "-p|--packageId",
            CommandOptionType.SingleValue,
            Description = "The unique identifier for the template package.")]
        [Prompt("Package ID")]
        public string PackageId { get; init; } = null!;

        /// <summary>
        /// Gets or initializes the author of the template package.
        /// </summary>
        [Option(
            "-a|--author",
            CommandOptionType.SingleValue,
            Description = "The author of the template package.")]
        [Prompt("Author")]
        public string Author { get; init; } = null!;
        
        /// <summary>
        /// Gets or initializes the title of the template package.
        /// </summary>
        [Option(
            "-t|--title",
            CommandOptionType.SingleValue,
            Description = "The title of the template package.")]
        [Prompt("Title")]
        public string Title { get; init; } = null!;

        /// <summary>
        /// Gets or initializes the description of the template package.
        /// </summary>
        [Option(
            "-d|--description",
            CommandOptionType.SingleValue,
            Description = "The description of the template package.")]
        [Prompt("Description")]
        public string Description { get; init; } = null!;

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            Prompt.PromptForAllOptions(this);

            TemplatePackTemplate template = new()
            {
                Author = Author,
                PackageId = PackageId,
                Title = Title,
                Description = Description
            };

            await TemplateEngine.RunAsync(template);
            
            return 1;
        }
    }
}