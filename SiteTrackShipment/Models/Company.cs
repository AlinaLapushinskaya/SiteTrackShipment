using System;
using System.Collections.Generic;

namespace SiteTrackShipment
{
    public partial class Company
    {
        public Company()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
