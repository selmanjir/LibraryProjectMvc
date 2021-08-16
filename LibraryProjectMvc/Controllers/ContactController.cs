using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;
namespace LibraryProjectMvc.Controllers
{
    public class ContactController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Contact
        public ActionResult Index()
        {
            var degerler = db.Contacts.ToList();
            return View(degerler);
        }
        public ActionResult GetMessage (int id)
        {
            var message = db.Contacts.Find(id);
            return View("GetMessage", message);
        }
    }
}