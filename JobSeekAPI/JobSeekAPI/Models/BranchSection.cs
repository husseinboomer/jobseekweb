using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class BranchSection
    {
        public BranchSection()
        {
            Jobs = new HashSet<Job>();
        }

        public int Id { get; set; }
        public int BranchId { get; set; }
        public int SectionId { get; set; }

        public virtual Branch Branch { get; set; } = null!;
        public virtual Section Section { get; set; } = null!;
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
