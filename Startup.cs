using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Portals_Technoprolis_RPG.Database;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace Portals_Technoprolis_RPG
{
    public class Startup
    {
        // Other methods...
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //Cox note: switch project to api-version that runs on localhost
        public IConfiguration Configuration { get; }

        // ConfigureServices method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PortalsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PortalsDb")));

            // Add other services as needed
            services.AddControllers()
                .AddNewtonsoftJson();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portals Technoprolis RPG API", Version = "v1" });
            });
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
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portals Technoprolis RPG API V1");
                c.RoutePrefix = string.Empty;
            });

            // Add other middleware as needed

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Or other endpoints as required
            });
        }
    }
}
