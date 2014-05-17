using HackathonFoShiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonFoShiz.Controllers
{
    public class PeopleLocationController : Controller
    {

        private EmergencyResponseDb db = new EmergencyResponseDb();

        //
        // GET: /PeopleLocation/

        public ActionResult Index()
        {
            return Json(db.PeopleLocations.ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /PeopleLocation/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PeopleLocation/Create

        public ActionResult Create()
        {
            return null;
        }

        //
        // POST: /PeopleLocation/Create

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
        // GET: /PeopleLocation/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PeopleLocation/Edit/5

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
        // GET: /PeopleLocation/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PeopleLocation/Delete/5

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
