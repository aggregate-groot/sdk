using AggregateGroot.Templating;

namespace AggregateGroot.DotNet.CliCommands.DotNet.CliCommands.Project.Add.DirectoryBuildProperties
{
    /// <summary>
    /// Template for a directory.build.props file.
    /// </summary>
    public class DirectoryBuildPropertiesTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "ag-directory-build-props";
        
        /// <summary>
        /// Gets or initializes the .NET SDK version.
        /// </summary>
        [TemplateArgument(
            Name = "dotNetVersion",
            DefaultValue = "net8.0",
            IsRequired = true)]
        public required string DotNetVersion { get; init; }
    }
}