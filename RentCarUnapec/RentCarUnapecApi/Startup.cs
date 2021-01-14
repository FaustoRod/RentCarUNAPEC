using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RentCarUnapec.Data.Interfaces;
using RentCarUnapec.Data.Services;
using SQLitePCL;

namespace RentCarUnapecApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:50894", "https://localhost:44370/").AllowAnyOrigin();
                });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            services.AddDbContext<RentCarUnapec.Data.RentCarDbContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("RentCarUnapecDbContext"));
                    options.UseLoggerFactory(Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
                    {
                        builder.AddConsole();
                    }));
                });

            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IRentReturnService, RentReturnService>();
            services.AddScoped<ICarRentInformationService, CarRentInformationService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            //app.UseCors(options =>
            //{
            //    options.WithOrigins("http://localhost:50894").AllowAnyOrigin();
            //});
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
