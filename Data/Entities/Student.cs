// <copyright file="EventLog.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary> Event Log Class.</summary>

namespace Demo.Data.Entities
{
    using Dapper;

    /// <summary>
    /// Class EventLog: Contain property for the Event Log details.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets EventLogGuid.
        /// </summary>
        /// <value>
        /// EventLogGuid.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        /// <value>
        /// FirstName.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        /// <value>
        /// LastName.
        /// </value>
        public string LastName { get; set; }
    }
}