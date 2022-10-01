using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentCourses.Models;

namespace StudentCourses.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentCourses.Models.Context _context;

        public IndexModel(StudentCourses.Models.Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.Include(s => s.StudentCourses!).ThenInclude(sc => sc.Course).ToListAsync();
            }
        }
    }
}
