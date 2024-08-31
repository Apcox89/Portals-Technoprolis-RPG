using System;
using System.Collections.Generic;
using Portals_Technoprolis_RPG.GameEngine;
using Microsoft.Extensions.DependencyInjection;
using Portals_Technoprolis_RPG.Database;
using Microsoft.EntityFrameworkCore;

/*
 * Andy Cox
 * SD725-Final Project
 * "Portals of Technoprolis" Action-Rpg text version.
 * 
 * This simple program allows a player to assign a name to their Character.
 * Once named, the character is equipped with an initial weapon, and faces an npc-battle.
 * 
 * If they pass the battle, they earn the chance to assign a skill to their Character.
 * 
 * The project demonstrates Inhertiance of class objects,
 * using simple loops, constraining the user input, and allowing the user to do something
 * when they complete a task. The task completion allows for a skill assignment
 * using the "Strategy" design gang-of-four module imported and modified from HW-7.
 * 
 * In the fully-fleshed out action-rpg version, there will be many npcs.
 * This is simply to demo what is required for the final-project and scope of the course.
 * 
 * The System.Collections.Generic API is integrated into the type <T> lists used to 
 * assign values from Player-GameEnvironment interaction. That is demonstrated
 * at ln150 where the Skill chosen by the Player dynamically is assigned to their Skill-class.
 */

//Sept-24-Update:
/*
 ==> Need to abstract logic and add real data
    + working off branching struct for upcoming features
    + cleaning out program-class
 */

namespace Portals_Technoprolis_RPG
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var consoleApp = services.GetRequiredService<ConsoleApp>();
                consoleApp.Run();
            }

            await host.RunAsync();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    if (context.HostingEnvironment.IsDevelopment())
                    {
                        config.AddUserSecrets<Program>();
                    }
                }).ConfigureServices((context, services) =>
                {
                    services.AddDbContext<PortalsDbContext>(options =>
                        options.UseSqlServer(context.Configuration.GetConnectionString("PortalsDb")));

                    services.AddScoped<IPortalsDbContext>(provider => provider.GetService<PortalsDbContext>());

                    services.AddTransient<ConsoleApp>(); // Add ConsoleApp to services
                });

    }

}

