using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrouseManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Pages.CoursePage
{
    public class CreateModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public CreateModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "SemesterName");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "SubjectName");

            Course = new Course
            {
                Status = 1 
            };
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Courses == null || Course == null)
            {
                return Page();
            }

            if (Course.Status != 1)
            {
                Course.Status = 1;
            }

            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();

            var courseList = await _context.Courses
                 .Include(c => c.Semester)
                 .Include(c => c.Subject)
                 .OrderByDescending(c => c.Id)
                 .ToListAsync();

            return RedirectToPage("./CourseMainPage");
        }
    }
}
