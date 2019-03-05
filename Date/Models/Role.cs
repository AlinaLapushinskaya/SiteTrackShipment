using System;
using System.Collections.Generic;

namespace Date.Models
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string NameRole { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
