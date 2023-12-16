using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class StudentInCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int? Status { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
