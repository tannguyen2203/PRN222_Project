﻿using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? SubjectCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? MajorId { get; set; }

        public virtual Major? Major { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
