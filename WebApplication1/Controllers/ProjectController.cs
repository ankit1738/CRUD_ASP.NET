using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication1.Contexts;
using WebApplication1.Models;
using WebApplication1.ViewModel;


namespace WebApplication1.Controllers
{
    public class ProjectController : Controller
    {
        private CompanyContext db;
        public ProjectController()
        {
            db = new CompanyContext();
        }
        // GET: Project
        public ActionResult AllProjects()
        {
            List<Project> projects = db.Projects.ToList();
            return View(projects);
        }
        
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Project proj)
        {
            db.Projects.Add(proj);
            db.SaveChanges();
            return RedirectToAction("AllProjects", "Project");
        }

        public ActionResult Details(int id)
        {
            Project proj = db.Projects.Include(p => p.Employees).SingleOrDefault(p => p.Id == id);
            return View(proj);
        }

        public ActionResult AddEmployeesToProj(int id)
        {
            List<Employee> emp = db.Employees.Include("Projects").ToList();
            Project proj = db.Projects.Find(id);

            EmployeeDetails empDetail = new EmployeeDetails
            {
                Employees = emp,
                Project = proj
            };

            return View(empDetail);
        }

        [HttpPost]
        public ActionResult AddEmployeesToProj_post(int id, int[] employeeIds)
        {
            Project proj = db.Projects.Include(p => p.Employees).SingleOrDefault(p => p.Id == id);
            foreach (var empId in employeeIds)
            {
                var emp = db.Employees.SingleOrDefault(emp1 => emp1.UserId == empId);
                proj.Employees.Add(emp);
                
            }
            db.SaveChanges();
            return RedirectToAction("Details", "Project", new { id });
        }

        
        public ActionResult RemoveEmployeeFromProj(int id, int empId)
        {
            Project proj = db.Projects.Include("Employees").SingleOrDefault(p => p.Id == id);
            Employee emp = db.Employees.SingleOrDefault(e => e.Id == empId);
            proj.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Details", "Project", new { id });
        }
    }
}