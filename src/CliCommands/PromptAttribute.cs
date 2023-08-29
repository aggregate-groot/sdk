using System;

namespace AggregateGroot.CliCommands
{
    /// <summary>
    /// Indicates that the property supports prompting for user input.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PromptAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="PromptAttribute"/> class.
        /// </summary>
        /// <param name="text">
        /// Required text for the prompt.
        /// </param>
        public PromptAttribute(string text)
        {
            Text = text;
        }
        
        /// <summary>
        /// Gets the text for the prompt.
        /// </summary>
        public string Text { get; }
    }
}