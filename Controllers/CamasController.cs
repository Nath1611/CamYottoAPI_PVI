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
    public class CamasController : ControllerBase
    {
        private readonly CamYottoDBContext _context;

        public CamasController(CamYottoDBContext context)
        {
            _context = context;
        }

        // GET: api/Camas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cama>>> GetCamas()
        {
            return await _context.Camas.ToListAsync();
        }

        // GET: api/Camas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cama>> GetCama(int id)
        {
            var cama = await _context.Camas.FindAsync(id);

            if (cama == null)
            {
                return NotFound();
            }

            return cama;
        }

        // PUT: api/Camas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCama(int id, Cama cama)
        {
            if (id != cama.Idcama)
            {
                return BadRequest();
            }

            _context.Entry(cama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamaExists(id))
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

        // POST: api/Camas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cama>> PostCama(Cama cama)
        {
            _context.Camas.Add(cama);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CamaExists(cama.Idcama))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCama", new { id = cama.Idcama }, cama);
        }

        // DELETE: api/Camas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCama(int id)
        {
            var cama = await _context.Camas.FindAsync(id);
            if (cama == null)
            {
                return NotFound();
            }

            _context.Camas.Remove(cama);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CamaExists(int id)
        {
            return _context.Camas.Any(e => e.Idcama == id);
        }
    }
}
