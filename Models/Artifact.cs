using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    public class Artifact
    {
        //base class for items - weapons, elixers, loot, and inventory
        public int ArtifactID { get; set; }
        public string ArtifactName { get; set; }

        public Artifact(int artifactId, string artifactName)
        {
            ArtifactID = artifactId;
            ArtifactName = artifactName;
        }
    }

    public class Weapon : Artifact
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int minDamage, int maxDamage, int artifactID, string artifactName) : base(artifactID, artifactName)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        public string DisplayWeapon()
        {
            return "You're equipped with " + ArtifactName + " Dealing Damage range from " + MinimumDamage + " to " + MaximumDamage;
        }


    }

    public class Elixer : Artifact
    {
        //elixers may be more than revive, for now its just a health regen
        public int RevivePlayer { get; set; }

        public Elixer(int revive, int artifactID, string artifactName) : base(artifactID, artifactName)
        {
            RevivePlayer = revive;
        }
    }

    //recall that an inventory is a collection of items, hmm.
    public class Inventory : Artifact
    {
        public int Quantity { get; set; }

        //+ list type of inventory needed to display to user
        public List<Artifact> InventoryCollection = new List<Artifact>();

        public Inventory(int qty, int artifactID, string artifactName) : base(artifactID, artifactName)
        {
            Quantity = qty;
        }
    }

    public class Loot : Artifact
    {
        public int LootItemReceived { get; set; }

        public Loot(int getLootItem, int artifactID, string artifactName) : base(artifactID, artifactName)
        {
            LootItemReceived = getLootItem;
        }
    }
}
