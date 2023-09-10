using System.Threading.Tasks;

namespace AggregateGroot.Architecture.Tools.DecisionRecords
{
    /// <summary>
    /// Interface for types that provide reading of architecture decision records.
    /// </summary>
    public interface IDecisionRecordReader
    {
        /// <summary>
        /// Reads the last created decision record.
        /// </summary>
        /// <returns>
        /// The last created decision record. If none exists, null is returned.
        /// </returns>
        Task<DecisionRecord?> ReadLatestAsync();
    }
}