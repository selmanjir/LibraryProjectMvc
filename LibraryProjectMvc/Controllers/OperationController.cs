using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;
namespace LibraryProjectMvc.Controllers
{
    public class OperationController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Operation
        public ActionResult Index()
        {
            var degerler = db.Actions.Where(x => x.ActionStatus == true).ToList();
            return View(degerler);
        }
    }
}