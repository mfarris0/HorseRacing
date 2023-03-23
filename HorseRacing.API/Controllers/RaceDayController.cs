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
    public class RaceDayController : ControllerBase
    {
        private readonly HorseRacingDbContext _context;

        public RaceDayController(HorseRacingDbContext context)
        {
            _context = context;
        }

        // GET: api/RaceDay
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceDay>>> GetRaceDays()
        {
            return await _context.RaceDays.ToListAsync();
        }

        // GET: api/RaceDay/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceDay>> GetRaceDay(int id)
        {
            var raceDay = await _context.RaceDays.FindAsync(id);

            if (raceDay == null)
            {
                return NotFound();
            }

            return raceDay;
        }

        // PUT: api/RaceDay/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceDay(int id, RaceDay raceDay)
        {
            if (id != raceDay.Id)
            {
                return BadRequest();
            }

            _context.Entry(raceDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceDayExists(id))
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

        // POST: api/RaceDay
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RaceDay>> PostRaceDay(RaceDay raceDay)
        {
            _context.RaceDays.Add(raceDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRaceDay), new { id = raceDay.Id }, raceDay);
        }

        // DELETE: api/RaceDay/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRaceDay(int id)
        {
            var raceDay = await _context.RaceDays.FindAsync(id);
            if (raceDay == null)
            {
                return NotFound();
            }

            _context.RaceDays.Remove(raceDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceDayExists(int id)
        {
            return _context.RaceDays.Any(e => e.Id == id);
        }
    }
}
