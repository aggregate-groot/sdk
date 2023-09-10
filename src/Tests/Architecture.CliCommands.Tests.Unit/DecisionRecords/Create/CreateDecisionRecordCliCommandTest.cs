using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;
using NSubstitute;
using Xunit;

using AggregateGroot.Architecture.CliCommands.DecisionRecords.Create;
using AggregateGroot.Architecture.Tools.DecisionRecords;
using AggregateGroot.CliCommands;

namespace AggregateGroot.Architecture.CliCommands.Tests.Unit.DecisionRecords.Create
{
    /// <summary>
    /// Unit tests for the <see cref="CreateDecisionRecordCliCommand" /> class.
    /// </summary>
    public class CreateDecisionRecordCliCommandTest
    {
        /// <summary>
        /// Tests that a decision record number is set to 1 if it is the first one.
        /// </summary>
        [Fact]
        public async Task Should_Set_Decision_Number_To_One_When_No_Other_Decisions_Exist()
        {
            _decisionRecordReader
                .ReadLatestAsync()
                .Returns((DecisionRecord?)null!);
            
            const string title = "Some Decision";
            CreateDecisionRecordCliCommand command = CreateCommand(title);

            DecisionRecord? decisionRecord = null;

            await _decisionRecordWriter
                    .WriteDecisionAsync(Arg.Do<DecisionRecord>(captured => decisionRecord = captured));

            await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.NotNull(decisionRecord);
            Assert.Equal(title, decisionRecord.Title);
            Assert.Equal(1, decisionRecord.Number);
        }

        /// <summary>
        /// Tests that the decision record number incremented by 1 from the last
        /// created decision.
        /// </summary>
        [Fact]
        public async Task Should_Increment_Decision_Number_From_Last_Decision()
        {
            DecisionRecord lastDecision = new(255, "Decision 255");
            
            _decisionRecordReader
                .ReadLatestAsync()
                .Returns(lastDecision);
            
            const string title = "Some Decision";
            CreateDecisionRecordCliCommand command = CreateCommand(title);

            DecisionRecord? decisionRecord = null;

            await _decisionRecordWriter
                .WriteDecisionAsync(Arg.Do<DecisionRecord>(captured => decisionRecord = captured));

            await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.NotNull(decisionRecord);
            Assert.Equal(title, decisionRecord.Title);
            Assert.Equal(256, decisionRecord.Number);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CreateDecisionRecordCliCommand"/>
        /// configured for testing.
        /// </summary>
        /// <param name="title">
        /// The title of the decision record to create.
        /// </param>
        private CreateDecisionRecordCliCommand CreateCommand(string title)
        {
            return new CreateDecisionRecordCliCommand(
                _console,
                _prompt,
                _decisionRecordReader,
                _decisionRecordWriter)
            {
                Title = title
            };
        }

        private readonly IConsole _console = Substitute.For<IConsole>();
        private readonly IPrompt _prompt = Substitute.For<IPrompt>();
        private readonly IDecisionRecordReader _decisionRecordReader = Substitute.For<IDecisionRecordReader>();
        private readonly IDecisionRecordWriter _decisionRecordWriter = Substitute.For<IDecisionRecordWriter>();
    }
}