using Laborotorna6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Laborotorna6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet("divided")]
        public IActionResult Divided()
        {
            int x = 10;
            int y = 0;
            int z = x / y;

            return View("Index");
        }
        [HttpPost]
        public IActionResult Cookies(string value, DateTime data) {
            if (!string.IsNullOrEmpty(value)){
                CookieOptions cookieOptions = new CookieOptions { Expires = data};
                Response.Cookies.Append("Value", value, cookieOptions);
                Response.Cookies.Append("Data", data.ToString(), cookieOptions);
                ViewData["Message"] = "Cookie встановлено";
                ViewData["Value"] = value;
            }
            else
            {
                ViewData["Message"] = "Некоректні данні";
            }
            return View("Index");
        }

        public IActionResult CookieValue() {
            string value = Request.Cookies["Value"];
            string data = Request.Cookies["Data"];
            if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(data)) {
                ViewData["message"] = "Cookie встановлено";
                ViewData["Value"] = value;
                ViewData["Data"] = data;
            }
            else
            {
             
                ViewData["message"] = "Cookie не встановлено";
                ViewData["Value"] = null;
                ViewData["Data"] = null;
            }
            return View();
        }
        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });*
        }*/
    }
}
