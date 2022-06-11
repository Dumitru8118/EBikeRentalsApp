//using EBikeRentalsApp.Data;
using EBikeRentalsApp.DbAccessLayer;
using EBikeRentalsApp.Models;
using EBikeRentalsApp.Repository.Bikes;
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

namespace EBikeRentalsApp
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

            var connectionString = new DatabaseConfig { Name = Configuration.GetConnectionString("DefaultConnection") };
            services.AddSingleton(connectionString);

            //services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            //services.AddSingleton<IBikeData, BikeData>();

            //services.AddSingleton(new DatabaseConfig { Name = Configuration["DefaultConnection"] });
            //services.AddScoped<IGenericRepository<BikeModel>, GenericRepository<BikeModel>>();
            services.AddScoped<IBikesRepository<BikeModel>, BikesRepository<BikeModel>>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
