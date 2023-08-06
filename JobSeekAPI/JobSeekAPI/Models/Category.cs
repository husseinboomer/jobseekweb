using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
