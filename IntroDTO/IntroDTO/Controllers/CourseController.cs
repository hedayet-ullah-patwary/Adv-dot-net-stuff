using IntroDTO.DTOs;
using IntroDTO.EF;
using IntroDTO.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace IntroDTO.Controllers
{
    public class CourseController : Controller
    {
        StudentMsASp26Context db;

        public CourseController(StudentMsASp26Context db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            //without DTO
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CourseDTO c)
        {
            if (ModelState.IsValid)
            {
                var st = new Course()
                {
                    Name = c.Name,
                    Did = c.Did
                };
                db.Courses.Add(st); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var depts = db.Departments.ToList();
            ViewBag.Departments = depts;
            return View(c); 
        }
    }
}
