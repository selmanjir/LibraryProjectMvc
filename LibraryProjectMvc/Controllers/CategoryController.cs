using LibraryProjectMvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class CategoryController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        public ActionResult Index()
        {
            //var result = _categoryService.GetAll();
            var categories = db.Categories.ToList();

            return View(categories);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Categories category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View("GetCategory", category);
        }
        public ActionResult UpdateCategory(Categories c)
        {
            var category = db.Categories.Find(c.CategoryId);
            category.CategoryName = c.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}