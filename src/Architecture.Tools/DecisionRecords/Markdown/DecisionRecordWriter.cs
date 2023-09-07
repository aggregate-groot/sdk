using System;
using System.IO;
using System.Threading.Tasks;

namespace AggregateGroot.Architecture.Tools.DecisionRecords.Markdown
{
    /// <summary>
    /// Markdown implementation of the <see cref="IDecisionRecordWriter"/> interface.
    /// </summary>
    public class DecisionRecordWriter : IDecisionRecordWriter
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DecisionRecordWriter"/> class.
        /// </summary>
        /// <param name="decisionsDirectory">
        /// Required directory to write a decision record to.
        /// </param>
        public DecisionRecordWriter(string decisionsDirectory)
        {
            _decisionsDirectory = decisionsDirectory 
                ?? throw new ArgumentNullException(nameof(decisionsDirectory));
        }
        
        /// <inheritdoc />
        public async Task WriteDecisionAsync(DecisionRecord decisionRecord)
        {
            if (decisionRecord == null)
            {
                throw new ArgumentNullException(nameof(decisionRecord));
            }
            
            string fileName = GetFileName(decisionRecord);
            string templatePath = Path.Combine(_decisionsDirectory, "Templates", "template.md");

            string contents = await DecisionRecordTemplate.MergeAsync(decisionRecord, templatePath);
            
            await File.WriteAllTextAsync(Path.Combine(_decisionsDirectory, fileName), contents);
        }

        /// <summary>
        /// Gets the file name for the decision record.
        /// </summary>
        /// <param name="decisionRecord">
        /// Required decision record to get the file name for.
        /// </param>
        private static string GetFileName(DecisionRecord decisionRecord)
        {
            string formattedNumber = decisionRecord.Number.ToString().PadLeft(4, '0');
            string formattedTitle = decisionRecord.Title.Replace(' ', '-').ToLower();
            return $"{formattedNumber}-{formattedTitle}.md";
        }

        private readonly string _decisionsDirectory;
    }
}