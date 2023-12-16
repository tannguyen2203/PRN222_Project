using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrouseManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Pages.SemesterPage
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
            return Page();
        }

        [BindProperty]
        public Semester Semester { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Semesters == null || Semester == null)
            {
                return Page();
            }
            int randomId = GenerateRandomId();

            while (await _context.Semesters.AnyAsync(s => s.Id == randomId))
            {
                randomId = GenerateRandomId();
            }

            Semester.Id = randomId;

            _context.Semesters.Add(Semester);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SemesterPage");
        }

        private int GenerateRandomId()
        {
            Random random = new Random();
            return random.Next(5, 20); 
        }
    }
}
