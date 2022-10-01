using System.ComponentModel.DataAnnotations;

namespace StudentCourses.Models
{
    public class Course
    {
        public int CourseID {get; set;} // Primary Key
        [Required]
        public string Description {get; set;} = string.Empty;
        public List<StudentCourse> StudentCourses {get; set;} = default!; // Navigation Property. Course can have MANY StudentCourses
    }

    public class StudentCourse
    {
        public int CourseID {get; set;}     // Composite Primary Key, Foreign Key 1
        public int StudentID {get; set;}    // Composite Primary Key, Foreign Key 2
        public Student Student {get; set;} = default!; // Navigation Property. One Student per StudentCourse
        public Course Course {get; set;} = default!;   // Navigation Property. One Course per StudentCourse
    }
}