using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{
    [Authorize]
    public class UserPanelController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var userName = (string)Session["UserName"];
            var degerler = db.Users.FirstOrDefault(x => x.UserName == userName);
            List<SelectListItem> deger1 = (from e in db.EducationStatuses.ToList()
                                           select new SelectListItem
                                           {
                                               Text = e.EducationStatus,
                                               Value = e.EducationStatusId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(Users u)
        {
            var user = (string)Session["UserName"];
            var member = db.Users.FirstOrDefault(x => x.UserName == user);
            member.FirstName = u.FirstName;
            member.LastName = u.LastName;
            member.Mail = u.Mail;
            member.Password = u.Password;
            member.Telephone = u.Telephone;
            member.Photo = u.Photo;
            member.School = u.School;
            var es = db.EducationStatuses.Where(e => e.EducationStatusId == u.EducationStatuses.EducationStatusId).FirstOrDefault();
            member.EducationStatusId = es.EducationStatusId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MyBooks()
        {
            var user = (string)Session["UserName"];
            var id = db.Users.Where(x => x.UserName == user.ToString()).Select(z => z.UserId).FirstOrDefault();
            var degerler = db.Actions.Where(x => x.UserId == id).ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
        
    }
}