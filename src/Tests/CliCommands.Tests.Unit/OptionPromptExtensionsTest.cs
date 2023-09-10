using System;
using System.Diagnostics.CodeAnalysis;

using NSubstitute;
using Xunit;

namespace AggregateGroot.CliCommands.Tests.Unit
{
    /// <summary>
    /// Unit tests for the PromptForAllOptions() method of the
    /// <see cref="OptionPromptExtensions" /> class.
    /// </summary>
    public class PromptForAllOptionsTest
    {
        /// <summary>
        /// Tests that passing a null command argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Command_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => _prompt.PromptForAllOptions(null!));

            Assert.Equal("command", exception.ParamName);
        }
        
        /// <summary>
        /// Tests that each property with a prompt attribute is prompted for user
        /// input and the provided value is bound.
        /// </summary>
        [Fact]
        public void Should_Prompt_For_Each_Option()
        {
            TestCommand command = new();
            const string someString = "Guy";
            
            _prompt.GetRequiredString("Some string:", "").Returns(someString);
            
            _prompt.PromptForAllOptions(command);
            
            Assert.Equal(someString, command.SomeString);
        }

        /// <summary>
        /// Test that is a command option has already been set, it will not be
        /// prompted for.
        /// </summary>
        [Fact]
        public void Should_Not_Prompt_When_Property_Is_Already_Set()
        {
            const string someString = "Buddy";
            const ushort someUShort = 8888;
            TestCommand command = new()
            {
                SomeString = someString,
                SomeUShort = someUShort
            };
            
            _prompt.GetRequiredString("Some string:", "").Returns("WGA");
            
            _prompt.PromptForAllOptions(command);
            
            Assert.Equal(someString, command.SomeString);
        }
        
        private readonly IPrompt _prompt = Substitute.For<IPrompt>();
    }
}