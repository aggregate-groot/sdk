using System;

namespace AggregateGroot.Architecture.Tools.DecisionRecords
{
    /// <summary>
    /// Represents an architecture decision record.
    /// </summary>
    public class DecisionRecord
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DecisionRecord"/> class.
        /// </summary>
        /// <param name="number">
        /// Required number of the decision record.
        /// </param>
        /// <param name="title">
        /// Required title for the decision record.
        /// </param>
        /// <param name="createdOn">
        /// Required date the the decision record was created.
        /// </param>
        public DecisionRecord(ushort number, string title, DateOnly createdOn)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(title));
            }

            Number = number;
            Title = title;
            CreatedOn = createdOn;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DecisionRecord"/> class.
        /// </summary>
        public DecisionRecord(ushort number, string title)
            : this(number, title, DateOnly.FromDateTime(DateTime.Today))
        {
        }
        
        /// <summary>
        /// Gets the decision record number.
        /// </summary>
        public ushort Number { get;  }
        
        /// <summary>
        /// Gets the title of the decision record.
        /// </summary>
        public string Title { get;  }

        /// <summary>
        /// Gets the date the decision record was created on.
        /// </summary>
        public DateOnly CreatedOn { get; private set; }
    }
}