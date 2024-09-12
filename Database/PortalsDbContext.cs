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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Player entity
        modelBuilder.Entity<Player>()
            .ToTable("Players")
            .HasKey(p => p.ID);

        // Configure Npc entity
        modelBuilder.Entity<Npc>()
            .ToTable("Npcs")
            .HasKey(n => n.ID);

        // Configure Skill entity
        modelBuilder.Entity<Skill>()
            .ToTable("Skills")
            .HasKey(s => s.SkillID);

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
