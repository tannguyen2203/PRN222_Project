using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrouseManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Pages.SessionPage
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
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
        ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "RoomCode");
            return Page();
        }

        [BindProperty]
        public Session Session { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Sessions == null || Session == null)
            {
                return Page();
            }
            int randomId = GenerateRandomId();

            while (await _context.Semesters.AnyAsync(s => s.Id == randomId))
            {
                randomId = GenerateRandomId();
            }

            Session.Id = randomId;

            _context.Sessions.Add(Session);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SessionPage");
        }

        private int GenerateRandomId()
        {
            Random random = new Random();
            return random.Next(5, 20);
        }
    }
}
