﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteTrackShipment.ViewModels
{
    public class RegistrationModel
    {
        [Required (ErrorMessage = "Email is required.")]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        //[Authorize]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required (ErrorMessage = "PasswordConfirm is required.")]
        public string ConfirmPassword { get; set; }


    }
}
