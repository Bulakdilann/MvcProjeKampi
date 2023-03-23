using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        Context context = new Context();
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalue = cm.GetByID(id);
            return View(contactvalue);
        }
        public PartialViewResult MessageMenuPartial()
        {
            ViewBag.toplam1 = context.Messages.Count(x=>x.ReceiverMail=="admin@gmail.com");
            ViewBag.toplam2= context.Messages.Count(x => x.SenderMail == "admin@gmail.com");
            ViewBag.iletisim= context.Contacts.Count();

            return PartialView();
            
        }
    }
}