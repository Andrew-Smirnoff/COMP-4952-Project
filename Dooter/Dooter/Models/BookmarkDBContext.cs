using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Dooter.Models
{
    public class BookmarkDBContext : IdentityDbContext<IdentityUser>
    {
        public BookmarkDBContext(DbContextOptions<BookmarkDBContext> options) : base(options)
        {

        }

        public DbSet<Bookmark> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder myModelBuilder)
        {
            base.OnModelCreating(myModelBuilder);

            myModelBuilder.Entity<Bookmark>().HasData(
                new Bookmark
                {
                    BookmarkID = 1,
                    Name = "Bookmark 1",
                    Rating = 3.5,
                    Latitude = 1.0,
                    Longitude = 1.0
                },
                new Bookmark
                {
                    BookmarkID = 2,
                    Name = "Bookmark 2",
                    Rating = 3.5,
                    Latitude = 1.0,
                    Longitude = 1.0
                }
            );
        }
    }
}
