using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portals_Technoprolis_RPG.Models;

namespace Portals_Technoprolis_RPG.Activities
{
    abstract class PlayerBoost
    {
        public abstract void Boost(string player);
    }

    //4 subclasses return a different outcome based on same type-cast
    class Health : PlayerBoost
    {
        public override void Boost(string player)
        {
            Console.WriteLine("\n  " + player + " applied to overall health.");
        }
    }

    class Damage : PlayerBoost
    {
        public override void Boost(string player)
        {
            Console.WriteLine("\n  " + player + " applied to damage dealing to npcs.");
        }
    }

    class Knowledge : PlayerBoost
    {
        public override void Boost(string player)
        {
            Console.WriteLine("\n  " + player + " applied to programming knowledge to enter Portals.");
        }
    }

    class Shield : PlayerBoost
    {
        public override void Boost(string player)
        {
            Console.WriteLine("\n  " + player + " applied to your armor.");
        }
    }

    //this class acts as a constructor to define the behavior of the data type being passed in by the user
    class BoostingMethod
    {
        private string? Player;
        private PlayerBoost? _playerBoost;

        public void SetPlayerBoost(PlayerBoost elixerBoost)
        {
            this._playerBoost = elixerBoost;
        }

        public void SetBoost(string name)
        {
            Player = name;
        }

        public void Boost()
        {
            _playerBoost.Boost(Player);
            Console.WriteLine();
        }
    }
}
