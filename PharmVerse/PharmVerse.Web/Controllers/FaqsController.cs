using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PharmVerse.Web.Controllers
{
    public class FaqsController : Controller
    {
        private readonly ILogger<FaqsController> _logger;

        public FaqsController(ILogger<FaqsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
