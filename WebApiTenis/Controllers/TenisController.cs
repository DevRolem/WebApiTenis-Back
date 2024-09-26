using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTenis.Context;
using WebApiTenis.Models;

namespace WebApiTenis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TenisController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenis>>> Gettenis()
        {
            return await _context.tenis.ToListAsync();
        }

    
        [HttpGet("{id}")]
        public async Task<ActionResult<Tenis>> GetTenis(int id)
        {
            var tenis = await _context.tenis.FindAsync(id);

            if (tenis == null)
            {
                return NotFound();
            }

            return tenis;
        }

   
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenis(int id, Tenis tenis)
        {
            if (id != tenis.Id)
            {
                return BadRequest();
            }

            _context.Entry(tenis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenisExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<Tenis>> PostTenis(Tenis tenis)
        {
            _context.tenis.Add(tenis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTenis", new { id = tenis.Id }, tenis);
        }

        // DELETE: api/Tenis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenis(int id)
        {
            var tenis = await _context.tenis.FindAsync(id);
            if (tenis == null)
            {
                return NotFound();
            }

            _context.tenis.Remove(tenis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TenisExists(int id)
        {
            return _context.tenis.Any(e => e.Id == id);
        }
    }
}
