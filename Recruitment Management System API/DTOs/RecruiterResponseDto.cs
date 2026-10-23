namespace Recruitment_Management_System_API.DTOs
{
    public class RecruiterResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}