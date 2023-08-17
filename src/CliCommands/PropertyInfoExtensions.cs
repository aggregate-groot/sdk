using System.Reflection;

namespace AggregateGroot.CliCommands
{
    /// <summary>
    /// Extension methods for the <see cref="PropertyInfo"/> clas.
    /// </summary>
    public static class PropertyInfoExtensions
    {
        /// <summary>
        /// Determines if the value for the provided <paramref name="property"/>
        /// is equal to the default for it's type.
        /// </summary>
        /// <param name="property">
        /// Required <see cref="PropertyInfo"/> containing the information about
        /// the property to check.
        /// </param>
        /// <param name="instance">
        /// Required instance of the type containing the property to check.
        /// </param>
        /// <returns>
        /// True if the property's value is equal to the default for the type,
        /// otherwise false.
        /// </returns>
        public static bool IsValueSet(this PropertyInfo property, object instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (property.PropertyType == typeof(string))
            {
                string? value = (string?)property.GetValue(instance);
                return value != default;
            }
            
            if (property.PropertyType == typeof(ushort))
            {
                ushort value = (ushort)(property.GetValue(instance) ?? 0);
                return value != default;
            }

            return false;
        }
    }
}