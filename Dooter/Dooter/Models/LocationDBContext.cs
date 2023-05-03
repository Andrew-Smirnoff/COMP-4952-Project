using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dooter.Models
{
    public class LocationDBContext : DbContext
    {
        public LocationDBContext(DbContextOptions<LocationDBContext> options) : base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder myModelBuilder)
        {
            myModelBuilder.Entity<Location>().HasData(
                new Location
                {
                    LocationID = 1,
                    Name = "Gothic tree",
                    Rating = 3.5,
                    Latitude = 1.0,
                    Longitude = 1.0
                },
                new Location
                {
                    LocationID = 2,
                    Name = "Gothic tree 2 electric boogaloo",
                    Rating = 3.5,
                    Latitude = 1.0,
                    Longitude = 1.0
                },
                new Location
                {
                    LocationID = 3,
                    Name = "Gothic tree 3 how many gothic trees are there?",
                    Rating = 3.5,
                    Latitude = 1.0,
                    Longitude = 1.0
                }
            );
        }
    }
        
}
