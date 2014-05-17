using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HackathonFoShiz.Models
{
    


        public interface IEmergencyResponseDb : IDisposable
        {
            IQueryable<T> Query<T>() where T : class;
        }

        public class EmergencyResponseDb : DbContext, IEmergencyResponseDb
        {
            public EmergencyResponseDb()
                : base("name=DefaultConnection")
            {

            }

            //public DbSet<UserProfile> UserProfiles { get; set; }
            public DbSet<Location> Locations { get; set; }
            public DbSet<Event> Events { get; set; }
            public DbSet<People> Peoples { get; set; }
            public DbSet<PeopleLocation> PeopleLocations { get; set; }

            IQueryable<T> IEmergencyResponseDb.Query<T>()
            {
                return Set<T>();
            }
        }
    
}