using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.CliCommands;
using AggregateGroot.Templating;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.New.AspNet
{
    /// <summary>
    /// CLI command for creating a new ASP.NET project.
    /// </summary>
    [Command(Name = "asp-net", Description = "Create a new ASP.NET project.")]
    public class AspNetProjectCliCommand : TemplateCliCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Creates a new instance of the <see cref="AspNetProjectCliCommand"/> class.
        /// </summary>
        public AspNetProjectCliCommand(
            IConsole console,
            IPrompt prompt,
            ITemplateEngine templateEngine)
            : base(console, prompt, templateEngine)
        { }

        /// <inheritdoc />
        protected override ISourceTemplate BindSourceTemplate()
        {
            return new AspNetProjectTemplate()
            {
                RootNamespace = RootNamespace,
                DotNetVersion = DotNetVersion,
                ApiPort = ApiPort,
                ApiSslPort = ApiSslPort
            };
        }
        
        /// <summary>
        /// Gets or initializes the command line argument representing the project's root namespace.
        /// </summary>
        [Option(
            "-rn|--rootNamespace",
            CommandOptionType.SingleValue,
            Description = "The root namespace for the ASP.NET project.")]
        [Prompt("Root namespace")]
        public string RootNamespace { get; set; } = null!;
        
        /// <summary>
        /// Gets or initializes the command line argument representing the version of .NET to use for the project.
        /// </summary>
        [Option(
            "-dv|--dotNetVersion",
            CommandOptionType.SingleValue,
            Description = "The version of .NET to use for the project.")]
        [Prompt(".NET version")]
        public string DotNetVersion { get; set; } = null!;
        
        /// <summary>
        /// Gets or initializes the command line argument representing the API port for the project.
        /// </summary>
        [Option(
            "-ap|--apiPort",
            CommandOptionType.SingleValue,
            Description = "The API port for the ASP.NET project.")]
        [Prompt("API port")]
        public ushort ApiPort { get; set; }

        /// <summary>
        /// Gets or initializes the command line argument representing the API SSL port for the project.
        /// </summary>
        [Option(
            "-asp|--apiSslPort",
            CommandOptionType.SingleValue,
            Description = "The API SSL port for the ASP.NET project.")]
        [Prompt("API SSL port")]
        public ushort ApiSslPort { get; set; }
    }
}