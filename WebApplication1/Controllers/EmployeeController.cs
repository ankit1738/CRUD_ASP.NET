    using System;   
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Contexts;
using WebApplication1.Models;
using System.Data.Entity;
using System.Dynamic;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private CompanyContext db = new CompanyContext();
        // GET: Employee
        public ActionResult ViewEmployees()
        {
            
            return View(db.Employees.ToList());
        }

        public ActionResult Details(int id)
        {

            Employee employee = db.Employees.Include(e => e.Projects).SingleOrDefault(emp => emp.UserId == id);
            EmployeeDetails empdetail = new EmployeeDetails
            {
                Employee = employee
            };

            return View(employee);
        }

        
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "UserId, Name")]Employee employee)
        {
          
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("ViewEmployees");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.SingleOrDefault(emp => emp.UserId == id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserId, Name")]Employee employee)
        {

            if (ModelState.IsValid)
            {
                Employee emp1 = db.Employees.SingleOrDefault(emp => emp.UserId == employee.UserId);
                emp1.Name = employee.Name;
                db.SaveChanges();
                return RedirectToAction("ViewEmployees");
            }
            return Content("Error");
        }

        public ActionResult Delete(int id)
        {
            //db.Database.Log = Console.Write;
            //Employee emp = new Employee() { UserId = id };
            //db.Employees.Add(emp);
            //db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;

            Employee emp1 = db.Employees.SingleOrDefault(emp => emp.UserId == id);
            db.Employees.Remove(emp1);
            db.SaveChanges();
            //db.Employees.Where(x => x.UserId == UserId)
            return RedirectToAction("ViewEmployees");
        }


    }
}