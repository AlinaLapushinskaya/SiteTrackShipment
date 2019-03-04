using System;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Date;
using Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteTrackShipment.ViewModels;

namespace SiteTrackShipment.Controllers
{
    [Route("api/reg")]
    [ApiController]
    public class RegistrationController : Controller, IRegistration
    {
        private readonly DeliveryContext _context;

        public RegistrationController(DeliveryContext context)
        {
            _context = context;
        }

        [HttpPost, Route("reg")]
        public IActionResult Registration([FromBody]RegistrationModel user);
        
    }
}
