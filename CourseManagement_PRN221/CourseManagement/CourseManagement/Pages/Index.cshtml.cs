using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public IndexModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Course = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Subject).ToListAsync();
            }
        }
    }
}
