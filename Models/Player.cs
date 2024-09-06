using System;
using System.Collections.Generic;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Loot { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsDead => CurrentHealth <= 0;
        public List<Skill> PlayerSkillCollection { get; set; }

        public Player() { }

        public Player(string pName, int loot, int xp, int level, int currentHealth, int maxHealth)
        {
            Name = pName;
            Loot = loot;
            Xp = xp;
            Level = level;
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
            PlayerSkillCollection = new List<Skill>();
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

        public string DisplayStats()
        {
            return $"{Name} is playing as Bill Gnant, rebel-leader. Current Health: {CurrentHealth} \nLoot: {Loot} XP: {Xp} Current Level: {Level}";
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
}
