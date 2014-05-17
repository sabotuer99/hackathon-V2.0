using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    public class PeopleLocation
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public int LocationId { get; set; }
    }
}