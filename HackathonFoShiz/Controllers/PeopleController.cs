using HackathonFoShiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonFoShiz.Controllers
{
    public class PeopleController : Controller
    {

        private EmergencyResponseDb db = new EmergencyResponseDb();

        //
        // GET: /People/

        public ActionResult Index()
        {
            return Json(db.Peoples.ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /People/Details/5

        public ActionResult Details(int id)
        {
            return Json(db.Peoples.Find(id), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /People/Create
        // Sending a GET request to the Create method on the API is not valid
        public ActionResult Create()
        {
            return null;
        }

        //
        // POST: /People/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /People/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /People/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /People/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /People/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
