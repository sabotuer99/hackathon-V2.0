using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    public class erPeople
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string OtherPhone { get; set; }
        public bool IsActive { get; set; }
    }
}