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
    public class NeedItemController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/NeedItem
        public IEnumerable<erNeedItem> GeterNeedItems()
        {
            return db.NeedItems.AsEnumerable();
        }

        // GET api/NeedItem/GetNeedsByLocationId
        [HttpGet]
        public IEnumerable<erNeedItem> GetNeedsByLocationId(int locationId)
        {
            var needs = db.NeedItems.Where(w => w.LocationId == locationId);
            return needs.AsEnumerable();
        }

        // GET api/NeedItem/5
        public erNeedItem GeterNeedItem(int id)
        {
            erNeedItem erneeditem = db.NeedItems.Find(id);
            if (erneeditem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return erneeditem;
        }

        // PUT api/NeedItem/5
        public HttpResponseMessage PuterNeedItem(int id, erNeedItem erneeditem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != erneeditem.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(erneeditem).State = EntityState.Modified;

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

        // POST api/NeedItem
        public HttpResponseMessage PosterNeedItem(erNeedItem erneeditem)
        {
            if (ModelState.IsValid)
            {
                db.NeedItems.Add(erneeditem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, erneeditem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = erneeditem.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/NeedItem/5
        public HttpResponseMessage DeleteerNeedItem(int id)
        {
            erNeedItem erneeditem = db.NeedItems.Find(id);
            if (erneeditem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.NeedItems.Remove(erneeditem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, erneeditem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}