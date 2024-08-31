using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portals_Technoprolis_RPG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals_Technoprolis_RPG
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PortalsDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Portals;Trusted_Connection=True;"));

            // Other service registrations
        }

        // Other methods...
    }
}
