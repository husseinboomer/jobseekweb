using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Education
    {
        public Education()
        {
            Jobs = new HashSet<Job>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
