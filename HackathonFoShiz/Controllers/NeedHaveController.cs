using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HackathonFoShiz.Models;

namespace HackathonFoShiz.Controllers
{
    public class NeedHaveController : ApiController
    {
        private EmergencyResponseDb db = new EmergencyResponseDb();
        // GET api/needhave
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/needhave/5
        public IEnumerable<erItemNeedHaveViewModel> Get(int locationId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //erEvent erevent = db.Events.Find(id);


            IEnumerable<erItemNeedHaveViewModel> needHaves = new List<erItemNeedHaveViewModel>();

            needHaves = from l in db.Locations
                        join n in db.NeedItems on l.Id equals n.LocationId into needs
                        from nd in needs.DefaultIfEmpty()
                        join h in db.HaveItems on new { nd.LocationId, nd.ItemId } equals new {h.LocationId, h.ItemId} into nhgp
                        from gp in nhgp.DefaultIfEmpty()                                                                                                
                        join i in db.Items on nd.ItemId equals i.Id
                        where (locationId == l.Id)
                        orderby l.Id
                        select new erItemNeedHaveViewModel()
                        {
                            LocationId = l.Id,
                            HaveQty = gp.Qty,
                            NeedQty = nd.Qty,
                            ItemId = i.Id,
                            Description = i.Description
                        };

            //needHaves = from l in db.Locations 
            //            join n in db.NeedItems 
            //                on l.Id equals n.LocationId 
            //                into needGroup
            //            from a in needGroup.DefaultIfEmpty()
            //            join h in db.HaveItems 
            //                on a.Id equals h.LocationId 
            //                into haveGroup
            //            from b in haveGroup.DefaultIfEmpty()
            //            join i in db.Items 
            //                on b.ItemId equals i.Id
            //                into itemGroup
            //            from ig in itemGroup.DefaultIfEmpty()
            //            where (locationId == l.Id)
            //            orderby l.Id
            //            select new erItemNeedHaveViewModel()
            //            {
            //                LocationId = l.Id,
            //                HaveQty = a.Qty,
            //                NeedQty = b.Qty,
            //                ItemId = ig.Id,
            //                Description = ig.Description
            //            };


            if (needHaves == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return needHaves;
        }

        //// POST api/needhave
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/needhave/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/needhave/5
        //public void Delete(int id)
        //{
        //}
    }
}
