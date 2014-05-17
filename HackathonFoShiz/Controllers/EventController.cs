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
        public IEnumerable<Event> GetEvents()
        {
            return db.Events.AsEnumerable();
        }

        // GET api/Event/5
        public Event GetEvent(int id)
        {
            Event event = db.Events.Find(id);
            if (event == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return event;
        }

        // PUT api/Event/5
        public HttpResponseMessage PutEvent(int id, Event event)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != event.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(event).State = EntityState.Modified;

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
        public HttpResponseMessage PostEvent(Event event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(event);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, event);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = event.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Event/5
        public HttpResponseMessage DeleteEvent(int id)
        {
            Event event = db.Events.Find(id);
            if (event == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Events.Remove(event);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, event);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}