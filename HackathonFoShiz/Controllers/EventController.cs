﻿using HackathonFoShiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HackathonFoShiz.Controllers
{
    public class EventController : Controller
    {

        private EmergencyResponseDb db = new EmergencyResponseDb();

        //
        // GET: /Event/

        public ActionResult Index()
        {
            return Json(db.Events.ToList(), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            return null;
        }

        //
        // POST: /Event/Create

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
        // GET: /Event/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Event/Edit/5

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
        // GET: /Event/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Event/Delete/5

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
