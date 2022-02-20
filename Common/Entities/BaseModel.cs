// <copyright file="BaseModel.cs" company="Demo Company">
// Copyright (c) Demo Company. All rights reserved.
// </copyright>
// <summary>Base Model.</summary>

namespace Common.Common.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Dapper;

    /// <summary>
    /// Class BaseModel: Contains method for the Grid Operation.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BaseModel : BaseViewModel
    {
        /// <summary>
        /// The Default Username.
        /// </summary>
        public const string DefaultUserName = "system";

        private string enteredBy = DefaultUserName;
        private DateTime? enteredOn = DateTime.UtcNow;
        private string modifiedBy = DefaultUserName;
        private DateTime? modifiedOn = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the Entered By.
        /// It contains userid of user who had enter record.
        /// </summary>
        /// <value>
        /// The Entered By.
        /// </value>
        [IgnoreUpdate]
        public string EnteredBy
        {
            get => enteredBy;
            set => enteredBy = value ?? DefaultUserName;
        }

        /// <summary>
        /// Gets or sets the Entered on.
        /// /// It contains record's insertion date.
        /// </summary>
        /// <value>
        /// The Entered on.
        /// </value>
        [IgnoreUpdate]
        public DateTime? EnteredOn
        {
            get => enteredOn;
            set => enteredOn = value ?? DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the Modified By.
        /// It contains userid of user who had last modify particular record.
        /// </summary>
        /// <value>
        /// The Modified By.
        /// </value>
        public string ModifiedBy
        {
            get => modifiedBy;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = enteredBy ?? DefaultUserName;
                }

                modifiedBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the modified on.
        /// /// It contains record's last modification date.
        /// </summary>
        /// <value>
        /// The modified on.
        /// </value>
        public DateTime? ModifiedOn
        {
            get => modifiedOn;
            set
            {
                if (value == null)
                {
                    value = enteredOn ?? DateTime.UtcNow;
                }

                modifiedOn = value;
            }
        }
    }
}
