   using Microsoft.AspNetCore.Mvc;
   using Portals_Technoprolis_RPG.Models;
   using System.Collections.Generic;

   namespace Portals_Technoprolis_RPG.Controllers
   {
       [ApiController]
       [Route("api/[controller]")]
       public class NpcsController : ControllerBase
       {
           private static List<Npc> npcs = new List<Npc>();

           [HttpGet]
           public ActionResult<IEnumerable<Npc>> GetNpcs()
           {
               return Ok(npcs);
           }

           [HttpPost]
           public ActionResult<Npc> CreateNpc(Npc npc)
           {
               npcs.Add(npc);
               return CreatedAtAction(nameof(GetNpcs), new { id = npc.ID }, npc);
           }
       }
   }
   