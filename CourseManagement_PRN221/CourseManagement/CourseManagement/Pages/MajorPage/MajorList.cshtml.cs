﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CrouseManagement.Repository.Models;

namespace CourseManagement.Pages.MajorPage
{
    public class IndexModel : PageModel
    {
        private readonly CrouseManagement.Repository.Models.CourseManagementContext _context;

        public IndexModel(CrouseManagement.Repository.Models.CourseManagementContext context)
        {
            _context = context;
        }

        public IList<Major> Major { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Majors != null)
            {
                Major = await _context.Majors.ToListAsync();
            }
        }
    }
}
