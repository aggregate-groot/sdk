using System.Threading.Tasks;

namespace AggregateGroot.Templating
{
    /// <summary>
    /// Interface for types that writes files based off of installed templates.
    /// </summary>
    public interface ITemplateEngine
    {
        /// <summary>
        /// Runs the provided <paramref name="template"/> to generate the output files.
        /// </summary>
        /// <param name="template">
        /// Required template used to generated the files.
        /// </param>
        Task RunAsync(ISourceTemplate template);
    }
}