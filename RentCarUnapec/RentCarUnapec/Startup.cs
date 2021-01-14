using jsreport.AspNetCore;
using jsreport.Binary;
using jsreport.Local;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RentCarUnapec.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RentCarUnapec.Data.Interfaces;
using RentCarUnapec.Data.Services;
using RentCarUnapec.Core.Models.Indentity;

namespace RentCarUnapec
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
            services.AddJsReport(new LocalReporting().UseBinary(JsReportBinary.GetBinary()).KillRunningJsReportProcesses().AsUtility().Create());

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContextPool<RentCarDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("RentCarConnectionSQL"));
                options.UseLoggerFactory(Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                }));
            });

            services.AddTransient<IVehicleTypeService, VehicleTypeService>();
            services.AddTransient<IVehicleColorService, VehicleColorService>();
            services.AddTransient<IFuelTypeService, FuelTypeService>();
            services.AddTransient<IFuelTankStateService, FuelTankStateService>();
            services.AddTransient<ITransmissionTypeService, TransmissionTypeService>();
            services.AddTransient<IManufacturerService, ManufacturerService>();
            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IShiftTypeService, ShiftTypeService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<ICarRentInformationService, CarRentInformationService>();
            services.AddTransient<IVehicleCheckService, VehicleCheckService>();
            services.AddTransient<IRentReturnService, RentReturnService>();
            services.AddTransient<IRentStateService, RentStateService>();
            services.AddTransient<IIdentificationTypeService, IdentificationTypeService>();
            services.AddTransient<IClientTypeService, ClientTypeService>();

            services.AddDefaultIdentity<RentCarUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                                 
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddEntityFrameworkStores<RentCarDbContext>();


            services.AddRazorPages();

            services.AddDbContext<RentCarDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("RentCarDBContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
