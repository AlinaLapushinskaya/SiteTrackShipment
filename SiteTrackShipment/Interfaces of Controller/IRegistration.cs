using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteTrackShipment.Interfaces_of_Controller
{
    interface IRegistration
    {
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


                _context.Users.Add(new Users
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
