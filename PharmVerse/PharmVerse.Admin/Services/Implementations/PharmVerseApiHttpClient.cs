using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using PharmVerse.Admin.Services.Interfaces;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PharmVerse.Admin.Services.Implementations
{
     public class PharmVerseApiHttpClient : IPharmVerseApiHttpClient
     {
          private readonly IHttpContextAccessor _httpContextAccessor;
          public IConfiguration Configuration { get; }
          private readonly HttpClient client = new HttpClient();

          public PharmVerseApiHttpClient(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, HttpClient _client)
          {
               _httpContextAccessor = httpContextAccessor;
               Configuration = configuration;
               client = _client;
          }

          public async Task<HttpClient> GetClient()
          {
               string accessToken = await GetAccessToken();
               if (!string.IsNullOrWhiteSpace(accessToken))
               {
                    client.SetBearerToken(accessToken);
               }

               client.BaseAddress = new Uri($"{Configuration["AuthServer:ApiBaseUrl"]}");
               client.DefaultRequestHeaders.Accept.Clear();
               client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               return client;
          }


          public async Task<string> GetAccessToken()
          {
               var exp = await _httpContextAccessor.HttpContext.GetTokenAsync("expires_at");
               var expires = DateTime.Parse(exp);
               if (!string.IsNullOrWhiteSpace(exp) || expires > DateTime.Now)
               {
                    return await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
               }
               return await GetRefreshAccessToken();
          }

          public async Task<string> GetRefreshAccessToken()
          {
               var discoClient = await client.GetDiscoveryDocumentAsync(Configuration["AuthServer:AuthBaseUrl"]);
               var tokenClientOptions = new TokenClientOptions
               {
                    Address = Configuration["AuthServer:AuthBaseUrl"],
                    AuthorizationHeaderStyle = BasicAuthenticationHeaderStyle.Rfc6749,
                    ClientId = Configuration["AuthServer:ClientId"],
                    ClientSecret = Configuration["AuthServer:ClientSecret"]
               };

               var tokenClient = new TokenClient(client, tokenClientOptions);


               var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
               var tokenResponse = await tokenClient.RequestRefreshTokenAsync(refreshToken);

               if (!tokenResponse.IsError)
               {
                    var auth = await _httpContextAccessor.HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    auth.Properties.UpdateTokenValue(OpenIdConnectParameterNames.AccessToken, tokenResponse.AccessToken);
                    auth.Properties.UpdateTokenValue(OpenIdConnectParameterNames.RefreshToken, tokenResponse.RefreshToken);

                    var expieresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResponse.ExpiresIn);
                    auth.Properties.UpdateTokenValue("expieres_at", expieresAt.ToString("o", CultureInfo.InvariantCulture));
                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, auth.Principal, auth.Properties);

                    return tokenResponse.AccessToken;
               }
               //return await GetAccessToken();
               throw tokenResponse.Exception;
          }
     }
}
