using System;
using System.Diagnostics.CodeAnalysis;

using Xunit;

using AggregateGroot.Architecture.Tools.DecisionRecords;

namespace AggregateGroot.Architecture.Tools.Tests.Unit.DecisionRecords
{
    /// <summary>
    /// Unit tests for the <see cref="DecisionRecord" /> class.
    /// </summary>
    public class DecisionRecordTest
    {
        /// <summary>
        /// Test that the decision record is properly initialized from the constructor.
        /// </summary>
        [Fact]
        public void Should_Initialize_From_Constructor()
        {
            const ushort number = 256;
            const string title = "Some Decision";
            DateOnly createdOn = DateOnly.Parse("2020-01-02");

            DecisionRecord decisionRecord = new(number, title, createdOn);
            
            Assert.Equal(number, decisionRecord.Number);
            Assert.Equal(title, decisionRecord.Title);
            Assert.Equal(createdOn, decisionRecord.CreatedOn);
        }

        /// <summary>
        /// Tests the the CreatedOn property is set to the current date when not
        /// provided in the constructor.
        /// </summary>
        [Fact]
        public void Should_Default_CreatedOn_To_Current_Date()
        {
            DecisionRecord decisionRecord = new(32, "Decision 32");
            
            Assert.Equal(DateOnly.FromDateTime(DateTime.Today), decisionRecord.CreatedOn);
        }

        /// <summary>
        /// Tests that passing a null or whitespace title argument to the constructor
        /// will result in an <see cref="ArgumentException" /> being thrown.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [ExcludeFromCodeCoverage]
        public void Constructor_Should_Validate_Title(string title)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new DecisionRecord(1, title));

            Assert.Equal("title", exception.ParamName);
        }
    }
}