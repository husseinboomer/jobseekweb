using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Paswword { get; set; }
        public DateTime LogInDate { get; set; }
        public DateTime? LogOutDate { get; set; }
    }
}
