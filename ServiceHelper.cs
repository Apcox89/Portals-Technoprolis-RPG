using Microsoft.Extensions.DependencyInjection;
using Portals_Technoprolis_RPG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portals_Technoprolis_RPG
{
    public static class ServiceHelper
    {
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Load the connection string from a configuration or environment variable
            string connectionString = GetConnectionString();

            services.AddDbContext<PortalsDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services.BuildServiceProvider();
        }

        private static string GetConnectionString()
        {
            // Option 1: Load from environment variables
            return Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
        }
    }

}
