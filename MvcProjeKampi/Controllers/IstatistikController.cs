
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    
    public class IstatistikController : Controller
    {
        
        Context _db = new Context();
        
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.deger1 = _db.Categories.Count();
            ViewBag.deger2 = _db.Headings.Count(x => x.Category.CategoryID==22).ToString();
            ViewBag.deger3 = _db.Writers.Where(x => x.WriterName.Contains("a")).Count();
            ViewBag.deger4 = _db.Categories.Where(c => c.CategoryID == _db.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
            .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();

            ViewBag.deger5 = _db.Categories.Count(x => x.CategoryStatus == true) - _db.Categories.Count(x => x.CategoryStatus == false);

            return View();
        }
    }
}