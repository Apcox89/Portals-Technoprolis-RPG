using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portals_Technoprolis_RPG.Models;
using Portals_Technoprolis_RPG.Activities;

namespace Portals_Technoprolis_RPG.Activities
{
    public class CombatManager
    {
        public void Fight(Player player, Npc enemy)
        {
            while (enemy.CurrentHealth > 0)
            {
                Console.WriteLine("Use your weapon to defeat the roboguard. (type a number 1-3)\n");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int playerInteraction) && (playerInteraction >= 1 && playerInteraction <= 3))
                {
                    Console.WriteLine($"You deal {playerInteraction} damage to the robo-guard.");
                    enemy.CurrentHealth = Math.Max(0, enemy.CurrentHealth - playerInteraction);
                    Console.WriteLine($"Robo guard current health: {enemy.CurrentHealth}\n");

                    if (enemy.CurrentHealth == 0)
                    {
                        Console.WriteLine("You have defeated the Robo-Commando!\n");
                        break;
                    }
                }
                else
                {
                    player.CurrentHealth = Math.Max(0, player.CurrentHealth - 10);
                    Console.WriteLine($"You lose health points: {player.CurrentHealth}\n");
                    Console.WriteLine("Please type a number in your weapon's range!\n");

                    if (player.CurrentHealth == 0)
                    {
                        Console.WriteLine("You have been defeated. Game over.");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }

}
