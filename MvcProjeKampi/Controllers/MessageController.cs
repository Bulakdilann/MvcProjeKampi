using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        
        public ActionResult Inbox()
        {
           
            var messagevalues = mm.GetListInbox();
            return View(messagevalues);
        }
        public ActionResult Sendbox()
        {
            var messagelist = mm.GetListSendbox();
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            mm.MesssageAdd(p);
            return View();
        }

    }
}