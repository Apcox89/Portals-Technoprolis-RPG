using System;
using System.Collections.Generic;
using Portals_Technoprolis_RPG.Models;
using Portals_Technoprolis_RPG.Activities;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    public class Character
    {
        //both Npc's and the Player are a type of Character
        public int Id { get; set; } // Primary key
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsDead { get; set; }

        //constructor:
        public Character() { }

        public Character(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;

        }

        public void UpdateHealth(int healthChange)
        {
            CurrentHealth = Math.Clamp(CurrentHealth + healthChange, 0, MaxHealth);
        }

        public void TakeDamage(int damage)
        {
            UpdateHealth(-damage);
        }

        public void Heal(int healingAmount)
        {
            UpdateHealth(healingAmount);
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
        public Player() : base() { }

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

        public Npc() : base() { }

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
