using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorseRacing.Data;
using HorseRacing.Domain;

namespace HorseRacing.MVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly HorseRacingDbContext _context;

        public TrackController(HorseRacingDbContext context)
        {
            _context = context;
        }

        // GET: api/Track
        [HttpGet]
        public async Task<List<Track>> GetTracks()
        {
            var tracks = await _context.Tracks.ToListAsync();

            return tracks;
        }

        // GET: api/Track/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(string id)
        {
            var track = await _context.Tracks.FindAsync(id);

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }


        private bool TrackExists(string id)
        {
            return _context.Tracks.Any(e => e.Id == id);
        }
    }
}
