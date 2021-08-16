using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryProjectMvc.Models.Entity;
namespace MvcLibraryProject.Controllers
{
    [Authorize(Roles = "A")]
    public class EmployeeController : Controller
    {
        LibraryProjectEntities db = new LibraryProjectEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();

            return View(employees);

        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employees employees)
        {
            db.Employees.Add(employees);
            db.SaveChanges();
            return View();
        }
        public ActionResult DeleteEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            return View("GetEmployee", employee);
        }
        public ActionResult UpdateEmployee(Employees e)
        {
            var employee = db.Employees.Find(e.EmployeeId);
            employee.EmployeeName = e.EmployeeName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}