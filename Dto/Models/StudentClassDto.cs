
using System.Collections.Generic;

namespace Demo.Dto.Models
{
    public class StudentClassDto
    {
        /// <summary>
        /// Gets or sets StudentId.
        /// </summary>
        /// <value>
        /// StudentId.
        /// </value>
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets ClassCodes.
        /// </summary>
        /// <value>
        /// ClassCodes.
        /// </value>
        public List<string> ClassCodes { get; set; }
    }
}
