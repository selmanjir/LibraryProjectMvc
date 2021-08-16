using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;
namespace MvcLibraryProject.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        LibraryProjectEntities db = new LibraryProjectEntities();
        public ActionResult Index()
        {
            var authors = db.Authors.ToList();
            return View(authors);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Authors author)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAuthor");
            }
            db.Authors.Add(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAuthor(int id)
        {
            var author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetAuthor(int id)
        {
            var author = db.Authors.Find(id);
            return View("GetAuthor", author);
        }
        public ActionResult UpdateAuthor(Authors a)
        {
            var author = db.Authors.Find(a.AuthorId);
            author.AuthorFirstName = a.AuthorFirstName;
            author.AuthorLastName = a.AuthorLastName;
            author.Detail = a.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}