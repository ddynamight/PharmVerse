using IdentityModel.AspNetCore.AccessTokenManagement;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IdentityModel.Tokens.Jwt;
using PharmVerse.Admin.Services.Implementations;
using PharmVerse.Admin.Services.Interfaces;


namespace PharmVerse.Admin
{
     public class Startup
     {
          // This method gets called by the runtime. Use this method to add services to the container.
          // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

          public Startup(IConfiguration configuration)
          {
               Configuration = configuration;
          }

          public IConfiguration Configuration { get; }



          public void ConfigureServices(IServiceCollection services)
          {
               #region Self Configured IdentityServer4 Stuff Here

               services.Configure<CookiePolicyOptions>(options =>
               {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
               });

               services.AddControllersWithViews()
                    .AddNewtonsoftJson(options =>
                    {
                         options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                         options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    });

               JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

               services.AddAuthentication(options =>
               {
                    options.DefaultChallengeScheme = "oidc";
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = "oidc";
               })
               .AddCookie("Cookies", options =>
               {
                    options.AccessDeniedPath = "/login/accessdenied";
               })
               .AddOpenIdConnect("oidc", options =>
               {
                    options.Authority = Configuration["AuthServer:AuthBaseUrl"];
                    options.RequireHttpsMetadata = false;
                    options.ClientId = Configuration["AuthServer:ClientId"];
                    options.ClientSecret = Configuration["AuthServer:ClientSecret"];
                    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;
                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("pharmverseapp");
                    options.Scope.Add("offline_access");
                    options.Scope.Add("roles");
                    options.SignedOutRedirectUri = "/";
                    //options.CallbackPath = "/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                         NameClaimType = "name",
                         RoleClaimType = "role",
                    };
                    options.ClaimActions.Remove("nonce");
                    options.ClaimActions.Remove("aud");
                    options.ClaimActions.Remove("azp");
                    options.ClaimActions.Remove("acr");
                    options.ClaimActions.Remove("amr");
                    options.ClaimActions.Remove("iss");
                    options.ClaimActions.Remove("iat");
                    options.ClaimActions.Remove("nbf");
                    options.ClaimActions.Remove("exp");
                    options.ClaimActions.Remove("at_hash");
                    options.ClaimActions.Remove("c_hash");
                    options.ClaimActions.Remove("auth_time");
                    options.ClaimActions.Remove("ipaddr");
                    options.ClaimActions.Remove("platf");
                    options.ClaimActions.Remove("ver");
                    options.ClaimActions.Remove("role");

                    options.ClaimActions.MapUniqueJsonKey("sub", "sub");
                    options.ClaimActions.MapUniqueJsonKey("name", "name");
                    options.ClaimActions.MapUniqueJsonKey("given_name", "given_name");
                    options.ClaimActions.MapUniqueJsonKey("family_name", "family_name");
                    options.ClaimActions.MapUniqueJsonKey("profile", "profile");
                    options.ClaimActions.MapUniqueJsonKey("email", "email");
                    options.ClaimActions.MapUniqueJsonKey("website", "website");
                    options.ClaimActions.MapUniqueJsonKey("role", "role");
               });

               services.AddAuthorization(options =>
               {
                    options.AddPolicy("IsAdmin", policyBuilder =>
                    {
                         policyBuilder.RequireAuthenticatedUser();
                         policyBuilder.RequireClaim("role", new[] { "Admin" });
                    });
               });

               #endregion

               services.AddCors(cfg =>
               {
                    cfg.AddDefaultPolicy(policy =>
                    {
                         policy.AllowAnyHeader();
                         policy.AllowAnyMethod();
                         policy.AllowAnyOrigin();
                         policy.WithMethods();
                    });
               });


               services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
               services.AddHttpClient<IPharmVerseApiHttpClient, PharmVerseApiHttpClient>()
                    .AddHttpMessageHandler<UserAccessTokenHandler>();

               services.AddAccessTokenManagement()
                    .ConfigureBackchannelHttpClient(client =>
                    {

                         client.Timeout = TimeSpan.FromSeconds(60);
                    });


               //ToDo: Add Logging


               services.AddMvc();
               services.AddControllersWithViews();
               services.AddRazorPages();
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
          {
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
               }
               else
               {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
               }

               app.UseHttpsRedirection();
               app.UseStaticFiles();

               app.UseRouting();
               app.UseCors();

               app.UseAuthentication();
               app.UseAuthorization();

               app.UseEndpoints(endpoints =>
               {
                    endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
               });
          }
     }
}