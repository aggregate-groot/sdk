using AggregateGroot.Templating;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.New.AspNet
{
    /// <summary>
    /// Template for creating a new ASP.NET project.
    /// </summary>
    public class AspNetProjectTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "ag-web-api";
        
        /// <summary>
        /// Gets or initializes the root namespace for the project
        /// </summary>
        [TemplateArgument(
            Name = "rootNamespace",
            IsRequired = true)]
        public required string RootNamespace { get; init; }
        
        /// <summary>
        /// Gets or initializes the version of .NET to use for the project.
        /// </summary>
        [TemplateArgument(
            Name = "dotnetVersion",
            DefaultValue = "net8.0",
            IsRequired = true)]
        public required string DotNetVersion { get; init; }
        
        /// <summary>
        /// Gets or initializes the API port for the project.
        /// </summary>
        [TemplateArgument(
            Name = "apiPort",
            IsRequired = true)]
        public required ushort ApiPort { get; init; }
        
        /// <summary>
        /// Gets or initializes the API SSL port for the project.
        /// </summary>
        [TemplateArgument(
            Name = "apiSslPort",
            IsRequired = true)]
        public required ushort ApiSslPort { get; init; }
    }
}