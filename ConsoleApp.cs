using Portals_Technoprolis_RPG.Database;
using Portals_Technoprolis_RPG.GameEngine;

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

