using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages.StudentInCourse
{
    public class DeleteModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public DeleteModel(CrouseManagement.Repository.Models.CourseManagementContext context)
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

            var studentincourse = await _context.StudentInCourses.FirstOrDefaultAsync(m => m.StudentId == id);

            if (studentincourse == null)
            {
                return NotFound();
            }
            else 
            {
                StudentInCourse = studentincourse;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudentInCourses == null)
            {
                return NotFound();
            }
            var studentincourse = await _context.StudentInCourses.FindAsync(id);

            if (studentincourse != null)
            {
                StudentInCourse = studentincourse;
                _context.StudentInCourses.Remove(StudentInCourse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
