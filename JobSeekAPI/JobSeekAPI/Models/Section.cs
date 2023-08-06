using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Section
    {
        public Section()
        {
            BranchSections = new HashSet<BranchSection>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<BranchSection> BranchSections { get; set; }
    }
}
