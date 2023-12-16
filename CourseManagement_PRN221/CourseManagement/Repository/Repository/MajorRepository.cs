using CrouseManagement.Repository.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrouseManagement.Repository.Repository
{
    public class MajorRepository : RepositoryBase<Major>
    {
        public MajorRepository(CourseManagementContext context) : base(context)
        {
        }
    }
}
