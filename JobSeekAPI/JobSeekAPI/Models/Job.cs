using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Job
    {
        public Job()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int? YearsOfExpieriance { get; set; }
        public int? AgeRequired { get; set; }
        public string? GenderRequired { get; set; }
        public decimal Salary { get; set; }
        public string? JobType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CertificationId { get; set; }
        public int? EducationId { get; set; }
        public int? EmployeerId { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public int? BranchSectionId { get; set; }
        public byte[]? Image { get; set; }
        public string Title { get; set; } = null!;
        public int PersonsNumRequired { get; set; }

        public virtual BranchSection? BranchSection { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Certification? Certification { get; set; }
        public virtual Education? Education { get; set; }
        public virtual Employeer? Employeer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
