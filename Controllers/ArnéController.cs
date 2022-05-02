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
    public class ArnéController : ControllerBase
    {
        private readonly CamYottoDBContext _context;

        public ArnéController(CamYottoDBContext context)
        {
            _context = context;
        }

        // GET: api/Arné
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arné>>> GetArnés()
        {
            return await _context.Arnés.ToListAsync();
        }

        // GET: api/Arné/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Arné>> GetArné(string id)
        {
            var arné = await _context.Arnés.FindAsync(id);

            if (arné == null)
            {
                return NotFound();
            }

            return arné;
        }

        // PUT: api/Arné/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArné(string id, Arné arné)
        {
            if (id != arné.Idarnes)
            {
                return BadRequest();
            }

            _context.Entry(arné).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArnéExists(id))
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

        // POST: api/Arné
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Arné>> PostArné(Arné arné)
        {
            _context.Arnés.Add(arné);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ArnéExists(arné.Idarnes))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetArné", new { id = arné.Idarnes }, arné);
        }

        // DELETE: api/Arné/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArné(string id)
        {
            var arné = await _context.Arnés.FindAsync(id);
            if (arné == null)
            {
                return NotFound();
            }

            _context.Arnés.Remove(arné);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArnéExists(string id)
        {
            return _context.Arnés.Any(e => e.Idarnes == id);
        }
    }
}
