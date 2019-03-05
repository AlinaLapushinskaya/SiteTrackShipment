using System;
using System.Collections.Generic;
using System.Linq;
using Date.Models;
using Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteTrackShipment;
using Repository.Repository;

namespace SiteTrackShipment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : IUsers
    {
        private readonly DeliveryContext _context;


        public UsersController(DeliveryContext context)
        {
            _context = context;
        }

        [HttpPost, Route("login")]
        public User Users(User user)
        {
            var person = _context.Users.SingleOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            return person;
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        private ActionResult<User> NotFound()
        {
            throw new NotImplementedException();
        }


        // GET: api/Users/5
        //[HttpGet("{address}")]
        //public async Task<ActionResult<AddressBook>> GetAddress(int IdUser)
        //{
        //    var users = await _context.AddressBook.FindAsync(IdUser);

        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return users;
        //}


        [Route("/api/protected")]
        [Authorize]
        private string Protected()
        {
            return "Only if you have a valid token!";
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        private ActionResult<User> CreatedAtAction(string v, object p, User users)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NotFound();
        }


        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        string IUsers.Protected()
        {
            throw new NotImplementedException();
        }

        bool IUsers.UsersExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
