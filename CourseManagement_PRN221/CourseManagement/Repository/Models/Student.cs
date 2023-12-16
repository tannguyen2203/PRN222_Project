using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Student
    {
        public Student()
        {
            Attendences = new HashSet<Attendence>();
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public int? Status { get; set; }
        public int? MajorId { get; set; }
        public string? Password {  get; set; }

        public virtual Major? Major { get; set; }
        public virtual ICollection<Attendence> Attendences { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
