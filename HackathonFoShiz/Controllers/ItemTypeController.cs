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
    public class ItemTypeController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/ItemType
        public IEnumerable<erItemType> GeterItemTypes()
        {
            return db.ItemTypes.AsEnumerable();
        }

        // GET api/ItemType/5
        public erItemType GeterItemType(int id)
        {
            erItemType eritemtype = db.ItemTypes.Find(id);
            if (eritemtype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return eritemtype;
        }

        // PUT api/ItemType/5
        public HttpResponseMessage PuterItemType(int id, erItemType eritemtype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != eritemtype.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(eritemtype).State = EntityState.Modified;

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

        // POST api/ItemType
        public HttpResponseMessage PosterItemType(erItemType eritemtype)
        {
            if (ModelState.IsValid)
            {
                db.ItemTypes.Add(eritemtype);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, eritemtype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = eritemtype.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/ItemType/5
        public HttpResponseMessage DeleteerItemType(int id)
        {
            erItemType eritemtype = db.ItemTypes.Find(id);
            if (eritemtype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.ItemTypes.Remove(eritemtype);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, eritemtype);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}