﻿using HackathonFoShiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonFoShiz.Controllers
{
    public class LocationController : Controller
    {
        
        private EmergencyResponseDb db = new EmergencyResponseDb();

        //
        // GET: /Location/
        public ActionResult Index()
        {
            return Json(db.Locations.ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Location/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Location/Create

        public ActionResult Create()
        {
            return null;
        }

        //
        // POST: /Location/Create

        [HttpPost]
        public ActionResult Create(Location location)
        {
            try
            {
                // TODO: Add insert logic here
                db.Locations.Add(location);
                db.SaveChanges();
                return Content("Success");
            }
            catch
            {
                return null;
            }
        }

        //
        // GET: /Location/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Location/Edit/5

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
        // GET: /Location/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Location/Delete/5

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