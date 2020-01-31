using ASPNET_MVC_EF_EXAMPLE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ASPNET_MVC_EF_EXAMPLE.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        doantestEntities1 entities = new doantestEntities1();
        // GET: Personel
        public ActionResult Index()
        {
            List<Personels> personels = entities.Personels.Include(x => x.Departments).ToList();
            return View(personels);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new PersonelViewModel()
            {
                Departments = entities.Departments.ToList()
            };
            return View("Add",model);
        }

        [HttpPost]
        public ActionResult Save(Personels personel)
        {
            if (personel.PersonelID == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                entities.Personels.Add(new Personels() {
                    PersonelID = Guid.NewGuid(),
                    DepartmentID = personel.DepartmentID,
                    PersonelName = personel.PersonelName,
                    PersonelSirname = personel.PersonelSirname,
                    PersonelAge = personel.PersonelAge,
                    PersonelBirthdate = personel.PersonelBirthdate,
                    PersonelGender = personel.PersonelGender,
                    PersonelSalary = personel.PersonelSalary,
                    MarriageStatus = personel.MarriageStatus
                });
            }
            else
            {
                var model = entities.Personels.Find(personel.PersonelID);
                if (model == null) return HttpNotFound();
                model.PersonelName = personel.PersonelName;
                model.PersonelSirname = personel.PersonelSirname;
                model.PersonelAge = personel.PersonelAge;
                model.PersonelBirthdate = personel.PersonelBirthdate;
                model.PersonelGender = personel.PersonelGender;
                model.PersonelSalary = personel.PersonelSalary;
                model.MarriageStatus = personel.MarriageStatus;
            }

            entities.SaveChanges();
            return RedirectToAction("Index", "Personel");
        }

        [HttpGet]
        public ActionResult UpdatePersonel(string id)
        {
            var model = entities.Personels.FirstOrDefault(e => e.PersonelID.ToString() == id);
            if (model == null) return HttpNotFound();
            return View("UpdatePersonel", model);
        }

        [HttpGet]
        public ActionResult DeletePersonel(string id)
        {
            var model = entities.Personels.FirstOrDefault(e => e.PersonelID.ToString() == id);
            entities.Personels.Remove(model);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}