using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portals_Technoprolis_RPG.Database;
using Portals_Technoprolis_RPG.Models;
using System.Threading.Tasks;

namespace Portals_Technoprolis_RPG.Controllers
   {
        [ApiController]
        [Route("api/[controller]")]
        public class PlayersController : ControllerBase
        {

            private readonly PortalsDbContext _context;

            public PlayersController(PortalsDbContext context)
            {
                _context = context;
            }

            [AllowAnonymous]
            [HttpPost]
            public async Task<IActionResult> CreatePlayer([FromBody] Player player)
            {
                if (player == null)
                {
                    return BadRequest();
                }

                _context.Players.Add(player);
                await _context.SaveChangesAsync();
                //Cox note: demo temp-data-model decoupled from raw db model. :-)
                var playerDto = new PlayerDto
                {
                    ID = player.ID,
                    Name = player.Name,
                    Loot = player.Loot,
                    Xp = player.Xp,
                    Level = player.Level,
                    CurrentHealth = player.CurrentHealth,
                    MaxHealth = player.MaxHealth
                };

                return CreatedAtAction(nameof(GetPlayerById), new { id = player.ID }, playerDto);
            }

            [AllowAnonymous]
            [HttpGet("{id}")]
            public async Task<IActionResult> GetPlayerById(int id)
            {
                var player = await _context.Players.FindAsync(id);

                if (player == null)
                {
                    return NotFound();
                }

                return Ok(player);
            }
        }
   }
   