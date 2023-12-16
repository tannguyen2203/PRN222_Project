using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Session
    {
        public Session()
        {
            Attendences = new HashSet<Attendence>();
        }

        public int Id { get; set; }
        public string? SessionDate { get; set; }
        public TimeSpan? SlotStart { get; set; }
        public TimeSpan? SlotEnd { get; set; }
        public int? CourseId { get; set; }
        public int? RoomId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ICollection<Attendence> Attendences { get; set; }
    }
}
