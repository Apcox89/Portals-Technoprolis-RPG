using Microsoft.EntityFrameworkCore;
using Portals_Technoprolis_RPG.Models;

namespace Portals_Technoprolis_RPG.Database
{
    public interface IPortalsDbContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Npc> Npcs { get; set; }
        DbSet<Skill> Skills { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
