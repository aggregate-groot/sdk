namespace AggregateGroot.CliCommands.Tests.Unit
{
    /// <summary>
    /// Represents a command for testing option prompting.
    /// </summary>
    public class TestCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="TestCommand"/> class.
        /// </summary>
        public TestCommand()
        {
            SomeString = default;
            SomeUShort = default;
        }
        
        /// <summary>
        /// Gets or initializes some string..
        /// </summary>
        [Prompt("Some string")]
        public string? SomeString { get; init; }
        
        /// <summary>
        /// Gets or initializes some ushort.
        /// </summary>
        [Prompt("Some ushort")]
        public ushort SomeUShort { get; init; }
    }
}