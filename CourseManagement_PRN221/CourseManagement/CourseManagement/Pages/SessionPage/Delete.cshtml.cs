using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages.SessionPage
{
    public class DeleteModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public DeleteModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Session Session { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }

            var session = await _context.Sessions.FirstOrDefaultAsync(m => m.Id == id);

            if (session == null)
            {
                return NotFound();
            }
            else 
            {
                Session = session;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sessions == null)
            {
                return NotFound();
            }
            var session = await _context.Sessions.FindAsync(id);

            if (session != null)
            {
                Session = session;
                _context.Sessions.Remove(Session);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./SessionPage");
        }
    }
}
