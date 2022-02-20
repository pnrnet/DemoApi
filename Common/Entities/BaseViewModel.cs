// <copyright file="BaseViewModel.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>Base Model For valid to and from.</summary>

namespace Common.Common.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class BaseModel: Contains method for the Grid Operation.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BaseViewModel
    {
        private DateTime validFrom;

        /// <summary>
        /// Gets or sets the ValidFrom.
        /// /// It contains record's insertion date.
        /// </summary>
        /// <value>
        /// The ValidFrom.
        /// </value>
        public DateTime ValidFrom
        {
            get => validFrom;
            set
            {
                if (value == DateTime.MinValue)
                {
                    value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                }
                else
                {
                    value = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
                }

                validFrom = value;
            }
        }

        /// <summary>
        /// Gets or sets the ValidTo.
        /// /// It contains record's insertion date.
        /// </summary>
        /// <value>
        /// The ValidTo.
        /// </value>
        public DateTime? ValidTo { get; set; }
    }
}
