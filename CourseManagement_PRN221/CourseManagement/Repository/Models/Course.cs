using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Course
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }
        public string? CourseCode { get; set; }
        public string? Instructor { get; set; }
        public string? CourseDescription { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int Status { get; set; }

        public virtual Semester? Semester { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
