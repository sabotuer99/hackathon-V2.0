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
    public class PeopleLocationController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/PeopleLocation
        public IEnumerable<PeopleLocation> GetPeopleLocations()
        {
            return db.PeopleLocations.AsEnumerable();
        }

        // GET api/PeopleLocation/5
        public PeopleLocation GetPeopleLocation(int id)
        {
            PeopleLocation peoplelocation = db.PeopleLocations.Find(id);
            if (peoplelocation == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return peoplelocation;
        }

        // PUT api/PeopleLocation/5
        public HttpResponseMessage PutPeopleLocation(int id, PeopleLocation peoplelocation)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != peoplelocation.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(peoplelocation).State = EntityState.Modified;

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

        // POST api/PeopleLocation
        public HttpResponseMessage PostPeopleLocation(PeopleLocation peoplelocation)
        {
            if (ModelState.IsValid)
            {
                db.PeopleLocations.Add(peoplelocation);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, peoplelocation);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = peoplelocation.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/PeopleLocation/5
        public HttpResponseMessage DeletePeopleLocation(int id)
        {
            PeopleLocation peoplelocation = db.PeopleLocations.Find(id);
            if (peoplelocation == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PeopleLocations.Remove(peoplelocation);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, peoplelocation);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}