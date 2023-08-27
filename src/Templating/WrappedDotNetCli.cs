using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

using CliWrap;

namespace AggregateGroot.Templating
{
    /// <summary>
    /// Wraps the dotnet CLI to execute it's commands
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class WrappedDotNetCli : IDotNetCli
    {
        /// <inheritdoc />
        public async Task<string> RunCommandAsync(string command)
        {
            if (command == null) {
                throw new ArgumentNullException(nameof(command));
            }

            StringBuilder outputBuffer = new ();

            await Cli
                .Wrap("dotnet")
                .WithArguments(command)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(outputBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(outputBuffer))
                .WithValidation(CommandResultValidation.None)
                .ExecuteAsync();
            
            Console.WriteLine(outputBuffer);

            return outputBuffer.ToString();
        }
    }
}