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

                return CreatedAtAction(nameof(GetPlayerById), new { id = player.ID }, player);
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
   