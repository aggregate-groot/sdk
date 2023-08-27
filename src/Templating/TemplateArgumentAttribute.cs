using System;

namespace AggregateGroot.Templating
{
    /// <summary>
    /// Marks a property as an argument that can be used to execute a source
    /// template.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TemplateArgumentAttribute : Attribute
    {
        /// <summary>
        /// Gets or initializes the name of the template argument..
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or initializes the default value for the argument.
        /// </summary>
        public string? DefaultValue { get; init; }
        
        /// <summary>
        /// Gets or initializes the value indicating if the template argument is
        /// required..
        /// </summary>
        public bool IsRequired { get; init; }
    }
}