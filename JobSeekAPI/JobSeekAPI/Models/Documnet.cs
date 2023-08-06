using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Documnet
    {
        public Documnet()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? IsCv { get; set; }
        public byte[]? IsImage { get; set; }
        public string? ExtraInfo { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
