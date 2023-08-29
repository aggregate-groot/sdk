using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliCommands
{
    /// <summary>
    /// Base class for CLI commands.
    /// </summary>
    public abstract class CliCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        [ExcludeFromCodeCoverage]
        public virtual Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            application.ShowHelp();
            return Task.FromResult(1);
        }
    }
}