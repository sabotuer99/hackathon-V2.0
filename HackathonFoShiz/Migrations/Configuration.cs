namespace HackathonFoShiz.Migrations
{
    using HackathonFoShiz.Models;
    using System;
    using System.Collections.Generic;
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
              new erLocation
              {
                  Name = "Google GovDev 2014",
                  Address1 = "1062 Some Street",
                  Address2 = null,
                  City = "Cheyenne",
                  State = "WY",
                  Zip = "82002",
                  Longitude = "122.0000",
                  Latitude = "32.0000",
                  ContactId = 1,
                  EventId = 1,
                  IsActive = true
              },

              new erLocation
              {
                  Name = "Test Location 1",
                  Address1 = "1062 Some Street",
                  Address2 = null,
                  City = "Cheyenne",
                  State = "WY",
                  Zip = "82002",
                  Longitude = "122.0000",
                  Latitude = "32.0000",
                  ContactId = 1,
                  EventId = 2,
                  IsActive = true
              },

              new erLocation
              {
                  Name = "TestLocation 2",
                  Address1 = "1062 Some Street",
                  Address2 = null,
                  City = "Cheyenne",
                  State = "WY",
                  Zip = "82002",
                  Longitude = "122.0000",
                  Latitude = "32.0000",
                  ContactId = 1,
                  EventId = 3,
                  IsActive = true
              },

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
                                IsActive = true },
             new erLocation { Name = "Another test location",
                                Address1 = "9876 Broadway",
                                Address2 = null,
                                City = "Englewood",
                                State = "CO",
                                Zip = "89966",
                                Longitude = "115.0000",
                                Latitude = "38.0000",
                                ContactId = 3,
                                EventId = 1,
                                IsActive = true },

            new erLocation { Name = "Frontier Mall",
                                Address1 = "9876 Broadway",
                                Address2 = null,
                                City = "Englewood",
                                State = "CO",
                                Zip = "89966",
                                Longitude = "115.0000",
                                Latitude = "38.0000",
                                ContactId = 3,
                                EventId = 3,
                                IsActive = true}
              );

            context.Events.AddOrUpdate(
                l => l.Name,
                new erEvent
                {
                    Name = "Yellowstone Super Volcano Blowout",
                    BeginDate = Convert.ToDateTime("1/1/14"),
                    EndDate = Convert.ToDateTime("1/26/14"),
                    Description = "the super volcano blew!",
                    IsActive = true,
                    Locations = context.Locations.Where(s => s.EventId == 1).ToList()
                    
                    
                    //new List<erLocation> {
                    //    new erLocation { Name = "Google GovDev 2014",
                    //            Address1 = "1062 Some Street",
                    //            Address2 = null,
                    //            City = "Cheyenne",
                    //            State = "WY",
                    //            Zip = "82002",
                    //            Longitude = "122.0000",
                    //            Latitude = "32.0000",
                    //            ContactId = 1,
                    //            IsActive = true },

                    //   new erLocation { Name = "Test Location 1",
                    //            Address1 = "1062 Some Street",
                    //            Address2 = null,
                    //            City = "Cheyenne",
                    //            State = "WY",
                    //            Zip = "82002",
                    //            Longitude = "122.0000",
                    //            Latitude = "32.0000",
                    //            ContactId = 1,
                    //            IsActive = true },

                    //    new erLocation { Name = "TestLocation 2",
                    //            Address1 = "1062 Some Street",
                    //            Address2 = null,
                    //            City = "Cheyenne",
                    //            State = "WY",
                    //            Zip = "82002",
                    //            Longitude = "122.0000",
                    //            Latitude = "32.0000",
                    //            ContactId = 1,
                    //            IsActive = true }
                    //}
                },

                new erEvent
                {
                    Name = "Fall 2013 Flooding",
                    BeginDate = Convert.ToDateTime("9/1/13"),
                    EndDate = Convert.ToDateTime("12/31/13"),
                    Description = "torrential rains and flooding",
                    IsActive = true
                },

                new erEvent
                {
                    Name = "The Deep Freeze",
                    BeginDate = Convert.ToDateTime("2/1/14"),
                    EndDate = Convert.ToDateTime("2/5/15"),
                    Description = "sub zero for days on end",
                    IsActive = true
                }
              );

            context.PeopleLocations.AddOrUpdate(
                new erPeopleLocation
                {
                    PeopleId = 1,
                    LocationId = 1
                },

                new erPeopleLocation
                {
                    PeopleId = 2,
                    LocationId = 1
                },

                new erPeopleLocation
                {
                    PeopleId = 3,
                    LocationId = 2
                }
             );

            context.Peoples.AddOrUpdate(
                l => l.FirstName,
                new erPeople
                {
                    FirstName = "Sam",
                    LastName = "Smith",
                    CellPhone = "970-555-1325",
                    OtherPhone = null,
                    IsActive = true
                },

                new erPeople
                {
                    FirstName = "Fred",
                    LastName = "Wilton",
                    CellPhone = "970-555-1452",
                    OtherPhone = null,
                    IsActive = true
                },

                new erPeople
                {
                    FirstName = "George",
                    LastName = "Lopez",
                    CellPhone = "307-555-8852",
                    OtherPhone = null,
                    IsActive = true
                }
            );

            context.ItemTypes.AddOrUpdate(
                l => l.Description,
                new erItemType
                {
                    Description = "Non-Perishable Food"
                },

                new erItemType
                {
                    Description = "Water"
                },

                 new erItemType
                 {
                     Description = "Personal Hygiene"
                 },
                 
                 new erItemType
                 {
                     Description = "Clothing"
                 },

                 new erItemType
                 {
                     Description = "Bedding Supplies"
                 }
            );

            context.Items.AddOrUpdate (
                l => l.Description,
                new erItem
                {
                    TypeId = 1,
                    Description = "Canned Meat",
                    Length = "3 inches",
                    Width = "2 inches",
                    Height = "3 inches",
                    Size = "12 ounces",
                    IsActive = true
                },

                new erItem
                {
                    TypeId = 1,
                    Description = "Instant Rice",
                    Length = "12 inches",
                    Width = "2 inches",
                    Height = "13 inches",
                    Size = "24 ounces",
                    IsActive = true
                },

                new erItem
                {
                    TypeId = 3,
                    Description = "Toliet Paper",
                    Length = "3 inches",
                    Width = "3 inches",
                    Height = "5 inches",
                    Size = null,
                    IsActive = true
                },

                new erItem
                {
                    TypeId = 3,
                    Description = "Bottled Water",
                    Length = "2 inches",
                    Width = "2 inches",
                    Height = "10 inches",
                    Size = "10 ounces",
                    IsActive = true
                }
            );

            context.HaveItems.AddOrUpdate(
                l => l.ItemId,
                new erHaveItem
                {
                    LocationId = 1,
                    ItemId = 1,
                    Qty = 15,
                    IsActive = true
                },

                new erHaveItem
                {
                    LocationId = 2,
                    ItemId = 2,
                    Qty = 5,
                    IsActive = true
                },

                new erHaveItem
                {
                    LocationId = 3,
                    ItemId = 3,
                    Qty = 60,
                    IsActive = true
                }
            );

            context.NeedItems.AddOrUpdate(
                l => l.ItemId,
                new erNeedItem
                {
                    LocationId = 1,
                    ItemId = 3,
                    Qty = 15,
                    IsActive = true
                },

                new erNeedItem
                {
                    LocationId = 2,
                    ItemId = 1,
                    Qty = 175,
                    IsActive = true
                }
            );
        }
    }
}
