using Date.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteTrackShipment.Controllers
{
   public interface ICarriers
    {
         Task<ActionResult<Carrier>> GetCarrier(int id);
         Task<ActionResult<Carrier>> PostCarrier(Carrier carrier);
         Task<ActionResult<Carrier>> DeleteCarrier(int id);
        bool CarrierExists(int id);
        Task<ActionResult<Carrier>> GetCarrier(string ActiveStatus);
    }
}
