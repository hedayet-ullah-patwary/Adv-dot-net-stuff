using Microsoft.AspNetCore.Mvc;
using RegistrationUsingSession.DTOs;
using RegistrationUsingSession.EF;
using RegistrationUsingSession.EF.Tables;

namespace RegistrationUsingSession.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationContext db;

        public RegistrationController(RegistrationContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RegistrationDTO u)
        {
            if (u == null || string.IsNullOrEmpty(u.Email) || string.IsNullOrEmpty(u.Pass))
            {
                ViewBag.Error = "Please fill all fields!";
                return View(u);
            }

            var user = (from r in db.Registrations
                        where r.Email == u.Email.Trim() && r.Pass == u.Pass.Trim()
                        select r).FirstOrDefault();

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserName", user.Name);

                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Email or Password!";
            return View(u);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrationDTO u)
        {
            if (ModelState.IsValid)
            {
                var newUser = new Registration
                {
                    Name = u.Name,
                    Email = u.Email,
                    Pass = u.Pass
                };

                db.Registrations.Add(newUser);
                db.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(u);
        }


        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
