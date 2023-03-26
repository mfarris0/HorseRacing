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
    public class RaceDayController : Controller
    {
        private readonly HorseRacingDbContext _context;

        public RaceDayController(HorseRacingDbContext context)
        {
            _context = context;
        }

        // GET: RaceDay
        public async Task<IActionResult> Index()
        {
            var raceDays = _context.RaceDays.Include(r => r.Track).OrderBy(r=>r.Track.Name);
            return View(await raceDays.ToListAsync());
        }

        // GET: RaceDay/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceDay = await _context.RaceDays
                .Include(r => r.Track)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceDay == null)
            {
                return NotFound();
            }

            return View(raceDay);
        }

        // GET: RaceDay/Create
        public IActionResult Create()
        {
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id");
            return View();
        }

        // POST: RaceDay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RaceDate,TrackCode,TrackId,RaceDateString,RaceDayIdString")] RaceDay raceDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raceDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id", raceDay.TrackId);
            return View(raceDay);
        }

        // GET: RaceDay/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceDay = await _context.RaceDays.FindAsync(id);
            if (raceDay == null)
            {
                return NotFound();
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id", raceDay.TrackId);
            return View(raceDay);
        }

        // POST: RaceDay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RaceDate,TrackCode,TrackId,RaceDateString,RaceDayIdString")] RaceDay raceDay)
        {
            if (id != raceDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raceDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceDayExists(raceDay.Id))
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
            ViewData["TrackId"] = new SelectList(_context.Tracks, "Id", "Id", raceDay.TrackId);
            return View(raceDay);
        }

        // GET: RaceDay/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceDay = await _context.RaceDays
                .Include(r => r.Track)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raceDay == null)
            {
                return NotFound();
            }

            return View(raceDay);
        }

        // POST: RaceDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raceDay = await _context.RaceDays.FindAsync(id);
            _context.RaceDays.Remove(raceDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceDayExists(int id)
        {
            return _context.RaceDays.Any(e => e.Id == id);
        }
    }
}
