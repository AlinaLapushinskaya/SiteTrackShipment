using System;
using System.Collections.Generic;

namespace Date.Models
{
    public class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
