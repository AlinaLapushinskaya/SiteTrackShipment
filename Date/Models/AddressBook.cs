using System;
using System.Collections.Generic;

namespace Date.Models
{
    public class AddressBook
    {
        public int Id { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
