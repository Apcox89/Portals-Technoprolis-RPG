using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portals_Technoprolis_RPG.Database;
using Portals_Technoprolis_RPG.GameEngine;
using System.Threading.Tasks;

namespace Portals_Technoprolis_RPG
{
    public class ConsoleApp
    {
        private readonly PortalsDbContext _dbContext;

        public ConsoleApp(PortalsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Run()
        {
            var game = new Game(_dbContext);
            game.Start();
        }
    }
}

