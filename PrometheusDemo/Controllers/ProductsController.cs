using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace PrometheusDemo.Controllers
{
    public class ProductsController : Controller
    {
        // Prometheus metric variables
        private static readonly Counter ProductsPageHitCounter =
            Metrics.CreateCounter("PrometheusDemo_ProductsPage_Hit_Count", "Count the number of hits to Products Page");

        // GET    
        public IActionResult Index()
        {
            ProductsPageHitCounter.Inc();
            return View();
        }
    }
}