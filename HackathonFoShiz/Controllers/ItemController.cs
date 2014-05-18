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
    public class ItemController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/Item
        public IEnumerable<erItem> GeterItems()
        {
            return db.Items.AsEnumerable();
        }

        // GET api/Item/5
        public erItem GeterItem(int id)
        {
            erItem eritem = db.Items.Find(id);
            if (eritem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return eritem;
        }

        // PUT api/Item/5
        public HttpResponseMessage PuterItem(int id, erItem eritem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != eritem.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(eritem).State = EntityState.Modified;

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

        // POST api/Item
        public HttpResponseMessage PosterItem(erItem eritem)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(eritem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, eritem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = eritem.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Item/5
        public HttpResponseMessage DeleteerItem(int id)
        {
            erItem eritem = db.Items.Find(id);
            if (eritem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Items.Remove(eritem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, eritem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}