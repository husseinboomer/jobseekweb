namespace JobSeekAPI.Dtos
{
    public class JobDto
    {
        public int? YearsOfExpieriance { get; set; }
        public int? AgeRequired { get; set; }
        public string? GenderRequired { get; set; }
        public decimal Salary { get; set; }
        public string? JobType { get; set; }
        public int? CertificationId { get; set; }
        public int? EmployeerId { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public string Title { get; set; } = null!;
        public int PersonsNumRequired { get; set; }

    }
}
