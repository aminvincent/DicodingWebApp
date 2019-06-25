using DicodingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DicodingWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            using (dicodingdbEntities db = new dicodingdbEntities())
            {
                var query = db.Employee.Select(x => new EmployeeModel
                {
                    EmployeeId = x.EmployeeId,
                    Name = x.Name,
                    Email = x.Email,
                    Job = x.Job
                }).ToList();

                ViewBag.EmployeeList = query;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (dicodingdbEntities db = new dicodingdbEntities())
                    {
                        Employee emp = new Employee();
                        emp.Name = model.Name;
                        emp.Email = model.Email;
                        emp.Job = model.Job;
                        emp.CreatedDate = DateTime.Now;
                        db.Employee.Add(emp);
                        db.SaveChanges();

                        ModelState.Clear();
                        ViewBag.Message = "<div class='alert alert-success'>Data Succesfull Added !</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "<div class='alert alert-danger'>" + ex.Message + "</div>";
            }
            return View("Index");
            //return RedirectToAction("Index");
        }

    }
}