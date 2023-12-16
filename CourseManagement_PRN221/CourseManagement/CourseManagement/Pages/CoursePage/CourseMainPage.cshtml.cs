using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrouseManagement.Repository.Models;
using Repository.Repository;

namespace CourseManagement.Pages.CoursePage
{
    public class IndexModel : PageModel
    {
        public CourseRepository CourseRepo { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }
        public List<Course> searchResults { get; set; }
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public IndexModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;
        public IList<Course> courseList { get; set; } = default!;

        public async Task OnGetAsync()
        {

            if (_context.Courses.Any())
            {
                Course = await _context.Courses
                .Include(c => c.Semester)
                .Include(c => c.Subject).ToListAsync();
                courseList = Course.OrderByDescending(c => c.Id).ToList();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchResults = await CourseRepo.GetByCourseCode(searchTerm);
                return Page();
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
