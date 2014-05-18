using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HackathonFoShiz.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Sql;
using System.Data.SqlClient;


namespace HackathonFoShiz.Controllers
{
    public class StoredProcController : ApiController
    {

        private EmergencyResponseDb db = new EmergencyResponseDb();

        // GET api/storedproc
        //public IEnumerable<usp_GeterEventIsActive_Result> Get(bool isActive)
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/storedproc/5
        [HttpGet]
        public DbSqlQuery<usp_GeterEventIsActive1> StoredProc1(bool isActive)
        {
            //var idParm = new SqlParameter{ParameterName = "isActive"};
            //String sp = "usp_GeterEventIsActive ";
            //ValueType vt = new c
            //DbSqlQuery<usp_GeterEventIsActive1> who = db.Database.SqlQuery(;
            //return who.;
        }

        // POST api/storedproc
        public void Post([FromBody]string value)
        {
        }

        // PUT api/storedproc/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/storedproc/5
        public void Delete(int id)
        {
        }
    }
}
