using System;
using System.Collections.Generic;
using Portals_Technoprolis_RPG.Models;
using Portals_Technoprolis_RPG.Activities;

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

//May-22-Update:
/*
 ==> Need to abstract logic and add real data
    + working off branching struct for upcoming features
    + cleaning out program-class
 */

namespace Portals_Technoprolis_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            int playerInteraction;

            Player player1 = new Player(001, " ", 10, 0, 1, 100, 100);
            Console.WriteLine("Welcome to Technoprolis, what do you want to name your Player?");
            input = Console.ReadLine();
            player1.PlayerName = input.ToString();

            Console.WriteLine(" Player stats: {0} \n", player1.DisplayStats());

            Location start = new Location(World.LOCATION_ID_BASE_CAMP, "Base-Camp", "Start-Game");
            Console.WriteLine(start.DisplayLocation());

            Weapon bluntAxeHandle = new Weapon(1, 3, 1, "Blunt Axe Handle");

            Console.WriteLine(bluntAxeHandle.DisplayWeapon() + "\n");
            Console.WriteLine("Complete the initial Quest to assign a new skill to your Character.\n");

            Console.WriteLine("You leave your rebel base camp, and find some robo-guard at a destroyed statue: \n");
            Console.WriteLine(" ~~ Beat the robo-guard to assign your character a new skill ~~ \n");

            Npc roboGuard1 = new Npc(World.NPC_ID_ROBO_COMMANDO, "Robo-Commando", 3, 20, 5, 10, 10);

            do
            {
                int health;

                Console.WriteLine("Use your weapon to defeat the roboguard. (type a number 1-3) \n");
                input = Console.ReadLine();

                playerInteraction = int.Parse(input);

                //need to constrain so user can't go into negative points on roboguard
                if ((playerInteraction >= 1 && playerInteraction <= 3))
                {

                    Console.WriteLine("You deal " + playerInteraction + " damage to the robo-guard.");

                    health = roboGuard1.CurrentHealth - playerInteraction;

                    Console.WriteLine("Robo guard current health: " + roboGuard1.HealthUpdate(health));

                }
                else
                {
                    //player loses 10 health for not entering correct number:
                    health = player1.CurrentHealth - 10;
                    Console.WriteLine("You lose health points " + player1.HealthUpdate(health) + "\n");
                    Console.WriteLine("Please type a number in your weapon's range! \n");
                }

                if (roboGuard1.IsDead == true)
                {
                    roboGuard1.CurrentHealth = 0;
                    break;
                }

                if (player1.CurrentHealth == 0)
                {
                    //player is dead from lost battle, reset:
                    Environment.Exit(0);
                }

                if (input == null)
                {
                    Environment.Exit(0);
                }

            }

            while (roboGuard1.CurrentHealth > 0);

            player1.LootUpdate(player1.Loot + roboGuard1.AwardLoot);
            player1.PointsUpdate(player1.Xp + roboGuard1.AwardXP);
            player1.LvlUp(player1.Level + 1);

            Console.WriteLine("= = = = = = = = = = = = = = = ");
            Console.WriteLine("You've achieved a new level!");
            Console.WriteLine("= = = = = = = = = = = = = = = \n");

            Console.WriteLine(player1.DisplayStats() + "\n");
            Console.WriteLine("You defeat the robo-guard to gain a skill. \n");

            //assign skill abstract strategy implementation + implement skill interface
            BoostingMethod boostMethod = new BoostingMethod();

            List<Skill> skills = new List<Skill>();
            //add the chosen skill to the Skill Class

            while (true)
            {
                Console.WriteLine("Do you want to boost your player skill now or save? \n(type 'boost' or 'save') \n");
                input = Console.ReadLine();
                if (input == "save")
                {
                    break;
                }

                boostMethod.SetBoost(input);

                Console.WriteLine("Do you want to boost your player's 'Health','Damage', 'Knowledge', or 'Shield'?");
                string player = Console.ReadLine();
                //input = Console.ReadLine();

                Type p = Type.GetType("Portals_Technoprolis_RPG.Activities." + player);

                PlayerBoost pBoost = (PlayerBoost)Activator.CreateInstance(p);
                boostMethod.SetPlayerBoost(pBoost);
                boostMethod.Boost();
                Console.WriteLine("You have chosen the " + player + " boost. \n");

                //add the chosen skill to the Skill-attribute class
                skills.Add(new Skill(001, player));
                Console.WriteLine("The new skill has upgraded your current " + player + " level. \n");
                foreach (Skill aSkill in skills)
                {
                    Console.WriteLine(aSkill + "\n");
                }

                Console.WriteLine(" = = = = = = = = \n");
                break;

            }

            Console.WriteLine("See you next time " + player1.PlayerName + " in another battle for Technoprolis. \n");
            Environment.Exit(0);

        }

    }

}

