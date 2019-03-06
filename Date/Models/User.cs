using System;
using System.Collections.Generic;

namespace Date.Models
{
    public class User
    {
        public User()
        {
            AddressBook = new HashSet<AddressBook>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool? SubscriptionStatus { get; set; }
        public int? IdRole { get; set; }
        public int? IdCarrier { get; set; }
        public int? IdCompany { get; set; }

        public virtual Carrier IdCarrierNavigation { get; set; }
        public virtual Company IdCompanyNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<AddressBook> AddressBook { get; set; }
        public string Token { get; set; }
    }
}
