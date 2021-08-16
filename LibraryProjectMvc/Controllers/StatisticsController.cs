using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{

    public class StatisticsController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Statistics
        public ActionResult Index()
        {
            var deger1 = db.Books.Count();
            ViewBag.dgr1 = deger1;

            var deger2 = db.Users.Count();
            ViewBag.dgr2 = deger2;

            var deger3 = db.Penalties.Sum(x => x.Price);
            ViewBag.dgr3 = deger3;

            var deger4 = db.Books.Where(x => x.BookStatus == false).Count();
            ViewBag.dgr4 = deger4;

            var deger5 = db.Categories.Count();
            ViewBag.dgr5 = deger5;

            var deger6 = db.UserMostBook().FirstOrDefault();
            ViewBag.dgr6 = deger6;

            var deger7 = db.BookMostBooks().FirstOrDefault();
            ViewBag.dgr7 = deger7;

            var deger8 = db.AuthorMostBook().FirstOrDefault();
            ViewBag.dgr8 = deger8;

            var deger9 = db.PublisherMostBookk().FirstOrDefault();
            ViewBag.dgr9 = deger9;

            var deger10 = db.EmployeeMostActions().FirstOrDefault();
            ViewBag.dgr10 = deger10;

            var deger11 = db.Contacts.Count();
            ViewBag.dgr11 = deger11;

            var deger12 = db.Actions.Where(x => x.ReceiveDate == DateTime.Today).Count();
            ViewBag.dgr12 = deger12;
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/web2/resimler"), Path.GetFileName(file.FileName));
                file.SaveAs(filePath);

            }
            return RedirectToAction("Galeri");
        }
       
    }
}