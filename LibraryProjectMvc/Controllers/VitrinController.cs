using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;
using LibraryProjectMvc.Models.Classes;

namespace LibraryProjectMvc.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.bookValue = db.Books.ToList();
            cs.aboutValue = db.Abouts.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Contacts c)
        {
            db.Contacts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}