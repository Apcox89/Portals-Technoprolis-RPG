using Microsoft.EntityFrameworkCore;
using Portals_Technoprolis_RPG.Models;

namespace Portals_Technoprolis_RPG.Database;

public partial class PortalsDbContext : DbContext, IPortalsDbContext
{
    public PortalsDbContext(DbContextOptions<PortalsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Npc> Npcs { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    //Polymorphism ex: 
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Character and Player -- Cox note: decouple/decompose player/npc
        modelBuilder.Entity<Character>()
            .ToTable("Character")
            .HasDiscriminator<string>("CharacterType")
            .HasValue<Player>("Player")
            .HasValue<Npc>("Npc");

        // Configure any additional mappings or constraints if necessary
        modelBuilder.Entity<Quest>()
                .HasKey(q => q.ID);

        // Configure Achievement entity
        modelBuilder.Entity<Achievement>()
            .HasKey(a => a.ID);

        // Define relationship: A Quest has many Achievements
        modelBuilder.Entity<Quest>()
            .HasMany(q => q.AchievementCollection)
            .WithOne(a => a.Quest)
            .HasForeignKey(a => a.QuestID);

        base.OnModelCreating(modelBuilder);
    }
}
