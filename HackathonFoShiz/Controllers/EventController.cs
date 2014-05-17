using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HackathonFoShiz.Models;

namespace HackathonFoShiz.Controllers
{
    public class EventController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/Event
        public IEnumerable<erEvent> GeterEvents()
        {
            return db.Events.AsEnumerable();
        }

        // GET api/Event/5
        public erEvent GeterEvent(int id)
        {
            erEvent erevent = db.Events.Find(id);
            if (erevent == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return erevent;
        }

        // PUT api/Event/5
        public HttpResponseMessage PuterEvent(int id, erEvent erevent)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != erevent.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(erevent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Event
        public HttpResponseMessage PosterEvent(erEvent erevent)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(erevent);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, erevent);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = erevent.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Event/5
        public HttpResponseMessage DeleteerEvent(int id)
        {
            erEvent erevent = db.Events.Find(id);
            if (erevent == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Events.Remove(erevent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, erevent);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}