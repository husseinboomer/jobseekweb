using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public int? DocumentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public double? RateGrade { get; set; }
        public string? Notes { get; set; }
        public int Acceptance { get; set; }

        public virtual Documnet? Document { get; set; }
        public virtual Job Job { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
