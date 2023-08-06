using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Company
    {
        public Company()
        {
            Branches = new HashSet<Branch>();
            Employeers = new HashSet<Employeer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? WebSite { get; set; }
        public string? Email { get; set; }
        public int? PassCode { get; set; }
        public string? Details { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Employeer> Employeers { get; set; }
    }
}
