using LeDuyNgocKhanh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace LeDuyNgocKhanh.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly QLNhaSachContext _db;
        public TheLoaiMenuViewComponent(QLNhaSachContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var ds = _db.TheLoais.ToList();
            return View(ds); 
        }
    }
}
