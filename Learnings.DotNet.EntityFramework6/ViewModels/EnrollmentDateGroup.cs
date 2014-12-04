using System;
using System.ComponentModel.DataAnnotations;

namespace Learnings.DotNet.EntityFramework6.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}