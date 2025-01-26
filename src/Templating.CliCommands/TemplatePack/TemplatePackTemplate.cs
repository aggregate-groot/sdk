namespace AggregateGroot.Templating.CliCommands.TemplatePack
{
    /// <summary>
    /// Template for creating a new template pack project.
    /// </summary>
    public class TemplatePackTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "ag-template-pack";

        /// <summary>
        /// Gets or initializes the author of the template package.
        /// </summary>
        [TemplateArgument(
            Name = "param:author",
            IsRequired = true)]
        public required string Author { get; init; }
        
        /// <summary>
        /// Gets or initializes the unique identifier of the template package.
        /// </summary>
        [TemplateArgument(
            Name = "packageId",
            IsRequired = true)]
        public required string PackageId { get; init; }

        /// <summary>
        /// Gets or initializes the title of the template package.
        /// </summary>
        [TemplateArgument(
            Name = "title",
            IsRequired = true)]
        public required string Title { get; init; }

        /// <summary>
        /// Gets or initializes the description of the template package.
        /// </summary>
        [TemplateArgument(
            Name = "description",
            IsRequired = true)]
        public required string Description { get; init; }
    }
}