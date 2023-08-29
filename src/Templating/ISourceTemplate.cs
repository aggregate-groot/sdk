namespace AggregateGroot.Templating
{
    /// <summary>
    /// Interface for types that define a source template.
    /// </summary>
    public interface ISourceTemplate
    {
        /// <summary>
        /// Gets the name of the template.
        /// </summary>
        string Name { get; }
    }
}