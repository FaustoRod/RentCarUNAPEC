using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(RentCarUnapec.Areas.Identity.IdentityHostingStartup))]
namespace RentCarUnapec.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}