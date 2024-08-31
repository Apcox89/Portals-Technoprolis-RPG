using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portals_Technoprolis_RPG.Models;
using Portals_Technoprolis_RPG.Activities;
using Portals_Technoprolis_RPG.Database;


namespace Portals_Technoprolis_RPG.GameEngine
{
    public class Game
    {
        private readonly PortalsDbContext _dbContext;
        private Player _player;
        private CombatManager _combatManager;

        public Game(PortalsDbContext dbContext)
        {
            _dbContext = dbContext;
            _combatManager = new CombatManager();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Technoprolis!");

            _player = InitializePlayer();

            // Display Player Stats
            Console.WriteLine($"Player stats: {_player.DisplayStats()}\n");

            // Start the Game
            Location start = new Location(World.LOCATION_ID_BASE_CAMP, "Base-Camp", "Start-Game");
            Console.WriteLine(start.DisplayLocation());

            // Initialize Weapon and NPC
            Weapon bluntAxeHandle = new Weapon(1, 3, 1, "Blunt Axe Handle");
            Npc roboGuard1 = new Npc(World.NPC_ID_ROBO_COMMANDO, "Robo-Commando", 3, 20, 5, 10, 10);

            Console.WriteLine(bluntAxeHandle.DisplayWeapon() + "\n");
            Console.WriteLine("Complete the initial Quest to assign a new skill to your Character.\n");

            // Combat
            _combatManager.Fight(_player, roboGuard1);

            // Post-Combat
            HandlePostCombat(roboGuard1);

            // Skill Boosting
            BoostPlayerSkills();

            Console.WriteLine($"See you next time {_player.PlayerName} in another battle for Technoprolis.\n");
        }

        private Player InitializePlayer()
        {
            Console.WriteLine("What do you want to name your Player?");
            string input = Console.ReadLine();

            var player = new Player(001, input, 10, 0, 1, 100, 100);

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Player name cannot be empty.");
                return player; // or set a default name
            }

            // Add player to the database
            _dbContext.Players.Add(player);
            _dbContext.SaveChanges();

            return player;
        }

        private void HandlePostCombat(Npc roboGuard)
        {
            _player.LootUpdate(_player.Loot + roboGuard.AwardLoot);
            _player.PointsUpdate(_player.Xp + roboGuard.AwardXP);
            _player.LvlUp(_player.Level + 1);

            Console.WriteLine("= = = = = = = = = = = = = = = ");
            Console.WriteLine("You've achieved a new level!");
            Console.WriteLine("= = = = = = = = = = = = = = = \n");
            Console.WriteLine(_player.DisplayStats() + "\n");
        }

        private void BoostPlayerSkills()
        {
            BoostingMethod boostMethod = new BoostingMethod();
            List<Skill> skills = new List<Skill>();

            while (true)
            {
                Console.WriteLine("Do you want to boost your player skill now or save? (type 'boost' or 'save')\n");
                string input = Console.ReadLine();
                if (input == "save")
                    break;

                boostMethod.SetBoost(input);
                Console.WriteLine("Do you want to boost your player's 'Health', 'Damage', 'Knowledge', or 'Shield'?");
                string playerBoost = Console.ReadLine();

                Type p = Type.GetType("Portals_Technoprolis_RPG.Activities." + playerBoost);
                PlayerBoost pBoost = (PlayerBoost)Activator.CreateInstance(p);

                boostMethod.SetPlayerBoost(pBoost);
                boostMethod.Boost();

                Console.WriteLine($"You have chosen the {playerBoost} boost.\n");
                skills.Add(new Skill(001, playerBoost));
                Console.WriteLine($"The new skill has upgraded your current {playerBoost} level.\n");

                foreach (Skill aSkill in skills)
                {
                    Console.WriteLine(aSkill + "\n");
                }

                Console.WriteLine(" = = = = = = = = \n");
                break;
            }
        }
    }

}
