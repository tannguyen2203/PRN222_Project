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
    public class IndexModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public IndexModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        public IList<CrouseManagement.Repository.Models.StudentInCourse> StudentInCourse { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            int userId = HttpContext.Session.GetInt32("Id") ?? 1;


            if (userId == 0)
            {
                return RedirectToPage("../Login");
            }

            StudentInCourse = await _context.StudentInCourses
                .Include(sic => sic.Course)
                .Include(sic => sic.Student)
                .Where(sic => sic.StudentId == userId)
                .ToListAsync();

            return Page();
        }
    }
}
