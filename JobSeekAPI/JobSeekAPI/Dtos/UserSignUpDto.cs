namespace JobSeekAPI.Dtos
{
    public class UserSignUpDto
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? CityId { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public int? CertificationId { get; set; }
    }
}
