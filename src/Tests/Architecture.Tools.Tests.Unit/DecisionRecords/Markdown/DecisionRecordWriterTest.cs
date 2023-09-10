using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.Architecture.Tools.DecisionRecords.Markdown;

namespace AggregateGroot.Architecture.Tools.Tests.Unit.DecisionRecords.Markdown
{
    /// <summary>
    /// Unit tests for the <see cref="DecisionRecordWriter" /> class.
    /// </summary>
    public class DecisionRecordWriterTest
    {
        /// <summary>
        /// Tests that the expected decision record is written to disk.
        /// </summary>
        [Fact]
        public async Task Should_Write_Decision_Record_To_Disk()
        {
            string directoryName = Guid.NewGuid().ToString();
            Directory.CreateDirectory(directoryName);

            DecisionRecord decision = new(8, "New Decision");
            
            DecisionRecordWriter writer = new(directoryName);
            await writer.WriteDecisionAsync(decision);

            string filePath = Path.Combine(directoryName, "0008-new-decision.md");
            
            Assert.True(File.Exists(filePath));
            
            string content = await File.ReadAllTextAsync(filePath);
            string firstLine = content.Split(Environment.NewLine).First();
            
            Assert.Equal("# 8. New Decision", firstLine);
        }

        /// <summary>
        /// Tests that passing a null decisionRecord argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public async Task Null_DecisionRecord_Should_Throw_Exception()
        {
            DecisionRecordWriter writer = new("/");
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => writer.WriteDecisionAsync(null!));

            Assert.Equal("decisionRecord", exception.ParamName);
        }
    }
}