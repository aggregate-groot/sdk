using System.IO;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.Architecture.Tools.DecisionRecords.Markdown;

namespace AggregateGroot.Architecture.Tools.Tests.Unit.DecisionRecords.Markdown
{
    /// <summary>
    /// Unit tests for the <see cref="DecisionRecordReader" /> class.
    /// </summary>
    public class DecisionRecordReaderTest
    {
        /// <summary>
        /// Tests that a null value is returned when no decision records exists in the directory.
        /// </summary>
        [Fact]
        public async Task Should_Return_Null_When_No_Decisions_Exist()
        {
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "DecisionRecords",
                "TestDecisions",
                "Empty");
            
            DecisionRecordReader reader = new(path);

            DecisionRecord? result = await reader.ReadLatestAsync();
            
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that decision with the highest number is read.
        /// </summary>
        [Fact]
        public async Task Should_Return_Decision_With_Highest_Number()
        {
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "DecisionRecords",
                "TestDecisions",
                "Decisions");
            
            DecisionRecordReader reader = new(path);

            DecisionRecord? result = await reader.ReadLatestAsync();
            
            Assert.NotNull(result);
            Assert.Equal(256, result.Number);
            Assert.Equal("Decision Two", result.Title);
        }
    }
}