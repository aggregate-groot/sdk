using System.Threading.Tasks;

namespace AggregateGroot.Git.Tools.GitIgnore
{
    /// <summary>
    /// Represents a git ignore file.
    /// </summary>
    public interface IGitIgnoreFile
    {
        /// <summary>
        /// Reads all lines from the git ignore file.
        /// </summary>
        /// <returns>
        /// A string array containing all lines from the git ignore file.
        /// </returns>
        Task<string[]> ReadAllLinesAsync();

        /// <summary>
        /// Writes the specified <paramref name="contents"/> to the git ignore file.
        /// </summary>
        /// <param name="contents">
        /// Required contents to write to the git ignore file.
        /// </param>
        /// <remarks>
        /// If any of the specified <paramref name="contents"/> already exist in the git ignore file, they will be
        /// skipped. This operation is idempotent.
        /// </remarks>
        Task WriteLinesAsync(string[] contents);
    }
}