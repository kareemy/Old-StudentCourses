using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentCourses.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Student.Any())
                {
                    return;
                }

                List<Student> students = new List<Student> {
                    new Student {FirstName="Laurie", LastName="Cornfoot"},
                    new Student {FirstName="Conni", LastName="Spriggen"},
                    new Student {FirstName="Darsey", LastName="Pervoe"},
                    new Student {FirstName="Ninetta", LastName="Seccombe"},
                    new Student {FirstName="Sibilla", LastName="Louisot"},
                    new Student {FirstName="Harli", LastName="Jencken"},
                    new Student {FirstName="Lisa", LastName="Dorrian"},
                    new Student {FirstName="Cary", LastName="Witt"},
                    new Student {FirstName="Hallsy", LastName="Choppen"},
                    new Student {FirstName="Sanson", LastName="Feyer"},
                    new Student {FirstName="Stearn", LastName="Hutchason"},
                    new Student {FirstName="Hewet", LastName="Gamlen"},
                    new Student {FirstName="Sheffie", LastName="Dicte"},
                    new Student {FirstName="Dot", LastName="Ralton"},
                    new Student {FirstName="Drusi", LastName="MacGovern"},
                    new Student {FirstName="Izak", LastName="Rosenkranc"},
                    new Student {FirstName="Clarinda", LastName="Rolling"},
                    new Student {FirstName="Coleen", LastName="Forcade"},
                    new Student {FirstName="Gray", LastName="Madner"},
                    new Student {FirstName="Rowan", LastName="Bursnell"},
                    new Student {FirstName="Kipp", LastName="Kiddell"},
                    new Student {FirstName="Iosep", LastName="Morville"},
                    new Student {FirstName="Martyn", LastName="Bhar"},
                    new Student {FirstName="Antoinette", LastName="Hanhardt"},
                    new Student {FirstName="Thor", LastName="Candy"},
                    new Student {FirstName="Beryl", LastName="Spikings"},
                    new Student {FirstName="Margeaux", LastName="Sturzaker"},
                    new Student {FirstName="Horatio", LastName="Chessel"},
                    new Student {FirstName="Vasili", LastName="Dore"},
                    new Student {FirstName="Flemming", LastName="Magnay"},
                };
                context.AddRange(students);

                List<Course> courses = new List<Course> {
                    new Course {Description = "CIDM 1315"},
                    new Course {Description = "CIDM 2315"},
                    new Course {Description = "CIDM 3312"},
                    new Course {Description = "CIDM 3350"},
                    new Course {Description = "CIDM 3385"},
                    new Course {Description = "CIDM 4360"},
                    new Course {Description = "CIDM 4390"},
                };
                context.AddRange(courses);

                List<StudentCourse> enrollment = new List<StudentCourse> {
                    new StudentCourse {CourseID = 1, StudentID = 1},
                    new StudentCourse {CourseID = 1, StudentID = 26},
                    new StudentCourse {CourseID = 1, StudentID = 5},
                    new StudentCourse {CourseID = 1, StudentID = 18},
                    new StudentCourse {CourseID = 1, StudentID = 2},
                    new StudentCourse {CourseID = 1, StudentID = 20},
                    new StudentCourse {CourseID = 1, StudentID = 25},
                    new StudentCourse {CourseID = 1, StudentID = 6},
                    new StudentCourse {CourseID = 1, StudentID = 27},

                    new StudentCourse {CourseID = 2, StudentID = 4},
                    new StudentCourse {CourseID = 2, StudentID = 2},
                    new StudentCourse {CourseID = 2, StudentID = 13},
                    new StudentCourse {CourseID = 2, StudentID = 11},
                    new StudentCourse {CourseID = 2, StudentID = 14},
                    new StudentCourse {CourseID = 2, StudentID = 10},
                    new StudentCourse {CourseID = 2, StudentID = 29},
                    new StudentCourse {CourseID = 2, StudentID = 7},
                    new StudentCourse {CourseID = 2, StudentID = 24},
                };
                context.AddRange(enrollment);

                context.SaveChanges();
            }
        }
    }
}