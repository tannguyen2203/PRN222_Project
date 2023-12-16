using CrouseManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class StudentInCourseRepository : RepositoryBase<StudentInCourse>
    {
        public StudentInCourseRepository(CourseManagementContext context) : base(context)
        {
        }
    }
}
