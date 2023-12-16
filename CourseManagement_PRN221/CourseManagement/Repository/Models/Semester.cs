using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string? SemesterName { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? Status { get; set; }
        public string? SemesterCode { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
