namespace AggregateGroot.Templating.CliCommands.DotNetNew
{
    /// <summary>
    /// Template for creating a new "dotnet new" template.
    /// </summary>
    public class DotNetNewTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "ag-dotnet-new-template";
        
        /// <summary>
        /// Gets or initializes the author of the template.
        /// </summary>
        [TemplateArgument(
            Name = "param:author",
            DefaultValue = "Iteration Zero Software",
            IsRequired = true)]
        public required string Author { get; init; }
        
        /// <summary>
        /// Gets or initializes the classification for the template.
        /// </summary>
        [TemplateArgument(
            Name = "classification",
            IsRequired = true)]
        public required string Classification { get; init; }

        /// <summary>
        /// Gets or initializes the identity for the template..
        /// </summary>
        [TemplateArgument(
            Name = "identity",
            IsRequired = true)]
        public required string Identity { get; init; }

        /// <summary>
        /// Gets or initializes the short name for the template.
        /// </summary>
        [TemplateArgument(
            Name = "shortName",
            IsRequired = true)]
        public required string ShortName { get; init; }
        
        /// <summary>
        /// Gets or initializes the name of the template to create.
        /// </summary>
        [TemplateArgument(
            Name = "name",
            IsRequired = true)]
        public required string TemplateName { get; init; }
        
        /// <summary>
        /// Gets or initializes the type of template (project or item).
        /// </summary>
        [TemplateArgument(
            Name = "templateType",
            DefaultValue = "project")]
        public required string Type { get; init; }
    }
}