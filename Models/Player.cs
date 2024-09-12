using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    public class Player : IPlayer
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

        public Player() {
            Name = string.Empty; // Initialize Name to an empty string
            PlayerSkillCollection = new List<Skill>(); // Initialize PlayerSkill
        }

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
        /* //Cox note: ex for why using an interface i.e contract/guarantee 
           // ++ ex of system reflection change and why the abstraction -- gets entire object instance
        */
        public string DisplayStats()
        {
            StringBuilder stats = new StringBuilder();
            // Handle the Name property separately
            stats.AppendLine($"{Name} is playing as Bill Gnant, rebel-leader.");

            //using system-reflection:
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == nameof(PlayerSkillCollection) 
                    ||  property.Name == nameof(ID) || property.Name == nameof(Name))
                {
                    continue; // Skip PlayerSkillCollection and ID properties
                }

                object value = property.GetValue(this, null);
                stats.AppendLine($"{property.Name}: {value}");
            }

            return stats.ToString();
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
