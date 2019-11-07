using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mywebapp.Models;

namespace mywebapp.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;

        public HomeController()
        {
            client = new HttpClient();
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

        public async Task<IActionResult> Quotes()
        {

            var response = await client.GetStringAsync("http://demowebapi:9000/api/quotes");
            ViewData["Message"] = response; 

            return View();
        }
    }
}
