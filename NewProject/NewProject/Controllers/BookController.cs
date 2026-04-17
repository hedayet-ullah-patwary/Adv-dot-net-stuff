using Microsoft.AspNetCore.Mvc;
using NewProject.Models;

namespace NewProject.Controllers
{
    public class BookController : Controller
    {
        List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "C# Basics", Author = "John Doe", Category = "Programming" },
            new Book { Id = 2, Title = "ASP.NET Core", Author = "Jane Smith", Category = "Programming" },
            new Book { Id = 3, Title = "Data Science", Author = "Alan Turing", Category = "Data" },
            new Book { Id = 4, Title = "Clean Code", Author = "Robert Martin", Category = "Development" }
        };

        public IActionResult List(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View(books);
            }

            List<Book> filteredBooks = new List<Book>();

            foreach (var b in books)
            {
                if (b.Category.ToLower() == id.ToLower())
                {
                    filteredBooks.Add(b);
                }
            }
            return View(filteredBooks);
        }
    }
}
