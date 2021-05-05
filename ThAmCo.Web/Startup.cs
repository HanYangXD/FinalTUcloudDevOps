using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Producks.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using ThAmCo.Auth;
using ThAmCo.Auth.Data.Account;

namespace ThAmCo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<StoreDb>(options => options.UseSqlServer(
                Configuration.GetConnectionString("StoreConnection")));

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var assembly = typeof(ThAmCo.Auth.Controllers.AccountController).Assembly;
            services.AddMvc().AddApplicationPart(assembly).AddControllersAsServices();


            var assembly1 = typeof(ThAmCo.Auth.Controllers.ManageController).Assembly;
            services.AddMvc().AddApplicationPart(assembly1).AddControllersAsServices();
            var assembly2 = typeof(ThAmCo.Auth.Controllers.HomesController).Assembly;
            services.AddMvc().AddApplicationPart(assembly2).AddControllersAsServices();
            var assembly3 = typeof(ThAmCo.Auth.Controllers.UsersController).Assembly;
            services.AddMvc().AddApplicationPart(assembly3).AddControllersAsServices();

            services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("AccountConnection"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "account")
            ));

            // configure Identity account management
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<AccountDbContext>()
                    .AddDefaultTokenProviders();

            // add bespoke factory to translate our AppUser into claims
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, AppClaimsPrincipalFactory>();

            // configure Identity security options
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;

                // Sign-in settings
                options.SignIn.RequireConfirmedEmail = false;
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                        //options.ClientId = Configuration["Authentication:ClientId"];
                        //options.ClientSecret = Configuration["Authentication:ClientSecret"];
                        options.ClientId = "263764767918-fbjqlbef2p0nd74sb7af355rp3k8kkr6.apps.googleusercontent.com";
                        options.ClientSecret = "pi1_xuVtgU1MlrErOVdHwRSy";
                    })
                    .AddFacebook(options =>
                    {
                        IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                        //options.AppId = Configuration["Authentication:AppId"];
                        //options.AppSecret = Configuration["Authentication:AppSecret"];
                        options.AppId = "538795560416730";
                        options.AppSecret = "72b7129d68f0db4b8b413bc10474226c";
                    })
                    .AddJwtBearer("thamco_account_api", options =>
                    {
                        options.Audience = "thamco_account_api";
                        //options.Authority = "https://localhost:5099";
                        options.Authority = "https://localhost:44344";

                    });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // configure IdentityServer (provides OpenId Connect and OAuth2)
            services.AddIdentityServer()
                    .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                    .AddInMemoryApiResources(Configuration.GetIdentityApis())
                    .AddInMemoryClients(Configuration.GetIdentityClients())
                    .AddAspNetIdentity<AppUser>()
                    .AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            // use IdentityServer middleware during HTTP requests
            app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
