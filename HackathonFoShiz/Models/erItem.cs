using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    public class erItem
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public bool IsActive { get; set; }
        //public virtual ICollection<erHaveItems> LocationsHaveItems { get; set; }
        //public virtual ICollection<erNeedItems> LocationsNeedItems { get; set; }

    }
}