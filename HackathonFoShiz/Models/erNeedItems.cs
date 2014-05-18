using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    public class erNeedItems
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public bool IsActive { get; set; }

       // public virtual erLocation Location { get; set; }
       // public virtual erItem Item { get; set; }
    }
}