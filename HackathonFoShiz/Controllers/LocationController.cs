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
    public class LocationController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/Location
        public IEnumerable<Location> GetLocations()
        {
            return db.Locations.AsEnumerable();
        }

        // GET api/Location/5
        public Location GetLocation(int id)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return location;
        }

        // PUT api/Location/5
        public HttpResponseMessage PutLocation(int id, Location location)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != location.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(location).State = EntityState.Modified;

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

        // POST api/Location
        public HttpResponseMessage PostLocation(Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, location);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = location.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Location/5
        public HttpResponseMessage DeleteLocation(int id)
        {
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Locations.Remove(location);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, location);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}