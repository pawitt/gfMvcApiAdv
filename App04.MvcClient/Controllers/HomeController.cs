using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App04.MvcClient.Models;
using App04.MvcClient.NSwagClients;
using System.Net.Http;
using System.Net.Http.Headers;

namespace App04.MvcClient.Controllers
{
    public class HomeController : Controller
    {
        // cross-session do not use.
        private static string token;

        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                var c = new Client("https://localhost:44343", httpClient);

                var result = await c.LogInAsync(new AuthLogIn { UserName = "Suchit", Password = "yyyy" });
                token = result.Token;

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var trucks = await c.GetAllTrucksAsync();

                return View(trucks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Truck item)
        {
            using (var httpClient = new HttpClient())
            {
                var c = new Client("https://localhost:44343", httpClient);
                var t = await c.PostAsync(item);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var c = new Client("https://localhost:44343", httpClient);
                var truck = await c.GetByIdAsync(id);
                return View(truck);
            }
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
