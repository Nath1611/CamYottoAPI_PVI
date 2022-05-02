using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CamYottoAPI.Models;

namespace CamYottoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChalecoesController : ControllerBase
    {
        private readonly CamYottoDBContext _context;

        public ChalecoesController(CamYottoDBContext context)
        {
            _context = context;
        }

        // GET: api/Chalecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chaleco>>> GetChalecos()
        {
            return await _context.Chalecos.ToListAsync();
        }

        // GET: api/Chalecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chaleco>> GetChaleco(int id)
        {
            var chaleco = await _context.Chalecos.FindAsync(id);

            if (chaleco == null)
            {
                return NotFound();
            }

            return chaleco;
        }

        // PUT: api/Chalecoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChaleco(int id, Chaleco chaleco)
        {
            if (id != chaleco.Column)
            {
                return BadRequest();
            }

            _context.Entry(chaleco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChalecoExists(id))
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

        // POST: api/Chalecoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chaleco>> PostChaleco(Chaleco chaleco)
        {
            _context.Chalecos.Add(chaleco);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChalecoExists(chaleco.Column))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChaleco", new { id = chaleco.Column }, chaleco);
        }

        // DELETE: api/Chalecoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChaleco(int id)
        {
            var chaleco = await _context.Chalecos.FindAsync(id);
            if (chaleco == null)
            {
                return NotFound();
            }

            _context.Chalecos.Remove(chaleco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChalecoExists(int id)
        {
            return _context.Chalecos.Any(e => e.Column == id);
        }
    }
}
