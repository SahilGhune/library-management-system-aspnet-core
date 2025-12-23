using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Controllers
{
    public class IssueRecordController : Controller
    {
        private readonly AppDbContext _context;

        public IssueRecordController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var records = _context.IssueRecord
                .Include(i => i.Book)
                .Include(i => i.Member)
                .ToList();
            return View(records);
        }

        [HttpGet]
        public IActionResult Issue()
        {
            ViewBag.Books = _context.Books.ToList();
            ViewBag.Member = _context.Member.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Issue(IssuedRecord record)
        {
            var book = _context.Books.Find(record.BookId);

            if(book == null || book.AvailableCopies <= 0)
            {
                ModelState.AddModelError("", "Book is Not Available.");
                return View();
            }

            record.IssueDate = DateTime.Now;
            record.DueDate = DateTime.Now.AddDays(7);
            record.IsReturned = false;

            book.AvailableCopies--;

            _context.IssueRecord.Add(record);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Return(int id)
        {
            var record = _context.IssueRecord
                .Include(i => i.Book)
                .Include(i => i.Member)
                .FirstOrDefault(i => i.Id == id);

            return View(record);
        }

        [HttpPost,ActionName("Return")]
        public IActionResult ReturnedConfirm(int id)
        {
            var record = _context.IssueRecord.Find(id);
            var book = _context.Books.Find(record.BookId);
            record.IsReturned = true;
            record.ReturnDate = DateTime.Now;

            book.AvailableCopies++;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
