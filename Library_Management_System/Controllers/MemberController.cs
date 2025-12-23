using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;

        public MemberController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var members = _context.Member.ToList();
            return View(members);
        }

        public IActionResult Details(int id)
        {
            var members = _context.Member.Find(id);

            if(members == null)
                return NotFound();

            return View(members);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member Member)
        {
            if(!ModelState.IsValid)
                return View(Member);

            _context.Member.Add(Member);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var member = _context.Member.Find(id);

            if(member == null)
                return NotFound();

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member UpdatedMember)
        {
            if (ModelState.IsValid)
                return View(UpdatedMember);

            var member = _context.Member.Find(UpdatedMember.Id);

            if(UpdatedMember == null)
                return NotFound();

            member.Name = UpdatedMember.Name;
            member.Email = UpdatedMember.Email;
            member.Phone = UpdatedMember.Phone;
            member.Address = UpdatedMember.Address;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var member = _context.Member.Find(id);

            if(member == null)
                return NotFound();

            return View(member);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var member = _context.Member.Find(id);

            if(member == null)
                return NotFound();

            _context.Member.Remove(member);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
