namespace HackathonFoShiz.Migrations
{
    using HackathonFoShiz.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HackathonFoShiz.Models.EmergencyResponseDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HackathonFoShiz.Models.EmergencyResponseDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Locations.AddOrUpdate(
              l => l.Name,
              new erLocation { Name = "Yellowstone Super Volcano Blowout",
                                Address1 = "1062 Some Street",
                                Address2 = null,
                                City = "Cheyenne",
                                State = "WY",
                                Zip = "82002",
                                Longitude = "122.0000",
                                Latitude = "32.0000",
                                ContactId = 1,
                                EventId = 1,
                                IsActive = true },
              new erLocation { Name = "Galvanize",
                                Address1 = "123 Whatever",
                                Address2 = null,
                                City = "Denver",
                                State = "CO",
                                Zip = "99999",
                                Longitude = "102.0000",
                                Latitude = "42.0000",
                                ContactId = 2,
                                EventId = 2,
                                IsActive = true },
              new erLocation { Name = "Spaghetti Factory",
                                Address1 = "9876 Broadway",
                                Address2 = null,
                                City = "Englewood",
                                State = "CO",
                                Zip = "89966",
                                Longitude = "115.0000",
                                Latitude = "38.0000",
                                ContactId = 3,
                                EventId = 2,
                                IsActive = true }
              );         
        }
    }
}
