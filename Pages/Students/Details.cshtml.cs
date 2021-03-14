using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentCourses.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentCourses.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly StudentCourses.Models.Context _context;

        public DetailsModel(StudentCourses.Models.Context context, ILogger<DetailsModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public Student Student { get; set; }

        [BindProperty]
        public int CourseIdToDelete {get; set;}

        [BindProperty]
        [Display(Name = "Course")]
        public int CourseIdToAdd {get; set;}
        public List<Course> AllCourses {get; set;}
        public SelectList CoursesDropDown {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data with .Include and .ThenInclude
            Student = await _context.Student.Include(s => s.StudentCourses).ThenInclude(sc => sc.Course).FirstOrDefaultAsync(m => m.StudentID == id);
            AllCourses = await _context.Course.ToListAsync();
            CoursesDropDown = new SelectList(AllCourses, "CourseID", "Description");

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteCourseAsync(int? id)
        {
            _logger.LogWarning($"OnPost: StudentId {id}, DROP course {CourseIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.Include(s => s.StudentCourses).ThenInclude(sc => sc.Course).FirstOrDefaultAsync(m => m.StudentID == id);
            //AllCourses = await _context.Course.ToListAsync();
            //CoursesDropDown = new SelectList(AllCourses, "CourseID", "Description");
            
            if (Student == null)
            {
                return NotFound();
            }

            StudentCourse courseToDrop = _context.StudentCourse.Find(CourseIdToDelete, id.Value);

            if (courseToDrop != null)
            {
                _context.Remove(courseToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Student NOT enrolled in course");
            }

            return RedirectToPage(new {id = id});
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: StudentId {id}, ADD course {CourseIdToAdd}");
            if (CourseIdToAdd == 0)
            {
                ModelState.AddModelError("CourseIdToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.Include(s => s.StudentCourses).ThenInclude(sc => sc.Course).FirstOrDefaultAsync(m => m.StudentID == id);            
            AllCourses = await _context.Course.ToListAsync();
            CoursesDropDown = new SelectList(AllCourses, "CourseID", "Description");

            if (Student == null)
            {
                return NotFound();
            }

            if (!_context.StudentCourse.Any(sc => sc.CourseID == CourseIdToAdd && sc.StudentID == id.Value))
            {
                StudentCourse courseToAdd = new StudentCourse { StudentID = id.Value, CourseID = CourseIdToAdd};
                _context.Add(courseToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Student already enrolled in the course");
            }

            // Best practice is that OnPost should redirect. This clears the form data.
            // FIXME: Can we just populate the routeValues from what is already there?
            return RedirectToPage(new {id = id});
        }
    }
}
