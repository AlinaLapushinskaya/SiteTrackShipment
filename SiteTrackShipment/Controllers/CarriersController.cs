using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Date;
using Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteTrackShipment;

namespace SiteTrackShipment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private readonly DeliveryContext _context;

        public CarriersController(DeliveryContext context)
        {
            _context = context;
        }

        // GET: api/Carriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrier>>> GetCarrier()
        {
            return await _context.Carrier.ToListAsync();
        }

        // GET: api/Carriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrier>> GetCarrier(int id)
        {
            var carrier = await _context.Carrier.FindAsync(id);

            if (carrier == null)
            {
                return NotFound();
            }

            return carrier;
        }

        // PUT: api/Carriers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrier(int id, Carrier carrier)
        {
            if (id != carrier.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrierExists(id))
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

        // POST: api/Carriers
        [HttpPost]
        public async Task<ActionResult<Carrier>> PostCarrier(Carrier carrier)
        {
            _context.Carrier.Add(carrier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrier", new { id = carrier.Id }, carrier);
        }

        // DELETE: api/Carriers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carrier>> DeleteCarrier(int id)
        {
            var carrier = await _context.Carrier.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }

            _context.Carrier.Remove(carrier);
            await _context.SaveChangesAsync();

            return carrier;
        }

        private bool CarrierExists(int id)
        {
            return _context.Carrier.Any(e => e.Id == id);
        }
    }
}

