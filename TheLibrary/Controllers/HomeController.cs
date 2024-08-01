using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TheLibrary.DAL;
using TheLibrary.Models;

namespace TheLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Library()
        {
            List<Library> library = Data.Get.Librarys.ToList();
            return View(library);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddLibrary(Library library)
        {
            Data.Get.Librarys.Add(library);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }

        public IActionResult Create()
        {
            return View(new Library());
        }

        public IActionResult Shelf(int id)
        {
            List<Shelf> allShelf = Data.Get.shelfs.ToList().FindAll(shelf => shelf.Library.ID == id);

            return View(allShelf);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(Shelf shelf)
        {
            Shelf newShelf = new Shelf();
            newShelf.height = shelf.height;
            newShelf.width = shelf.width;
            newShelf.Library = Data.Get.Librarys.FirstOrDefault(l => l.ID  == shelf.ID);

            Data.Get.shelfs.Add(newShelf);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }

        public IActionResult CreateShelf(int id)
        {
            return View(new Shelf());
        }

        public IActionResult AllBooks(int id)
        {
            List<Book> allBooks = Data.Get.books.ToList().FindAll(b => b.Shelf.ID == id);

            return View(allBooks);
        }

        public IActionResult CreateBook(int id)
        {
            return View(new Book());
        }

        public IActionResult AddBook(Book book)
        {
            Book newBook = new Book();
            newBook.BookName = book.BookName;
            newBook.height = book.height;
            newBook.width = book.width;
            newBook.Shelf = Data.Get.shelfs.FirstOrDefault(l => l.ID == book.ID);

            Data.Get.books.Add(newBook);
            Data.Get.SaveChanges();
            return RedirectToAction("Library");
        }
    }
}
