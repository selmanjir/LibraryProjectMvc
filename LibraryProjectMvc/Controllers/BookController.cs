using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{
    public class BookController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Book
        public ActionResult Index(string s)
        {
            var books = from b in db.Books select b;
            if (!string.IsNullOrEmpty(s))
            {
                books = books.Where(m => m.BookName.Contains(s));
            }

            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem>
            deger1 = (from i in db.Categories.ToList()
              select new SelectListItem
              {
                  Text = i.CategoryName,
                  Value = i.CategoryName

              }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem>
                deger2 = (from i in db.Authors.ToList()
                          select new SelectListItem
                          {
                              Text = i.AuthorLastName,
                              Value = i.AuthorLastName
                          }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Books b)
        {
            db.Books.Add(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetBook(int id)
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
        public ActionResult UpdateBook(Books s)
        {
            var book = db.Books.Find(s.BookId);
            book.BookName = s.BookName;
            book.YearOfPublication = s.YearOfPublication;
            book.Page = s.Page;
            book.Publisher = s.Publisher;
            book.BookStatus = true;

            var ctg = db.Categories.Where(c => c.CategoryId == s.Categories.CategoryId).FirstOrDefault();
            var atr = db.Authors.Where(a => a.AuthorId == s.Authors.AuthorId).FirstOrDefault();
            book.CategoryId = ctg.CategoryId;
            book.AuthorId = atr.AuthorId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ToRevise(int id)
        {
            var book = db.Books.Find(id);
            book.BookStatus = false;
            book.RevisedStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ReviseRemove(int id)
        {
            var book = db.Books.Find(id);
            book.BookStatus = true;
            book.RevisedStatus = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}