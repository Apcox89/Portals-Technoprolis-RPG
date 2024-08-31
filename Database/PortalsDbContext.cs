using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Portals_Technoprolis_RPG.Models;

namespace Portals_Technoprolis_RPG.Database;

public partial class PortalsDbContext : DbContext
{
    public PortalsDbContext(DbContextOptions<PortalsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Npc> Npcs { get; set; }
    public DbSet<Skill> Skills { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Character and Player
        modelBuilder.Entity<Character>()
            .ToTable("Character")
            .HasDiscriminator<string>("CharacterType")
            .HasValue<Player>("Player")
            .HasValue<Npc>("Npc");

        // Configure any additional mappings or constraints if necessary

        base.OnModelCreating(modelBuilder);
    }
}
