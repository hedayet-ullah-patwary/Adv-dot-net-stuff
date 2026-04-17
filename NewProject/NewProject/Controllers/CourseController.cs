using Microsoft.AspNetCore.Mvc;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class CourseController : Controller
    {
        List<Course> courses = new List<Course>
        {
            new Course { Id = 101, Title = "C# Programming", Credit = 3, Semester = "1st" },
            new Course { Id = 102, Title = "Database Systems", Credit = 3, Semester = "2nd" },
            new Course { Id = 103, Title = "Web Development", Credit = 4, Semester = "1st" },
            new Course { Id = 104, Title = "Algorithms", Credit = 3, Semester = "3rd" }
        };

        [Route("Course/List/{semester?}")]
        public IActionResult List(string? semester)
        {
            if (string.IsNullOrEmpty(semester))
            {
                return View(courses);
            }

            List<Course> filteredCourses = new List<Course>();

            foreach (var c in courses)
            {
                if (c.Semester.ToLower() == semester.ToLower())
                {
                    filteredCourses.Add(c);
                }
            }
            return View(filteredCourses);
        }
    }
}
