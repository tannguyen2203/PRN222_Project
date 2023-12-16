using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages.CoursePage
{
    public class DetailsModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public DetailsModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;
        public List<Session> Sessions { get; set; } = new List<Session>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Sessions)
                .ThenInclude(r => r.Room)
                .Include(c => c.StudentInCourses)
                .ThenInclude(sic => sic.Student)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
                Sessions = course.Sessions.ToList();
            }

            return Page();
        }
    }
}
