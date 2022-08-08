using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppV1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppV1.Data
{
    public class AppV1Context : IdentityDbContext<AppV1User>
    {

        public AppV1Context(DbContextOptions<AppV1Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
