using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    public class usp_GeterEventIsActive1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}