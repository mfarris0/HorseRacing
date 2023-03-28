using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HorseRacing.Data;
using HorseRacing.Domain;

namespace HorseRacing.MVC.Controllers
{
    public class RawRaceHorseController : Controller
    {
        private readonly HorseRacingDbContext _context;

        public RawRaceHorseController(HorseRacingDbContext context)
        {
            _context = context;
        }

        // GET: RawRaceHorse
        public async Task<IActionResult> Index(string id)
        {
            var raceHorses = _context.RawRaceHorses.Where(r=>r.RawRaceId == id)
                                                             .Include(r => r.RawRace);

            //var rawRace = _context.RawRaces.Where(r => r.Id == id)
            //                               .Include(r => r.RaceHorseList);
            
            return View(await raceHorses.ToListAsync());
        }

        // GET: RawRaceHorse/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawRaceHorse = await _context.RawRaceHorses
                .Include(r => r.RawRace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rawRaceHorse == null)
            {
                return NotFound();
            }

            return View(rawRaceHorse);
        }

        // GET: RawRaceHorse/Create
        public IActionResult Create()
        {
            ViewData["RawRaceId"] = new SelectList(_context.RawRaces, "Id", "Id");
            return View();
        }

        // POST: RawRaceHorse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostPosition,HorseName,MorningLineOdds,JockeyName,WeightCarried,TrainerName,RawRaceId")] RawRaceHorse rawRaceHorse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rawRaceHorse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RawRaceId"] = new SelectList(_context.RawRaces, "Id", "Id", rawRaceHorse.RawRaceId);
            return View(rawRaceHorse);
        }

        // GET: RawRaceHorse/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawRaceHorse = await _context.RawRaceHorses.FindAsync(id);
            if (rawRaceHorse == null)
            {
                return NotFound();
            }
            ViewData["RawRaceId"] = new SelectList(_context.RawRaces, "Id", "Id", rawRaceHorse.RawRaceId);
            return View(rawRaceHorse);
        }

        // POST: RawRaceHorse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PostPosition,HorseName,MorningLineOdds,JockeyName,WeightCarried,TrainerName,RawRaceId")] RawRaceHorse rawRaceHorse)
        {
            if (id != rawRaceHorse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rawRaceHorse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RawRaceHorseExists(rawRaceHorse.Id))
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
            ViewData["RawRaceId"] = new SelectList(_context.RawRaces, "Id", "Id", rawRaceHorse.RawRaceId);
            return View(rawRaceHorse);
        }

        // GET: RawRaceHorse/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rawRaceHorse = await _context.RawRaceHorses
                .Include(r => r.RawRace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rawRaceHorse == null)
            {
                return NotFound();
            }

            return View(rawRaceHorse);
        }

        // POST: RawRaceHorse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rawRaceHorse = await _context.RawRaceHorses.FindAsync(id);
            _context.RawRaceHorses.Remove(rawRaceHorse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RawRaceHorseExists(string id)
        {
            return _context.RawRaceHorses.Any(e => e.Id == id);
        }
    }
}
