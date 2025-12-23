using System.Diagnostics;
using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Dashboard stats
            ViewBag.TotalBooks = _context.Books.Count();
            ViewBag.TotalMembers = _context.Member.Count();
            ViewBag.TotalIssuedBooks = _context.IssueRecord.Count(i => !i.IsReturned);
            ViewBag.OverdueBooks = _context.IssueRecord.Count(i => !i.IsReturned && DateTime.Now > i.DueDate);

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
    }
}
