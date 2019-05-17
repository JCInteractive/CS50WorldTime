using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS50WorldTime.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CS50WorldTime.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    
                    var response = client.GetAsync("http://worldtimeapi.org/api/ip");

                    string responseBody = response.Result.Content.ReadAsStringAsync().Result;

                    dynamic time = JObject.Parse(responseBody);

                    string timeZone = time.timezone;
                    string currentTime = DateTime.Now.ToString();

                    ViewBag.timezone = timeZone;
                    ViewBag.time = currentTime;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
            return View();
        }

        public IActionResult CheckTime()
        {
            return View();
        }

        public IActionResult PlanTrip()
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
