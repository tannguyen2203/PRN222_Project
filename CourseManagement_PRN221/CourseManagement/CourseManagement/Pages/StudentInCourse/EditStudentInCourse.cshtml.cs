using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages.StudentInCourse
{
    public class EditModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public EditModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrouseManagement.Repository.Models.StudentInCourse StudentInCourse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentInCourses == null)
            {
                return NotFound();
            }

            var studentincourse =  await _context.StudentInCourses.FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentincourse == null)
            {
                return NotFound();
            }
            StudentInCourse = studentincourse;
           ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
           ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentInCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentInCourseExists(StudentInCourse.StudentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentInCourseExists(int id)
        {
          return (_context.StudentInCourses?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
