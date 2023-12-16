using CrouseManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CourseRepository : RepositoryBase<Course>
    {
        private readonly DbSet<Course> _dbSet;

        public CourseRepository(CourseManagementContext context) : base(context)
        {

        }

        public async Task<List<Course>> GetByCourseCode(string courseCode)
        {
            return await _dbSet.Where(c => c.CourseCode == courseCode).ToListAsync();
        }

       

    }
}
