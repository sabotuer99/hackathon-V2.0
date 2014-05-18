using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    public class erHaveItemSimple
    {
        public int LocationId { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public int HaveQty { get; set; }
    }
}