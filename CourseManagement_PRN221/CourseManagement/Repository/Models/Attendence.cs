using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Attendence
    {
        public int Id { get; set; }
        public int? SessionId { get; set; }
        public DateTime? DateAttendence { get; set; }
        public int? Status { get; set; }
        public int? StudentId { get; set; }

        public virtual Session? Session { get; set; }
        public virtual Student? Student { get; set; }
    }
}
