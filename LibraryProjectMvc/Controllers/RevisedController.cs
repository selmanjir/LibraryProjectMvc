using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{
    public class RevisedController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Revized
        public ActionResult Index(int id)
        {
            var book = db.Books.Find(id);
            List<SelectListItem> deger1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Authors.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AuthorFirstName + ' ' + i.AuthorLastName,
                                               Value = i.AuthorId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("GetBook", book);
        }
        [HttpGet]
        public ActionResult ToRevise()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ToRevise(Actions t)
        {
            db.Actions.Add(t);
            db.SaveChanges();
            return View();
        }
        public ActionResult ReviseRemove()
        {
            return View();
        }
    }
}