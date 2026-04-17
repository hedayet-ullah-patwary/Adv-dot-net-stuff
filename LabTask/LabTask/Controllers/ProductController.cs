using LabTask.EF;
using LabTask.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace LabTask.Controllers
{
    public class ProductController : Controller
    {
        LabTaskContext db;
        public ProductController(LabTaskContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var data = db.Categorys.ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product d)
        {
            db.Products.Add(d); //data saved not committed
            db.SaveChanges(); //data committed //returns no of rows affected
            TempData["Msg"] = d.Name + " Created Successfully";

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var data = db.Products.Find(id); //works iwth PK
            return View(data);

        }
    }
}
