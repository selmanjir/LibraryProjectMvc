using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Register
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(Users u)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.Users.Add(u);
            db.SaveChanges();
            return View();
        }
    }
}