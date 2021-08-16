using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryProjectMvc.Models.Entity;

namespace LibraryProjectMvc.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Employees e)
        {
            var informations = db.Employees.FirstOrDefault(x => x.UserName == e.UserName && x.Password == e.Password);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.UserName, false);
                Session["UserName"] = informations.UserName.ToString();
                return RedirectToAction("Index", "Statistics");
            }
            else
            {
                return View();

            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}