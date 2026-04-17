using Microsoft.AspNetCore.Mvc;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "Atif", Salary = 60000, Designation = "Manager" },
                new Employee { Name = "Rahim", Salary = 45000, Designation = "Developer" },
                new Employee { Name = "Karim", Salary = 55000, Designation = "Designer" },
                new Employee { Name = "Sufia", Salary = 40000, Designation = "Intern" }
            };

            return View(employees);
        }
    }
}