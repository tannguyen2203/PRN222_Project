using System;
using System.Collections.Generic;

namespace CrouseManagement.Repository.Models
{
    public partial class Room
    {
        public Room()
        {
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public string? RoomCode { get; set; }
        public string? Detail { get; set; }
        public int? Status { get; set; }
        public string? RoomName { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
