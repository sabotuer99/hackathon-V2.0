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
            public DbSet<erLocation> Locations { get; set; }
            public DbSet<erEvent> Events { get; set; }
            public DbSet<erPeople> Peoples { get; set; }
            public DbSet<erPeopleLocation> PeopleLocations { get; set; }

            IQueryable<T> IEmergencyResponseDb.Query<T>()
            {
                return Set<T>();
            }
        }
    
}