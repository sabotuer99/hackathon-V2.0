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
    public class HaveItemController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/HaveItem
        public IEnumerable<erHaveItem> GeterHaveItems()
        {
            return db.HaveItems.AsEnumerable();
        }

        // GET api/HaveItem?locationId=x
        [HttpGet]
        public IEnumerable<erHaveItemSimple> GetHasByLocationId(int locationId)
        {
            //var has = db.HaveItems.Where(w => w.LocationId == locationId);
            //return has.AsEnumerable();

            db.Configuration.ProxyCreationEnabled = false;
            //erEvent erevent = db.Events.Find(id);

            IEnumerable<erHaveItemSimple> haves = new List<erHaveItemSimple>();

            haves =  from l in db.Locations
                        join h in db.HaveItems on l.Id equals h.LocationId
                        join i in db.Items on h.ItemId equals i.Id
                        where (locationId == l.Id)
                        orderby l.Id
                        select new erHaveItemSimple()
                        {
                            LocationId = l.Id,
                            HaveQty = h.Qty,
                            ItemId = i.Id,
                            Description = i.Description
                        };

            return haves;
        }


        // GET api/HaveItem/5
        public erHaveItem GeterHaveItem(int id)
        {
            erHaveItem erhaveitem = db.HaveItems.Find(id);
            if (erhaveitem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return erhaveitem;
        }

        // PUT api/HaveItem/5
        public HttpResponseMessage PuterHaveItem(int id, erHaveItem erhaveitem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != erhaveitem.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(erhaveitem).State = EntityState.Modified;

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

        // POST api/HaveItem
        public HttpResponseMessage PosterHaveItem(erHaveItem erhaveitem)
        {
            if (ModelState.IsValid)
            {
                db.HaveItems.Add(erhaveitem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, erhaveitem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = erhaveitem.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/HaveItem/5
        public HttpResponseMessage DeleteerHaveItem(int id)
        {
            erHaveItem erhaveitem = db.HaveItems.Find(id);
            if (erhaveitem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.HaveItems.Remove(erhaveitem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, erhaveitem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}