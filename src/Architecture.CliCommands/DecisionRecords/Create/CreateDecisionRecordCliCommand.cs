using System.Threading.Tasks;

using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.CliCommands;
using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Architecture.CliCommands.DecisionRecords.Create
{
    /// <summary>
    /// CLI command for creating a new architecture decision record.
    /// </summary>
    [Command(Name = "create", Description = "Creates a new architecture decision record.")]
    public class CreateDecisionRecordCliCommand : InteractiveCliCommand
    {
        /// <inheritdoc />
        public CreateDecisionRecordCliCommand(
            IConsole console, 
            IPrompt prompt,
            IDecisionRecordReader decisionRecordReader,
            IDecisionRecordWriter decisionRecordWriter) 
            : base(console, prompt)
        {
            _decisionRecordReader = decisionRecordReader;
            _decisionRecordWriter = decisionRecordWriter;
        }

        /// <summary>
        /// Gets or initializes the title for the decision record.
        /// </summary>
        [Option(
            "-t|--title",
            CommandOptionType.SingleValue,
            Description = "The title for the decision record.")]
        [Prompt("Title")]
        public string Title { get; init; } = null!;

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            Prompt.PromptForAllOptions(this);
            DecisionRecord? lastDecision = await _decisionRecordReader.ReadLatestAsync();

            ushort decisionNumber = 1;

            if (lastDecision != null)
            {
                decisionNumber = (ushort)(lastDecision.Number + 1);
            }

            await _decisionRecordWriter.WriteDecisionAsync(new DecisionRecord(decisionNumber, Title));
            
            return 1;
        }
        
        private readonly IDecisionRecordReader _decisionRecordReader;
        private readonly IDecisionRecordWriter _decisionRecordWriter;
    }
}