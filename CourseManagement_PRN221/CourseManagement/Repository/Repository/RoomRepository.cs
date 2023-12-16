using CrouseManagement.Repository.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrouseManagement.Repository.Repository
{
    public class RoomRepository : RepositoryBase<Room>
    {
        public RoomRepository(CourseManagementContext context) : base(context)
        {
        }
    }
}
