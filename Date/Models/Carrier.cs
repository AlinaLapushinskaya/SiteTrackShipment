using System;
using System.Collections.Generic;

namespace Date.Models
{
    public class Carrier
    {
        public Carrier()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public bool? SubscriptionStatus { get; set; }
        public bool? ActiveStatus { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string Logotip { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public static implicit operator Carrier(bool v)
        {
            throw new NotImplementedException();
        }

    
    }
}
