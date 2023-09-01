using AggregateGroot.Templating;

namespace AggregateGroot.Architecture.CliCommands.Workspace.Create
{
    /// <summary>
    /// Template for a an architecture workspace.
    /// </summary>
    public class WorkspaceTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "ag-architecture-workspace";
    }
}