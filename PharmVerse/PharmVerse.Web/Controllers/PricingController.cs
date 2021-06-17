using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PharmVerse.Web.Controllers
{
    public class PricingController : Controller
    {
        private readonly ILogger<PricingController> _logger;

        public PricingController(ILogger<PricingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
