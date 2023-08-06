using System;
using System.Collections.Generic;

namespace JobSeekAPI.Models
{
    public partial class Savedjob
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JobId { get; set; }
    }
}
