using System;
using AppV1.Areas.Identity.Data;
using AppV1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AppV1.Areas.Identity.IdentityHostingStartup))]
namespace AppV1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppV1Context>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<AppV1User>(options =>
				{
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                    .AddEntityFrameworkStores<AppV1Context>();
            });
        }
    }
}