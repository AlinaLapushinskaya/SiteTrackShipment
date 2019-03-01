using System;
using System.Collections.Generic;

namespace Date
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string NameRole { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
