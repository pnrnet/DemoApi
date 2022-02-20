using Demo.Dto.Models;
using System.Collections.Generic;

namespace Demo.Dto.Responses
{
    public class StudentClassResponceDto : StudentDto
    {

        /// <summary>
        /// Gets or sets Classs.
        /// </summary>
        /// <value>
        /// Classs.
        /// </value>
        public List<ClassDto> Classs { get; set; }
    }
}
