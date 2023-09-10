using System;
using System.Reflection;

namespace AggregateGroot.CliCommands
{
    /// <summary>
    /// Extensions methods for prompting for command option values.
    /// </summary>
    public static class OptionPromptExtensions
    {
        /// <summary>
        /// Prompts and binds the input for all options in the provided
        /// <paramref name="command"/>.
        /// </summary>
        /// <param name="prompt">
        /// Required prompt to add the method to.
        /// </param>
        /// <param name="command">
        /// Required command containing the options to prompt for.
        /// </param>
        public static void PromptForAllOptions(this IPrompt prompt, object command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            PropertyInfo[] properties = command.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                PromptForInput(prompt, property, command);
            }
        }

        /// <summary>
        /// Invokes the prompt to get the value to bind to the provided
        /// <paramref name="property"/>.
        /// </summary>
        /// <param name="prompt">
        /// Required type responsible for prompting for user input.
        /// </param>
        /// <param name="property">
        /// Required property to bind the value to.
        /// </param>
        /// <param name="command">
        /// Require instance of the command containing the property to set.
        /// </param>
        private static void PromptForInput(IPrompt prompt, PropertyInfo property, object command)
        {
            PromptAttribute? promptAttribute 
                = property.GetCustomAttribute<PromptAttribute>();
            
            if (promptAttribute == null || property.IsValueSet(command))
            {
                return;
            }

            string promptMessage = promptAttribute.Text + ":";
            object value = PromptForProperty(prompt, property, promptMessage);
            property.SetValue(command, value);
        }

        /// <summary>
        /// Prompts the user for the value of the provided <paramref name="prompt"/>.
        /// </summary>
        /// <param name="prompt">
        /// Required type responsible for prompting for user input.
        /// </param>
        /// <param name="property">
        /// Required property to bind the value to.
        /// </param>
        /// <param name="promptMessage">
        /// The message to prompt the user with.
        /// </param>
        /// <returns>
        /// The value provided by the user.
        /// </returns>
        private static object PromptForProperty(
            IPrompt prompt,
            PropertyInfo property,
            string promptMessage)
        {
            if (property.PropertyType == typeof(ushort))
            {
                return prompt.GetUShort(promptMessage, 0);
            }
            
            return prompt.GetRequiredString(promptMessage, string.Empty);
        }
    }
}