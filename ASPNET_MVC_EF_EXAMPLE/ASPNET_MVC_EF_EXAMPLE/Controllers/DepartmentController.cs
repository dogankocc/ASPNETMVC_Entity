using ASPNET_MVC_EF_EXAMPLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_EF_EXAMPLE.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        doantestEntities1 entities = new doantestEntities1();
        // GET: Department
        public ActionResult Index()
        {
            List<Departments> departments = entities.Departments.ToList();
            return View(departments);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Departments department)
        {
            if(department.DepartmentID == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                entities.Departments.Add(new Departments
                {
                    DepartmentID = Guid.NewGuid(),
                    DepartmentName = department.DepartmentName
                });
            }
            else
            {
                var model = entities.Departments.Find(department.DepartmentID);
                if (model == null) return HttpNotFound();
                model.DepartmentName = department.DepartmentName;
            }

            entities.SaveChanges();
            return RedirectToAction("Index","Department");
        }

        [HttpGet]
        public ActionResult UpdateDepartment(string id)
        {
            var model = entities.Departments.FirstOrDefault(e=>e.DepartmentID.ToString() == id);
            if (model == null) return HttpNotFound();
            return View("UpdateDepartment", model);
        }


        [HttpGet]
        public ActionResult DeleteDepartment(string id)
        {
            var model = entities.Departments.FirstOrDefault(e => e.DepartmentID.ToString() == id);
            entities.Departments.Remove(model);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}