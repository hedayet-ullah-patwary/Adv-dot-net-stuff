using LabTaskValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabTaskValidation.Controllers
{
    public class StudentController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                return Content("Validation Successful!");
            }
            return View(student);
        }
    }
}
