using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teknologisk.Kursus.WebsiteSql.Models;

namespace Teknologisk.Kursus.WebsiteSql.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        TelemetryClient telemetryClient = new TelemetryClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var dict = new Dictionary<string, string>();
            dict.Add("Host", HttpContext.Request.Host.Value);
            dict.Add("User.Identity", HttpContext.User.Identity.Name);
            telemetryClient.TrackTrace("User load frontpage",SeverityLevel.Critical, dict);

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
