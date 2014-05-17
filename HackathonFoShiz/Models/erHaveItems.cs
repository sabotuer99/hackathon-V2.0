using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    public class erHaveItems
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public bool IsActive { get; set; }
    }
}