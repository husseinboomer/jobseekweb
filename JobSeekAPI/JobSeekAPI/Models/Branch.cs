using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Branch
    {
        public Branch()
        {
            BranchSections = new HashSet<BranchSection>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public int CompanyId { get; set; }
        public string? Address { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<BranchSection> BranchSections { get; set; }
    }
}
