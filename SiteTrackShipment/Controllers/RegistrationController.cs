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
using Repository.Repository;
using Date.Models;
using SiteTrackShipment.Interfaces;

namespace SiteTrackShipment.Controllers
{
    [Route("api/reg")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly DeliveryContext _context;
       
        public RegistrationController(DeliveryContext context)
        {
            _context = context;
        }

        [HttpPost, Route("reg")]
        public IActionResult Registration([FromBody]RegistrationModel user)
        {

            var person = _context.Users.SingleOrDefault(u => u.Email == user.Email);

            if (person != null)
            {
                return BadRequest("Identity detected");
            }

            if (person == null)
            {

                //hash
                byte[] salt = new byte[128 / 8];
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: user.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8));


                _context.Users.Add(new User
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Password = hashed,
                    IdRole = 2,
                    IdCarrier = null,
                    IdCompany = null
                });

                _context.SaveChanges();
                return Ok(user.Email + " " + "successfully");

            }
            return Ok("");
        }
    }
}
