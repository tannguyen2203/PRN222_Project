using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string? MajorCode { get; set; }
        public string? MajorName { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
