using Dooter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace Dooter.Controllers
{
    public class FunctionalityController : Controller
    {
        private LocationDBContext LocationContext { get; set; }
        private BookmarkDBContext BookmarkContext { get; set; }

        public FunctionalityController(LocationDBContext locationContext, BookmarkDBContext bookmarkContext)
        {
            LocationContext = locationContext;
            BookmarkContext = bookmarkContext;
        }

        [HttpGet]
        public IActionResult AddLocation()
        {
            ViewBag.Action = "Add";
            return View("EditLocation", new Location());
        }

        [HttpGet]
        public IActionResult EditLocation(int id)
        {
            ViewBag.Action = "Edit";
            var location = LocationContext.Locations.Find(id);
            return View(location);
        }

        [HttpPost]
        public IActionResult EditLocation(Location location)
        {
            location.Latitude = 3.21;
            location.Longitude = 1.23;
            if (ModelState.IsValid)
            {
                if (location.LocationID == 0)
                    LocationContext.Locations.Add(location);
                else
                    LocationContext.Locations.Update(location);
                LocationContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (location.LocationID == 0) ? "Add" : "Edit";
                return View(location);
            }
        }

        [HttpGet]
        public IActionResult AddBookmark()
        {
            ViewBag.Action = "Add";
            return View("EditBookmark", new Bookmark());
        }

        [HttpGet]
        public IActionResult EditBookmark(int id)
        {
            ViewBag.Action = "Edit";
            var bookmark = BookmarkContext.Bookmarks.Find(id);
            return View(bookmark);
        }

        [HttpPost]
        public IActionResult EditBookmark(Bookmark bookmark)
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteBookmark(int id)
        {
            var location = BookmarkContext.Bookmarks.Find(id);
            return View(location);
        }

        [HttpPost]
        public IActionResult DeleteBookmark(Bookmark bookmark)
        {
            BookmarkContext.Bookmarks.Remove(bookmark);
            BookmarkContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Unused right now.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteLocation(int id)
        {
            var location = LocationContext.Locations.Find(id);
            return View(location);
        }
        
        /// <summary>
        /// Unused right now.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteLocation(Location location)
        {
            LocationContext.Locations.Remove(location);
            LocationContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
