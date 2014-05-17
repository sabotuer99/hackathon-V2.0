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
    public class PeopleController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/People
        public IEnumerable<erPeople> GetPeople()
        {
            return db.Peoples.AsEnumerable();
        }

        // GET api/People/5
        public erPeople GetPeople(int id)
        {
            erPeople people = db.Peoples.Find(id);
            if (people == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return people;
        }

        // PUT api/People/5
        public HttpResponseMessage PutPeople(int id, erPeople people)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != people.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(people).State = EntityState.Modified;

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

        // POST api/People
        public HttpResponseMessage PostPeople(erPeople people)
        {
            if (ModelState.IsValid)
            {
                db.Peoples.Add(people);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, people);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = people.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/People/5
        public HttpResponseMessage DeletePeople(int id)
        {
            erPeople people = db.Peoples.Find(id);
            if (people == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Peoples.Remove(people);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, people);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}