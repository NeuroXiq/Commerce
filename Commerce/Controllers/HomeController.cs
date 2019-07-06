using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commerce.Models;
using Commerce.Data;
using Commerce.ViewModels;

namespace Commerce.Controllers
{
    public class HomeController : Controller
    {
        CommerceDbContext commerceDbContext;

        public HomeController(CommerceDbContext commerceDbContext)
        {
            this.commerceDbContext = commerceDbContext;
        }

        public IActionResult Index()
        {
            

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
