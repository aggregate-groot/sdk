namespace AggregateGroot.Templating.Tests.Unit
{
    /// <summary>
    /// Template for testing the <see cref="DotNetTemplateEngine"/> class.
    /// </summary>
    public class TestTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "some-template";
        
        /// <summary>
        /// Gets or initializes some template argument for testing.
        /// </summary>
        [TemplateArgument(Name = "some-argument")]
        public required string SomeArgument { get; init; }
    }
}