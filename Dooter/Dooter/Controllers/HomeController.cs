using Dooter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Dooter.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private LocationDBContext LocationContext { get; set; }
        private BookmarkDBContext BookmarkContext { get; set; }

        public HomeController(LocationDBContext locationContext, BookmarkDBContext bookmarkContext)
        {
            LocationContext = locationContext;
            BookmarkContext = bookmarkContext;
        }

        public IActionResult Index()
        {
            var locations = LocationContext.Locations.OrderBy(l => l.Name).ToList();
            return View(locations);
        }

        public IActionResult Bookmarks()
        {
            var bookmarks = BookmarkContext.Bookmarks.OrderBy(l => l.Name).ToList();
            return View(bookmarks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Location_Information(int id)
        {
            var location = LocationContext.Locations.Find(id);
            return View(location);
        }

        public IActionResult Authenticate()
        {
            var accessClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "John"),
                new Claim(ClaimTypes.Email, "John.Smith@gmail.com"),
                new Claim("Secret code", "TechPro 2020")
            };
            var googleClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "John T Smith"),
                new Claim(ClaimTypes.Email, "John.Smith@gmail.com"),
                new Claim(ClaimTypes.MobilePhone, "778-778-9090")
            };

            var accessIdentity = new ClaimsIdentity(accessClaims, "Access Identity");
            var googleIdentity = new ClaimsIdentity(googleClaims, "Google Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { accessIdentity, googleIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
