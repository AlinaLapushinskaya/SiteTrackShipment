using Date.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteTrackShipment.Controllers
{
    public interface IUsers
    {
        
        Task<ActionResult<User>> GetUsers(int id);
        string Protected();
        Task<ActionResult<User>> PostUsers(User users);
         Task<ActionResult<User>> DeleteUsers(int id);
        bool UsersExists(int id);
         
    }
}
