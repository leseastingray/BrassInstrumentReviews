using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BrassInstrumentReviews.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.CookiePolicy;

namespace BrassInstrumentReviews
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
            services.AddControllersWithViews();

            // This addition should help prevent cross-site request forgery
            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties†.
                options.FormFieldName = "AntiforgeryFieldname";
                options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
                options.SuppressXFrameOptionsHeader = false;
            });
            // Dependency injection for repos into controllers
            //services.AddTransient<IReviewRepository, ReviewRepository>();

            // To connect with the local database
            services.AddDbContext<InstrumentReviewContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("InstrumentReviewContext")));
            services.AddIdentity<Reviewer, IdentityRole>()
                .AddEntityFrameworkStores<InstrumentReviewContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiForgery, InstrumentReviewContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // An additional protection against cross-site request forgery
            app.Use(next => context =>
            {
                string path = context.Request.Path.Value;

                if (
                    string.Equals(path, "/", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(path, "/index.html", StringComparison.OrdinalIgnoreCase))
                {
                    // The request token can be sent as a JavaScript-readable cookie, 
                    // and Angular uses it by default.
                    var tokens = antiForgery.GetAndStoreTokens(context);
                    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
                        new CookieOptions() { HttpOnly = false });
                }

                return next(context);
            });
            // An addition to address the X-Frame-Options Header not set issue
            app.Use(async (ctx, next) => {
                ctx.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                ctx.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });
            // An addition to address cookie without secure flag issue
            app.UseCookiePolicy(new CookiePolicyOptions { 
                HttpOnly = HttpOnlyPolicy.Always, Secure = CookieSecurePolicy.Always 
            });

            // Added to enable Identity, Authentication must come first
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Variables for new seed method
            var serviceProvider = app.ApplicationServices;
            var userManager = serviceProvider.GetRequiredService<UserManager<Reviewer>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // New seed method, calls Seed() from SeedData class
            SeedData.Seed(context, userManager, roleManager);

            // Old seed method, calls CreateAdminUser method from InstrumentReviewContext, built on additional code in CreateHostBuilder method in Program.cs
            //InstrumentReviewContext.CreateAdminUser(app.ApplicationServices).Wait();
        }
    }
}
