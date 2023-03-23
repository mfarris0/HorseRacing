using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorseRacing.Data;
using HorseRacing.Domain;

namespace HorseRacing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceTypeController : ControllerBase
    {
        private readonly HorseRacingDbContext _context;

        public RaceTypeController(HorseRacingDbContext context)
        {
            _context = context;
        }

        // GET: api/RaceType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceType>>> GetRaceTypes()
        {
            return await _context.RaceTypes.ToListAsync();
        }

        // GET: api/RaceType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceType>> GetRaceType(string id)
        {
            var raceType = await _context.RaceTypes.FindAsync(id);

            if (raceType == null)
            {
                return NotFound();
            }

            return raceType;
        }

        // PUT: api/RaceType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceType(string id, RaceType raceType)
        {
            if (id != raceType.Id)
            {
                return BadRequest();
            }

            _context.Entry(raceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceTypeExists(id))
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

        // POST: api/RaceType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RaceType>> PostRaceType(RaceType raceType)
        {
            _context.RaceTypes.Add(raceType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RaceTypeExists(raceType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetRaceType), new { id = raceType.Id }, raceType);
        }

        // DELETE: api/RaceType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceType(string id)
        {
            var raceType = await _context.RaceTypes.FindAsync(id);
            if (raceType == null)
            {
                return NotFound();
            }

            _context.RaceTypes.Remove(raceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceTypeExists(string id)
        {
            return _context.RaceTypes.Any(e => e.Id == id);
        }
    }
}
