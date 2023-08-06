using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateOnly? BirthDay { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Status { get; set; }
        public string? Address { get; set; }
        public int? CertificationId { get; set; }
        public int? EducationId { get; set; }
        public int? CityId { get; set; }
        public byte[]? Image { get; set; }
        public int? YearsOfExpieriance { get; set; }

        public virtual Certification? Certification { get; set; }
        public virtual City? City { get; set; }
        public virtual Education? Education { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
