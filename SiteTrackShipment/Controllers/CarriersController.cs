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
using Repository.Repository;
using Date.Models;

namespace SiteTrackShipment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class CarriersController : ICarriers


    {
        private readonly DeliveryContext _context;

        public CarriersController(DeliveryContext context)
        {
            _context = context;
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

        private ActionResult<Carrier> NotFound()
        {
            throw new NotImplementedException();
        }

        // GET: api/Carriers/1
        //[HttpGet("{ActiveStatus}")]
        //public async Task<ActionResult<Carrier>> GetCarrier(string ActiveStatus)
        //{
        //    var status = await _context.Carrier.FindAsync(ActiveStatus);

        //    if (status = false)
        //    {
        //        return NotFound();
        //    }

        //    return status;
        //}

        // POST: api/Carriers
        [HttpPost]
        public async Task<ActionResult<Carrier>> PostCarrier(Carrier carrier)
        {
            _context.Carrier.Add(carrier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrier", new { id = carrier.Id }, carrier);
        }

        private ActionResult<Carrier> CreatedAtAction(string v, object p, Carrier carrier)
        {
            throw new NotImplementedException();
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

            return NotFound();
        }

        private bool CarrierExists(int id)
        {
            return _context.Carrier.Any(e => e.Id == id);
        }

        bool ICarriers.CarrierExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Carrier>> GetCarrier(string ActiveStatus)
        {
            throw new NotImplementedException();
        }
    }
}

