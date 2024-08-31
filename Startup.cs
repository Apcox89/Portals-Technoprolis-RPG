using Microsoft.AspNetCore.Builder;
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

        // Other methods...
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // ConfigureServices method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PortalsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PortalsDb")));

            // Add other services as needed
        }

        // Configure method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Add other middleware as needed

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Or other endpoints as required
            });
        }
    }
}
