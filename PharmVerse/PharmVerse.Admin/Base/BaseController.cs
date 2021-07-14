using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PharmVerse.Admin.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace PharmVerse.Admin.Base
{
     public class BaseController : Controller
     {
          public IConfiguration Configuration { get; }
          public readonly ILogger<BaseController> _logger;
          public readonly IPharmVerseApiHttpClient _apiClient;

          public BaseController(IConfiguration configuration, ILogger<BaseController> logger, IPharmVerseApiHttpClient apiClient)
          {
               Configuration = configuration;
               _logger = logger;
               _apiClient = apiClient;

               formatters = new List<MediaTypeFormatter>() { new JsonMediaTypeFormatter(), new XmlMediaTypeFormatter() };
          }

          protected List<MediaTypeFormatter> formatters = new List<MediaTypeFormatter>();
     }
}