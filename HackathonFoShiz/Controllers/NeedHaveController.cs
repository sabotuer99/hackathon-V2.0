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

            //int lid  = locationId;
            needHaves = from l in db.Locations
                        join n in db.NeedItems on l.Id equals n.LocationId
                        join h in db.HaveItems on n.LocationId equals h.LocationId
                        join i in db.Items on n.ItemId equals i.Id
                        where (locationId == l.Id)
                        orderby l.Id
                        select new erItemNeedHaveViewModel() 
                        {
                            LocationId = l.Id,
                            HaveQty = h.Qty,
                            NeedQty = n.Qty,
                            ItemId = i.Id,
                            Description = i.Description
                        };


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
