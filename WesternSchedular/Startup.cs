using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Repository.Models;
using Repository.Services;
using Microsoft.AspNetCore.Cors;

namespace WesternSchedular
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
            services.AddDbContext<WesternSchedulerContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:conn"]));
            services.AddMvc();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IEventsServices, EventServices>();
            services.AddScoped<IEventMangerService, EvenManagerService>();
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<IProjectNumberServices, ProjectNumberServices>();
            services.AddScoped<ICommonServices, CommonServices>();
            services.AddScoped<IDepartmentServices, DepartmentServices>();
            services.AddScoped<ISchedulerInfoServices, SchedulerInfoServices>();
            services.AddScoped<IProjectScheduler, ProjectSchedulerServices>();
            services.AddScoped<IProjectReviewServices, ProjectReviewServices>();
            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://devintranet.westernoffice.com/")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                  "CorsPolicy",
                  builder => builder.WithOrigins("http://192.168.104.53:8088")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
            });
            services.AddSwaggerDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CorsPolicy");
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
