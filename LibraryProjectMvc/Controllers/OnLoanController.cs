using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{

    public class OnLoanController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: OnLoan
        public ActionResult Index()
        {
            var dgr = db.Actions.Where(a => a.ActionStatus == false).ToList();
            return View(dgr);

        }
        [HttpGet]
        public ActionResult ToLend()
        {
            List<SelectListItem>
               deger1 = (from i in db.Books.ToList() where i.BookStatus == true
                         select new SelectListItem
                         {
                             Text = i.BookId.ToString(),
                             Value = i.BookId.ToString()
                             
                         }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult ToLend(Actions a)
        {
            db.Actions.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LoanReturn(int id)
        {
            var lrn = db.Actions.Find(id);
            DateTime d1 = DateTime.Parse(lrn.ReturnDate.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            if (d3.TotalDays > 0)
            {
                ViewBag.dgr = d3.TotalDays;
            }
            else
            {
                ViewBag.dgr = 0;
            }

            return View("LoanReturn", lrn);
        }
        public ActionResult UpdateOnLoan(Actions a)
        {
            var act = db.Actions.Find(a.ActionId);
            act.UserReturnDate = a.UserReturnDate;
            act.ActionStatus = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult InvalidAction()
        {
            return View();
        }
    }
}