using Microsoft.AspNetCore.Mvc;
using Repository.Repository;
using SiteTrackShipment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteTrackShipment.Controllers
{
    public interface IRegistration
    {
        
        IActionResult Registration([FromBody]RegistrationModel user);

    }
}
