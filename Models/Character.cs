using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    public class Character
    {
        //both Npc's and the Player are a type of Character
        //they will both have health attributes and be either alive or dead:
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsDead { get; set; }

        //struct:
        public Character(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;

        }

        public int HealthUpdate(int healthStat)
        {
            return this.CurrentHealth = healthStat;
        }
    }

    public class Player : Character
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public int Loot { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }

        //implement skill class interface/strategy
        public List<Skill> PlayerSkillCollection { get; set; }

        public Player(int pID, string pName, int loot, int xp, int level,
            int currentHealth, int maxHealth) : base(currentHealth, maxHealth)
        {
            PlayerID = pID;
            PlayerName = pName;
            Loot = loot;
            Xp = xp;
            Level = level;

            PlayerSkillCollection = new List<Skill>();
        }

        //Functional Requirement #1.6
        public string DisplayStats()
        {
            return PlayerName + " is playing as Bill Gnant, rebel-leader." + " Current Health: " + CurrentHealth + " \n" +
                    " Loot: " + Loot + " XP: " + Xp + " Current Level: " + Level;
        }

        public int LootUpdate(int addLoot)
        {
            return Loot = addLoot;
        }

        public int PointsUpdate(int newPoints)
        {
            return Xp = newPoints;
        }

        public int LvlUp(int newLvl)
        {
            return Level = newLvl;
        }

    }

    public class Npc : Character
    {
        public int NpcID { get; set; }
        public string NpcName { get; set; }
        public int MaxDamage { get; set; }
        public int AwardXP { get; set; }
        public int AwardLoot { get; set; }

        public Npc(int npcid, string npcname, int maxDamage, int awardXP,
            int awardLoot, int currentHealth, int maxHealth) : base(currentHealth, maxHealth)
        {
            NpcID = npcid;
            NpcName = npcname;
            MaxDamage = maxDamage;
            AwardXP = awardXP;
            AwardLoot = awardLoot;

        }

        public string DisplayNPC()
        {
            return NpcName;
        }

    }
}
