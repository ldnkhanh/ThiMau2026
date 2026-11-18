using LeDuyNgocKhanh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace LeDuyNgocKhanh.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _db;
        public HomeController(QLNhaSachContext db)
        {
            _db = db;
        }
        //c3
        public IActionResult Index()
        {
            var ds = _db.Saches.Where(s => s.Gia >= 100).ToList();
            return View(ds);
        }

        public IActionResult LocTheoTheLoai(int maTl)
        {
            var ds = _db.Saches.Where(s => s.MaTL == maTl).ToList();
            return PartialView("Khanh_MainContent", ds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTL = new SelectList(_db.TheLoais, "MaTL", "TenTL");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _db.Saches.Add(sach);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTL = new SelectList(_db.TheLoais, "MaTL", "TenTL", sach.MaTL);
            return View(sach);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
