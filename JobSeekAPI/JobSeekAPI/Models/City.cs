using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class City
    {
        public City()
        {
            Branches = new HashSet<Branch>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
