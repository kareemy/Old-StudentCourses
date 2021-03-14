using Microsoft.EntityFrameworkCore;

namespace StudentCourses.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(s => new {s.CourseID, s.StudentID});
        }

        public DbSet<Course> Course {get; set;}
        public DbSet<Student> Student {get; set;}
        public DbSet<StudentCourse> StudentCourse {get; set;}
    }
}