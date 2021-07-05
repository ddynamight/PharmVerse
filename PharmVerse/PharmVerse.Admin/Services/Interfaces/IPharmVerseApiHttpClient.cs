using System.Net.Http;
using System.Threading.Tasks;

namespace PharmVerse.Admin.Services.Interfaces
{
     public interface IPharmVerseApiHttpClient
     {
          Task<HttpClient> GetClient();
     }
}