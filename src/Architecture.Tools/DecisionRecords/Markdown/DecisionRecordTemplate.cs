using System;
using System.IO;
using System.Threading.Tasks;

namespace AggregateGroot.Architecture.Tools.DecisionRecords.Markdown
{
    /// <summary>
    /// Represents a template that can be used to format an architecture decision record
    /// as a markdown document.
    /// </summary>
    public static class DecisionRecordTemplate
    {
        /// <summary>
        /// Merges the provided <paramref name="decisionRecord"/> with the template.
        /// </summary>
        /// <param name="decisionRecord">
        /// Required decision record containing the data to move.
        /// </param>
        /// <param name="templatePath">
        /// Required path to the template.
        /// </param>
        /// <returns>
        /// The markdown content for a decision record with the provided <paramref name="decisionRecord"/>
        /// data merged in.
        /// </returns>
        public static async Task<string> MergeAsync(DecisionRecord decisionRecord, string templatePath)
        {
            if (decisionRecord == null)
            {
                throw new ArgumentNullException(nameof(decisionRecord));
            }

            if (string.IsNullOrWhiteSpace(templatePath))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(templatePath));
            }

            string templateContent = _defaultTemplate;
            
            if (File.Exists(templatePath))
            {
                templateContent = await File.ReadAllTextAsync(templatePath);
            }

            return templateContent
                .Replace("NUMBER", decisionRecord.Number.ToString())
                .Replace("TITLE", decisionRecord.Title)
                .Replace("DATE", decisionRecord.CreatedOn.ToString("yyyy-MM-dd"));
        }

        private const string _defaultTemplate =
            """
            # NUMBER. TITLE

            Date: DATE

            Last Discussed: DATE

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
    }
}