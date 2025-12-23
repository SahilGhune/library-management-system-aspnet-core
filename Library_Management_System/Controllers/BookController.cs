using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search)
        {
            var book = _context.Books.AsQueryable();
            if(!string.IsNullOrEmpty(search))
            {
                book = book.Where(b => b.Title.Contains(search));
            }
            return View(book.ToList());
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Books book)
        {
            if (!ModelState.IsValid)
                return View();
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Books UpdatedBooks)
        {
            if(!ModelState.IsValid)
                return View(UpdatedBooks);

            var book = _context.Books.Find(UpdatedBooks.Id);

            if(book == null)
                return NotFound();

            book.Title = UpdatedBooks.Title;
            book.Author = UpdatedBooks.Author;
            book.ISBN = UpdatedBooks.ISBN;
            book.Category = UpdatedBooks.Category;
            book.TotalCopies = UpdatedBooks.TotalCopies;
            book.AvailableCopies = UpdatedBooks.AvailableCopies;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);

            if( book == null )
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var book = _context.Books.Find(id);

            if(book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
