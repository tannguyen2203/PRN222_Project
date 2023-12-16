using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrouseManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseManagement.Pages.RoomPage
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
        public Room Room { get; set; } = default!;
        
        private int currentId = 10;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Rooms == null || Room == null)
            {
                return Page();
            }
            int randomId = GenerateRandomId();

            while (await _context.Semesters.AnyAsync(s => s.Id == randomId))
            {
                randomId = GenerateRandomId();
            }

            Room.Id = randomId;

            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./RoomPage");
        }

         private int GenerateRandomId()
        {
            Random random = new Random();
            return random.Next(4, 9999);
        }
    }
}
