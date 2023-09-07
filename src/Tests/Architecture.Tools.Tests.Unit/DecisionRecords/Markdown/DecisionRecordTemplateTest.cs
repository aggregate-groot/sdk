using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.Architecture.Tools.DecisionRecords.Markdown;

namespace AggregateGroot.Architecture.Tools.Tests.Unit.DecisionRecords.Markdown
{
    /// <summary>
    /// Unit tests for the <see cref="DecisionRecordTemplate" /> class.
    /// </summary>
    public class DecisionRecordTemplateTest
    {
        /// <summary>
        /// Tests that the template file is used if it is found at the provided template
        /// location.
        /// </summary>
        [Fact]
        public async Task Should_Use_Template_File_When_Available()
        {
            string template = Path.Combine(
                Directory.GetCurrentDirectory(),
                "DecisionRecords",
                "TestDecisions",
                "TemplateTest",
                "Templates",
                "template.md");

            DecisionRecord decisionRecord = new(64, "Decision 64", DateOnly.Parse("2020-01-01"));

            string output = await DecisionRecordTemplate.MergeAsync(decisionRecord, template);
            const string expected =
                """
                # (Templated) 64. Decision 64

                Date: 2020-01-01
                """;
            
            Assert.Equal(expected, output);
        }

        /// <summary>
        /// Tests that the embedded default template is used if the provided template
        /// location is not found.
        /// </summary>
        [Fact]
        public async Task Should_Use_Default_Template_If_Provided_File_Not_Available()
        {
            string template = Path.Combine(
                Directory.GetCurrentDirectory(),
                "DecisionRecords",
                "TestDecisions",
                "TemplateTest",
                "Templates",
                "fake-template.md");

            DecisionRecord decisionRecord = new(128, "Decision 128", DateOnly.Parse("2000-01-01"));

            string output = await DecisionRecordTemplate.MergeAsync(decisionRecord, template);
            const string expected =
                """
                # 128. Decision 128

                Date: 2000-01-01

                Last Discussed: 2000-01-01

                Owners:

                ## Status

                STATUS

                ## Context

                Add some context...

                ## Options

                ### 1.

                Option 1 summary...

                Pros:

                Cons:

                ### 2.

                Option 2 summary...

                Pros:

                Cons:

                ## Outcome

                We chose option ****
                """;
            
            Assert.Equal(expected, output);
        }

        /// <summary>
        /// Tests that passing a null decisionRecord argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public async Task NullDecisionRecordShouldThrowException()
        {
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => DecisionRecordTemplate.MergeAsync(null!, "/"));

            Assert.Equal("decisionRecord", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null or whitespace templatePath argument will result
        /// in an <see cref="ArgumentException" /> being thrown.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [ExcludeFromCodeCoverage]
        public async Task Null_TemplatePath_Should_Throw_Exception(string templatePath)
        {
            DecisionRecord decisionRecord = new(512, "Some Decision");
            ArgumentException exception = await Assert.ThrowsAsync<ArgumentException>(
                () => DecisionRecordTemplate.MergeAsync(decisionRecord, templatePath));

            Assert.Equal("templatePath", exception.ParamName);
        }
    }
}