using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages.SubjectPage
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
            ViewData["MajorId"] = new SelectList(_context.Majors, "Id", "MajorCode");
            return Page();
        }

        [BindProperty]
        public Subject Subject { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Subjects == null || Subject == null)
            {
                return Page();
            }

            Subject.CreateDate = DateTime.Now;

            _context.Subjects.Add(Subject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SubjectPage");
        }
    }
}
