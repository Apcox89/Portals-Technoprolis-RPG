namespace Portals_Technoprolis_RPG.Models
{
    //Cox note: wk-3 review example interface from base-class
    public interface IPlayer
    {
        int ID { get; set; }
        string Name { get; set; }
        int Loot { get; set; }
        int Xp { get; set; }
        int Level { get; set; }
        int CurrentHealth { get; set; }
        int MaxHealth { get; set; }
        bool IsDead { get; }
        List<Skill> PlayerSkillCollection { get; set; }

        void UpdateHealth(int healthChange);
        void TakeDamage(int damage);
        void Heal(int healingAmount);
        string DisplayStats();
        int LootUpdate(int addLoot);
        int PointsUpdate(int newPoints);
        int LvlUp(int newLvl);
    }
}
