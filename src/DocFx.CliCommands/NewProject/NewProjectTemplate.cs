using AggregateGroot.Templating;

namespace AggregateGroot.DocFx.CliCommands.NewProject
{
    /// <summary>
    /// Template for creating a new DocFx project.
    /// </summary>
    public class NewProjectTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "ag-docfx-project";
    }
}