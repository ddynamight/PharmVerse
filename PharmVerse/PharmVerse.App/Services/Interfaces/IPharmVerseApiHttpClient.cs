using System.Net.Http;
using System.Threading.Tasks;

namespace PharmVerse.App.Services.Interfaces
{
     public interface IPharmVerseApiHttpClient
     {
          Task<HttpClient> GetClient();
     }
}