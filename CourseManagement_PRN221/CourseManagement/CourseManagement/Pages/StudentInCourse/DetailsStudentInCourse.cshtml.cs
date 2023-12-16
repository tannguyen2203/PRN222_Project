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
    public class DetailsModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public DetailsModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

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
    }
}
