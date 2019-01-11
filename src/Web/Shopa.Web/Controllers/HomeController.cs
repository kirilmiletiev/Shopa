using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopa.Data.Models;
using Shopa.Services.Contracts;
using Shopa.Web.Models;

namespace Shopa.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ShopaUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IHomeService homeService;

        public HomeController(RoleManager<IdentityRole> roleManager, UserManager<ShopaUser> userManager, IHomeService homeService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
