using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testest.Areas.Identity.Data;
using testest.Data;

[assembly: HostingStartup(typeof(testest.Areas.Identity.IdentityHostingStartup))]
namespace testest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<testestContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("testestContextConnection")));

                services.AddDefaultIdentity<testestUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<testestContext>();
            });
        }
    }
}