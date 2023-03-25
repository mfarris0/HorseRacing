using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorseRacing.Data;
using HorseRacing.Domain;
using HorseRacing.Service;

namespace HorseRacing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceTypeController : ControllerBase
    {
        private readonly IRaceTypeService _raceTypeService;

        public RaceTypeController(IRaceTypeService raceTypeService)
        {
            this._raceTypeService = raceTypeService;
        }


        // GET: api/RaceType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceType>>> GetRaceTypes()
        {
            return await _raceTypeService.GetAll();
        }

        //// GET: api/RaceType/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<RaceType>> GetRaceType(string id)
        //{
        //    var raceType = await _raceTypeService.RaceTypes.FindAsync(id);

        //    if (raceType == null)
        //    {
        //        return NotFound();
        //    }

        //    return raceType;
        //}

        //// PUT: api/RaceType/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRaceType(string id, RaceType raceType)
        //{
        //    if (id != raceType.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _raceTypeService.Entry(raceType).State = EntityState.Modified;

        //    try
        //    {
        //        await _raceTypeService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RaceTypeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/RaceType
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<RaceType>> PostRaceType(RaceType raceType)
        //{
        //    _raceTypeService.RaceTypes.Add(raceType);
        //    try
        //    {
        //        await _raceTypeService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (RaceTypeExists(raceType.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction(nameof(GetRaceType), new { id = raceType.Id }, raceType);
        //}

        ////DELETE: api/RaceType/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRaceType(string id)
        //{
        //    var raceType = await _raceTypeService.RaceTypes.FindAsync(id);
        //    if (raceType == null)
        //    {
        //        return NotFound();
        //    }

        //    _raceTypeService.RaceTypes.Remove(raceType);
        //    await _raceTypeService.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool RaceTypeExists(string id)
        //{
        //    return _raceTypeService.RaceTypes.Any(e => e.Id == id);
        //}
    }
}
