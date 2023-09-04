using System.Threading.Tasks;

namespace AggregateGroot.Architecture.Tools.DecisionRecords
{
    /// <summary>
    /// Interface for types that can write architecture decision records.
    /// </summary>
    public interface IDecisionRecordWriter
    {
        /// <summary>
        /// Writes the provided <paramref name="decisionRecord"/>.
        /// </summary>
        /// <param name="decisionRecord">
        /// Required architecture decision record to write.
        /// </param>
        Task WriteDecisionAsync(DecisionRecord decisionRecord);
    }
}