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
    public class MaquinariumsController : ControllerBase
    {
        private readonly CamYottoDBContext _context;

        public MaquinariumsController(CamYottoDBContext context)
        {
            _context = context;
        }

        // GET: api/Maquinariums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maquinarium>>> GetMaquinaria()
        {
            return await _context.Maquinaria.ToListAsync();
        }

        // GET: api/Maquinariums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maquinarium>> GetMaquinarium(int id)
        {
            var maquinarium = await _context.Maquinaria.FindAsync(id);

            if (maquinarium == null)
            {
                return NotFound();
            }

            return maquinarium;
        }

        // PUT: api/Maquinariums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaquinarium(int id, Maquinarium maquinarium)
        {
            if (id != maquinarium.Idmaquinaria)
            {
                return BadRequest();
            }

            _context.Entry(maquinarium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaquinariumExists(id))
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

        // POST: api/Maquinariums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maquinarium>> PostMaquinarium(Maquinarium maquinarium)
        {
            _context.Maquinaria.Add(maquinarium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaquinarium", new { id = maquinarium.Idmaquinaria }, maquinarium);
        }

        // DELETE: api/Maquinariums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaquinarium(int id)
        {
            var maquinarium = await _context.Maquinaria.FindAsync(id);
            if (maquinarium == null)
            {
                return NotFound();
            }

            _context.Maquinaria.Remove(maquinarium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaquinariumExists(int id)
        {
            return _context.Maquinaria.Any(e => e.Idmaquinaria == id);
        }
    }
}
