using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace AggregateGroot.Templating.Tests.Unit
{
    /// <summary>
    /// Unit tests for the <see cref="DotNetTemplateEngine" /> class.
    /// </summary>
    public class DotNetTemplateEngineTest
    {
        /// <summary>
        /// Tests that passing a null dotNetCli argument to the constructor will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Constructor_Should_Validate_DotNetCli()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new DotNetTemplateEngine(null!));

            Assert.Equal("dotNetCli", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null template argument to the RunCommandAsync method will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public async Task NullTemplateShouldThrowException()
        {
            DotNetTemplateEngine engine = CreateTemplateEngine();
            
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => engine.RunAsync(null!));

            Assert.Equal("template", exception.ParamName);
        }
        
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown if the
        /// required template is not installed.
        /// </summary>
        [Fact]
        public async Task Should_Throw_Exception_When_Template_Not_Installed()
        {
            TestTemplate someTemplate = new ()
            {
                SomeArgument = "Mega-maid"
            };

            _dotNetCli
                .RunCommandAsync($"new list {someTemplate.Name}")
                .Returns($"No templates found matching: '{someTemplate.Name}'.");


            DotNetTemplateEngine engine = CreateTemplateEngine();

            InvalidOperationException exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => engine.RunAsync(someTemplate));
            
            Assert.Equal($"The template '{ someTemplate.Name }' is not installed.", exception.Message);
        }
        
        /// <summary>
        /// Tests that the provided template name and parameters are converted
        /// to the expected "dotnet new" command. 
        /// </summary>
        [Fact]
        public async Task Should_Convert_Template_Name_And_Parameters_To_DotNet_New_Command()
        {
            
            TestTemplate someTemplate = new ()
            {
                SomeArgument = "Some template"
            };
            
            const string templateResult = 
                """
                Template Name  Short Name     Language  Tags
                -------------  -------------  --------  --------
                Some Project   some-template  [C#]      Some/Tag
                """;

            _dotNetCli
                .RunCommandAsync($"new list {someTemplate.Name}")
                .Returns(templateResult);
            
            DotNetTemplateEngine engine = CreateTemplateEngine();

            await engine.RunAsync(someTemplate);

            await _dotNetCli
                .Received(1)
                .RunCommandAsync($"new {someTemplate.Name} --some-argument \"{someTemplate.SomeArgument}\"");
        }

        /// <summary>
        /// Creates a new <see cref="DotNetTemplateEngine"/> configured for testing.
        /// </summary>
        private DotNetTemplateEngine CreateTemplateEngine()
        {
            return new DotNetTemplateEngine(_dotNetCli);
        }

        private readonly IDotNetCli _dotNetCli = Substitute.For<IDotNetCli>();
    }
}