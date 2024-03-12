using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet_API.Data;
using Projet_API.Models;

namespace Projet_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameConsolesController : ControllerBase
    {
        private readonly Projet_APIContext _context;

        public GameConsolesController(Projet_APIContext context)
        {
            _context = context;
        }

        // GET: api/GameConsoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameConsole>>> GetGameConsole()
        {
            return await _context.GameConsole.ToListAsync();
        }

        // GET: api/GameConsoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameConsole>> GetGameConsole(int id)
        {
            var gameConsole = await _context.GameConsole.FindAsync(id);

            if (gameConsole == null)
            {
                return NotFound();
            }

            return gameConsole;
        }

        // PUT: api/GameConsoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameConsole(int id, GameConsole gameConsole)
        {
            if (id != gameConsole.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameConsole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameConsoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GameConsoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameConsole>> PostGameConsole(GameConsole gameConsole)
        {
            _context.GameConsole.Add(gameConsole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameConsole", new { id = gameConsole.Id }, gameConsole);
        }

        // DELETE: api/GameConsoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameConsole(int id)
        {
            var gameConsole = await _context.GameConsole.FindAsync(id);
            if (gameConsole == null)
            {
                return NotFound();
            }

            _context.GameConsole.Remove(gameConsole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameConsoleExists(int id)
        {
            return _context.GameConsole.Any(e => e.Id == id);
        }
    }
}
