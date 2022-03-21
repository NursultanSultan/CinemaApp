using CinemaApp.Business.Implementations;
using CinemaApp.Business.Interfaces;
using CinemaApp.Business.Profiles;
using CinemaApp.Core;
using CinemaApp.DataAcces;
using CinemaApp.DataAcces.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaApp.UI
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
            //services.AddAutoMapper(typeof(Startup));
            services.AddMapperService();

            services.AddControllersWithViews();
            

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"]);
            });

            services.AddScoped<IUnitOfWork , UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IFormatService, FormatService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IContactUsService, ContactUsService>();

            services.AddIdentity<IdentityUser, IdentityRole>(opt => { opt.SignIn.RequireConfirmedEmail = true; })
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            

            services.AddControllers().AddNewtonsoftJson(x =>
                 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAuthentication()
                            .AddGoogle(options => {


                                options.ClientId = "104954020607-duuco9c1pq89o5ck20b5spu1i0h6gqsi.apps.googleusercontent.com";
                                options.ClientSecret = "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";
                            });
            services.AddAuthentication()
                            .AddFacebook(options => {


                                options.AppId = "328701479233888";
                                options.AppSecret = "2ed5d93fd46a70bb5ee1d08a1f00fbf3";
                            });
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });
        }
    }
}
