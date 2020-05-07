using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrometheusDemo.Models;
using Prometheus;
using System.Net.Http;

namespace PrometheusDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Random rn = new Random();

        // Prometheus metric variables
        private static readonly Counter HomePageHitCounter =
            Metrics.CreateCounter("PrometheusDemo_HomePage_Hit_Count", "Count the number of hits to Home Page");

        private static readonly Gauge SiteVisitorsCounter = Metrics
            .CreateGauge("PrometheusDemo_SiteVisitors_Gauge", "Site Visitors Gauge");


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomePageHitCounter.Inc();

            SiteVisitorsCounter.Set(rn.Next(1, 15));

            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}