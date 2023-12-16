using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages.StudentInCourse
{
    public class CreateModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public CreateModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int StudentId { get; set; }

        [BindProperty]
        public int CourseId { get; set; }

        public IActionResult OnGet()
        {
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CrouseManagement.Repository.Models.StudentInCourse StudentInCourse { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.StudentInCourses == null || StudentInCourse == null)
            {
                return Page();
            }

            StudentInCourse.StudentId = StudentId;
            StudentInCourse.CourseId = CourseId;


            _context.StudentInCourses.Add(StudentInCourse);
            await _context.SaveChangesAsync();

            return RedirectToPage("../CoursePage/CourseMainPage");
        }
    }
}
