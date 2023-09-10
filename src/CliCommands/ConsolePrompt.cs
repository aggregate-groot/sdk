using System;
using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.CliCommands
{
    /// <summary>
    /// Console implementation of the <see cref="IPrompt"/> interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsolePrompt : IPrompt
    {
        /// <inheritdoc />
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="prompt"/> is not provided.
        /// </exception>
        public string? GetString(string prompt, string? defaultValue)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(prompt));
            }

            return Prompt.GetString(prompt, defaultValue);
        }
        
        /// <inheritdoc />
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="prompt"/> is not provided.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the user does not provide a value for the input prompt.
        /// </exception>
        public string GetRequiredString(string prompt, string? defaultValue)
        {
            string? value = GetString(prompt, defaultValue);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"User input from {prompt} is required.");
            }

            return value;
        }
        
        /// <inheritdoc />
        public ushort GetUShort(string prompt, ushort defaultValue)
        {
            int value = Prompt.GetInt(prompt, defaultValue);

            if (value > ushort.MaxValue)
            {
                return ushort.MaxValue;
            }
            
            return (ushort)value;
        }
    }
}