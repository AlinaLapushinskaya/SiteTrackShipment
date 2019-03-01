using System;
using System.Collections.Generic;

namespace SiteTrackShipment
{
    public partial class Carrier
    {
        public Carrier()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public bool? SubscriptionStatus { get; set; }
        public bool? ActiveStatus { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string Logotip { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
