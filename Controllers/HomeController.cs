using crud2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMPLE_CRUD.Controllers
{
    public class HomeController : Controller
    {
        DBHandler db = new DBHandler();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            db.Added(employee);
            return View();
        }
        public ActionResult Edit(int id)
        {
            db.GetAll().Find(x => x.Id == id);

            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                db.Update(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}