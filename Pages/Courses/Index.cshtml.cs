using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity1.Data;
using ContosoUniversity1.Models;

namespace ContosoUniversity1.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity1.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity1.Data.SchoolContext context)
        {
            _context = context;
        }


        public IList<Course> Courses { get; set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
