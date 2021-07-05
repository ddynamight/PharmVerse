using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PharmVerse.Admin.Base;
using PharmVerse.Admin.Services.Interfaces;

namespace PharmVerse.Admin.Controllers
{
     [Authorize(Policy = "IsAdmin"), Route("/")]
     public class HomeController : BaseController
     {
          public HomeController(IConfiguration configuration, ILogger<BaseController> logger, IPharmVerseApiHttpClient apiClient) : base(configuration, logger, apiClient)
          {
          }


          public async Task<IActionResult> Index()
          {
               var client = await _apiClient.GetClient();
               var userId = User.Identity.GetSubjectId();

               return View();
          }
     }
}
