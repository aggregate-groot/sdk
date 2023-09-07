using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AggregateGroot.Architecture.Tools.DecisionRecords.Markdown
{
     /// <summary>
    /// Markdown implementation of the <see cref="IDecisionRecordReader"/> interface/
    /// </summary>
    public partial class DecisionRecordReader : IDecisionRecordReader
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DecisionRecordReader"/> class.
        /// </summary>
        /// <param name="decisionsDirectory">
        /// Required directory to read the markdown decisions from.
        /// </param>
        public DecisionRecordReader(string decisionsDirectory)
        {
            _decisionsDirectory = decisionsDirectory;
        }
        
        /// <inheritdoc />
        public async Task<DecisionRecord?> ReadLatestAsync()
        {
            string[] files = Directory.GetFiles(_decisionsDirectory, "*.md");
            if (files.Length == 0)
            {
                return null;
            }

            string file = files.OrderBy(name => name).Last();
            DecisionRecord decision = await ParseDecisionRecord(file);

            return decision;
        }

        /// <summary>
        /// Parse the decision record date from a markdown file.
        /// </summary>
        /// <param name="file">
        /// Required file containing the decision record data.
        /// </param>
        private static async Task<DecisionRecord> ParseDecisionRecord(string file)
        {
            string content = await File.ReadAllTextAsync(file);
            string firstLine = content
                .Split(Environment.NewLine)
                .First();
            
            Match numberMatch = NumberExpression().Match(firstLine);
            Match titleMatch = TitleExpression().Match(firstLine);
            
            DecisionRecord decision = new(ushort.Parse(numberMatch.Value), titleMatch.Value.Trim());
            return decision;
        }

        private readonly string _decisionsDirectory;

        /// <summary>
        /// Regular expression for finding the decision number.
        /// </summary>
        [GeneratedRegex("\\d+")]
        private static partial Regex NumberExpression();
        
        /// <summary>
        /// Regular expression for finding the decision title.
        /// </summary>
        [GeneratedRegex(@"\s+[A-Za-z,;'\s]+")]
        private static partial Regex TitleExpression();
    }
}