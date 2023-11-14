using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.Architecture.Tools.DecisionRecords.Markdown;

namespace AggregateGroot.Architecture.Tools.Tests.Unit.DecisionRecords.Markdown.DecisionRecordWriterTests
{
    /// <summary>
    /// Specifies the behavior when writing a decision record to disk.
    /// </summary>
    public class WhenWriting
    {
        /// <summary>
        /// Tests that the expected decision record is written to disk.
        /// </summary>
        [Fact]
        public async Task Decision_Record_Is_Written_To_Disk()
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
            
            Directory.Delete(directoryName, true);
        }

        /// <summary>
        /// Tests that attempting to write a null decision record is rejected.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public async Task Null_Decision_Record_IsRejected()
        {
            DecisionRecordWriter writer = new("/");
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => writer.WriteDecisionAsync(null!));

            Assert.Equal("decisionRecord", exception.ParamName);
        }
    }
}