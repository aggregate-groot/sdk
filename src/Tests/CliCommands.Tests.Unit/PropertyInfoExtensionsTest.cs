using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Xunit;

namespace AggregateGroot.CliCommands.Tests.Unit
{
    /// <summary>
    /// Unit tests for the <see cref="PropertyInfoExtensions" /> class.
    /// </summary>
    public class PropertyInfoExtensionsTest
    {
        /// <summary>
        /// Tests that passing a null instance argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Instance_Should_Throw_Exception()
        {
            TestClass test = new();

            PropertyInfo? property = test.GetType().GetProperty(nameof(test.SomeString));
            
            Assert.NotNull(property);
            
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => property.IsValueSet(null!));

            Assert.Equal("instance", exception.ParamName);
        }
        
        /// <summary>
        /// Tests that a string property with a default value is considered inset.
        /// </summary>
        [Fact]
        public void Should_Return_False_When_String_Property_Is_Default()
        {
            TestClass test = new();

            PropertyInfo? property = test.GetType().GetProperty(nameof(test.SomeString));
            
            Assert.NotNull(property);

            Assert.False(property.IsValueSet(test));
        }
        
        /// <summary>
        /// Tests that a string property with a default value is considered inset.
        /// </summary>
        [Fact]
        public void Should_Return_True_When_String_Property_Has_Been_Sett()
        {
            TestClass test = new()
            {
                SomeString = "guy"
            };

            PropertyInfo? property = test.GetType().GetProperty(nameof(test.SomeString));
            
            Assert.NotNull(property);

            Assert.True(property.IsValueSet(test));
        }
        
        /// <summary>
        /// Tests that a ushort property with a default value is considered inset.
        /// </summary>
        [Fact]
        public void Should_Return_False_When_UShort_Property_Is_Default()
        {
            TestClass test = new();

            PropertyInfo? property = test.GetType().GetProperty(nameof(test.SomeUShort));
            
            Assert.NotNull(property);

            Assert.False(property.IsValueSet(test));
        }
        
        /// <summary>
        /// Tests that a ushort property with a default value is considered inset.
        /// </summary>
        [Fact]
        public void Should_Return_True_When_UShort_Property_Has_Been_Sett()
        {
            TestClass test = new()
            {
                SomeUShort = 80
            };

            PropertyInfo? property = test.GetType().GetProperty(nameof(test.SomeUShort));
            
            Assert.NotNull(property);

            Assert.True(property.IsValueSet(test));
        }
    }
}