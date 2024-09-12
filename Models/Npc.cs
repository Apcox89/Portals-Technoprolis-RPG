using System;

namespace Portals_Technoprolis_RPG.Models
{
    [Serializable]
    public class Npc
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxDamage { get; set; }
        public int AwardXP { get; set; }
        public int AwardLoot { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsDead => CurrentHealth <= 0;

        public Npc() { }

        public Npc(int npcid, string npcname, int maxDamage, int awardXP, int awardLoot, int currentHealth, int maxHealth)
        {
            ID = npcid;
            Name = npcname;
            MaxDamage = maxDamage;
            AwardXP = awardXP;
            AwardLoot = awardLoot;
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

        public string DisplayNPC()
        {
            return Name;
        }
    }
}
