using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{
    public class UserController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: User
        public ActionResult Index(int page = 1)
        {
            //var users = db.Users.ToList();
            var users = db.Users.ToList().ToPagedList(page, 3);
            return View(users);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            List<SelectListItem> deger1 = (from i in db.EducationStatuses.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.EducationStatus,
                                               Value = i.EducationStatus

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Users users)
        {
            if (!ModelState.IsValid)
            {
                return View("AddUser");
            }
            db.Users.Add(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetUser(int id)
        {
            var user = db.Users.Find(id);
            List<SelectListItem> deger1 = (from e in db.EducationStatuses.ToList()
                                           select new SelectListItem
                                           {
                                               Text = e.EducationStatus,
                                               Value = e.EducationStatusId.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("GetUser", user);
        }
        public ActionResult UpdateUser(Users u)
        {
            var user = db.Users.Find(u.UserId);
            user.FirstName = u.FirstName;
            user.LastName = u.LastName;
            user.Mail = u.Mail;
            user.UserName = u.UserName;
            user.Password = u.Password;
            user.School = u.School;
            var es = db.EducationStatuses.Where(e => e.EducationStatusId == u.EducationStatuses.EducationStatusId).FirstOrDefault();
            user.EducationStatusId = es.EducationStatusId;
            user.Telephone = u.Telephone;
            user.Photo = u.Photo;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}