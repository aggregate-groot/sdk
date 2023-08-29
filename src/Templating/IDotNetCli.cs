using System.Threading.Tasks;

namespace AggregateGroot.Templating
{
    /// <summary>
    /// Interface for modeling the dotnet CLI.
    /// </summary>
    public interface IDotNetCli
    {
        /// <summary>
        /// Runs the specified dotnet CLI command.
        /// </summary>
        /// <param name="command">
        /// Required dotnet CLI command to run.
        /// </param>
        Task<string> RunCommandAsync(string command);
    }
}