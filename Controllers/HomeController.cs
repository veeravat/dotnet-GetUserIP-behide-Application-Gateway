using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using getUserIP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace getUserIP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.clientIP = HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            ViewBag.Header = HttpContext.Request.Headers;
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
