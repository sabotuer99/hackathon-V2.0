using System;

namespace HackathonFoShiz.Controllers
{
    public partial class usp_GeterEventIsActive_Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}