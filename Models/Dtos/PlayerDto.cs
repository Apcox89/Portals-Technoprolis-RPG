namespace Portals_Technoprolis_RPG.Models
{
    public class PlayerDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Loot { get; set; }
        public int Xp { get; set; }
        public int Level { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsDead => CurrentHealth <= 0;
    }
}
