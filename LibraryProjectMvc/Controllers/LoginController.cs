using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;
using System.Web.Security;

namespace LibraryProjectMvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Users u)
        {
            var informations = db.Users.FirstOrDefault(x => x.UserName == u.UserName && x.Password == u.Password);
            if (informations != null)
            {
                
                FormsAuthentication.SetAuthCookie(informations.UserName, false);
                Session["UserName"] = informations.UserName.ToString();
                return RedirectToAction("Index", "UserPanel");
            }
            else
            {
                return View();
            }
        }
       
    }
}