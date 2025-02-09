using AggregateGroot.CliCommands;
using AggregateGroot.Templating;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.Add.DirectoryBuildProperties
{
    /// <summary>
    /// CLI command for adding a Directory.Build.props file to a project.
    /// </summary>
    [Command(Name = "directory-build-props", Description = "Create a new Directory.Build.props file.")]
    public class DirectoryBuildPropertiesCliCommand : TemplateCliCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// Creates a new instance of the <see cref="DirectoryBuildPropertiesCliCommand"/> class.
        /// </summary>
        public DirectoryBuildPropertiesCliCommand(
            IConsole console,
            IPrompt prompt,
            ITemplateEngine templateEngine) 
            : base(console, prompt, templateEngine)
        {
        }
        
        /// <summary>
        /// Gets or initializes the name of the class library project.
        /// </summary>
        [Option(
            "-dv|--dotNetVersion",
            CommandOptionType.SingleValue,
            Description = "The version of the .NET SDK to use.")]
        [Prompt(".NET SDK version")]
        public string DotNetVersion { get; init; } = null!;

        /// <inheritdoc />
        protected override ISourceTemplate BindSourceTemplate()
        {
            return new DirectoryBuildPropertiesTemplate()
            {
                DotNetVersion = DotNetVersion
            };
        }
    }
}