using Microsoft.AspNetCore.Mvc;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Profile(int id)
        {
            var student = new Student
            {
                Id = id,
                Name = "Ariful Islam",
                Age = 20,
                Department = "CSE",
                CGPA = 3.85
            };

            return View(student);
        }
    }
}
