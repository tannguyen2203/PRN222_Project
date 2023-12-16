using CrouseManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Pages.CoursePage
{
    public class CourseStudentDetailsModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public CourseStudentDetailsModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;
        public List<Session> Sessions { get; set; } = new List<Session>();
        [BindProperty]
        public CrouseManagement.Repository.Models.StudentInCourse StudentInCourse { get; set; } = default!;

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

        public async Task<IActionResult> OnPostJoinAsync(int courseId)
        {
            if (!ModelState.IsValid || _context.StudentInCourses == null || StudentInCourse == null)
            {
                return Page();
            }

            int userId = HttpContext.Session.GetInt32("Id") ?? 0;

            if (userId == 0)
            {
                return RedirectToPage("../Login");
            }

            if (StudentInCourse == null)
            {
                StudentInCourse = new CrouseManagement.Repository.Models.StudentInCourse();
            }

            StudentInCourse.StudentId = userId;
            StudentInCourse.CourseId = courseId;


            _context.StudentInCourses.Add(StudentInCourse);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CourseStudentDetails");
        }
    }
}
