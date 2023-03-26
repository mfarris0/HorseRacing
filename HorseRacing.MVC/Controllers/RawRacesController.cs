using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HorseRacing.Data;
using HorseRacing.Domain;
using HorseRacing.MVC.ViewModels;

namespace HorseRacing.MVC.Controllers
{
    public class RawRacesController : Controller
    {
        private readonly HorseRacingDbContext _context;

        public RawRacesController(HorseRacingDbContext context)
        {
            _context = context;
        }

        // GET: RawRaces
        // 20230326: Added id arg to signature; we only need the races for a given RaceDay
        public async Task<IActionResult> Index(string id)
        {
            var rawRaces = _context.RawRaces.Where(r => r.RaceDayIdString == id)
                                            .Include(r => r.Distance)
                                            .Include(r => r.RaceDay)
                                            .Include(r => r.RaceSurface) 
                                            .Include(r => r.RaceType);
            
            var raceDayViewModel = new RaceDayViewModel(rawRaces);
            raceDayViewModel.RaceDay = _context.RaceDays.Where(r => r.RaceDayIdString == id)
                                                        .Include(r=>r.Track)  
                                                        .FirstOrDefault();

            return View(raceDayViewModel);
            //return View(await rawRaces.ToListAsync());
        }

        // GET: RawRaces/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawRace = await _context.RawRaces
                .Include(r => r.Distance)
                .Include(r => r.RaceDay)
                .Include(r => r.RaceSurface)
                .Include(r => r.RaceType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rawRace == null)
            {
                return NotFound();
            }

            return View(rawRace);
        }

        // GET: RawRaces/Create
        public IActionResult Create()
        {
            ViewData["DistanceId"] = new SelectList(_context.Distances, "Id", "Id");
            ViewData["RaceDayId"] = new SelectList(_context.RaceDays, "Id", "RaceDateString");
            ViewData["RaceSurfaceId"] = new SelectList(_context.RaceSurfaces, "Id", "Id");
            ViewData["RaceTypeId"] = new SelectList(_context.RaceTypes, "Id", "Id");
            return View();
        }

        // POST: RawRaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RaceNumber,Purse,Classification,Conditions,RaceTypeId,DistanceId,RaceSurfaceId,RaceDayId,RaceDayIdString")] RawRace rawRace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rawRace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistanceId"] = new SelectList(_context.Distances, "Id", "Id", rawRace.DistanceId);
            ViewData["RaceDayId"] = new SelectList(_context.RaceDays, "Id", "RaceDateString", rawRace.RaceDayId);
            ViewData["RaceSurfaceId"] = new SelectList(_context.RaceSurfaces, "Id", "Id", rawRace.RaceSurfaceId);
            ViewData["RaceTypeId"] = new SelectList(_context.RaceTypes, "Id", "Id", rawRace.RaceTypeId);
            return View(rawRace);
        }

        // GET: RawRaces/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawRace = await _context.RawRaces.FindAsync(id);
            if (rawRace == null)
            {
                return NotFound();
            }
            ViewData["DistanceId"] = new SelectList(_context.Distances, "Id", "Id", rawRace.DistanceId);
            ViewData["RaceDayId"] = new SelectList(_context.RaceDays, "Id", "RaceDateString", rawRace.RaceDayId);
            ViewData["RaceSurfaceId"] = new SelectList(_context.RaceSurfaces, "Id", "Id", rawRace.RaceSurfaceId);
            ViewData["RaceTypeId"] = new SelectList(_context.RaceTypes, "Id", "Id", rawRace.RaceTypeId);
            return View(rawRace);
        }

        // POST: RawRaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,RaceNumber,Purse,Classification,Conditions,RaceTypeId,DistanceId,RaceSurfaceId,RaceDayId,RaceDayIdString")] RawRace rawRace)
        {
            if (id != rawRace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rawRace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RawRaceExists(rawRace.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistanceId"] = new SelectList(_context.Distances, "Id", "Id", rawRace.DistanceId);
            ViewData["RaceDayId"] = new SelectList(_context.RaceDays, "Id", "RaceDateString", rawRace.RaceDayId);
            ViewData["RaceSurfaceId"] = new SelectList(_context.RaceSurfaces, "Id", "Id", rawRace.RaceSurfaceId);
            ViewData["RaceTypeId"] = new SelectList(_context.RaceTypes, "Id", "Id", rawRace.RaceTypeId);
            return View(rawRace);
        }

        // GET: RawRaces/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rawRace = await _context.RawRaces
        //        .Include(r => r.Distance)
        //        .Include(r => r.RaceDay)
        //        .Include(r => r.RaceSurface)
        //        .Include(r => r.RaceType)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (rawRace == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rawRace);
        //}

        // POST: RawRaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var rawRace = await _context.RawRaces.FindAsync(id);
        //    _context.RawRaces.Remove(rawRace);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool RawRaceExists(string id)
        {
            return _context.RawRaces.Any(e => e.Id == id);
        }
    }
}
