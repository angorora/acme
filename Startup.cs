using System;
using acme_employees.Data;
using acme_employees.Data.Repository.Implementations;
using acme_employees.Data.Repository.Interfaces;
using acme_employees.Services.Implementations;
using acme_employees.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace acme_employees
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

            //services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<AcmeContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("AcmeDatabase")));
             services.AddTransient<IEmployeeRepository, EmployeeRepository>();
             services.AddTransient<IEmployeeDataService, EmployeeDataService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           // app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-development");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
        }
    }
}
