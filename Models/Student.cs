using System.ComponentModel.DataAnnotations;

namespace StudentCourses.Models
{
    public class Student
    {
        public int StudentID {get; set;}
        [Display(Name = "First Name")]
        [Required]
        public string FirstName {get; set;} = string.Empty;
        [Display(Name = "Last Name")]
        [Required]
        public string LastName {get; set;} = string.Empty;
        public List<StudentCourse>? StudentCourses {get; set;} = default!; // Navigation Property. Student can have MANY StudentCourses

    }
}