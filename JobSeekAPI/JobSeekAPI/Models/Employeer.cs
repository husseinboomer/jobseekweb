using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Employeer
    {
        public Employeer()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ulong? State { get; set; }
        public byte[]? Image { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
