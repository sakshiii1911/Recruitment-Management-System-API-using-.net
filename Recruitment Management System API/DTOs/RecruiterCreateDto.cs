using System.ComponentModel.DataAnnotations;

namespace Recruitment_Management_System_API.DTOs
{
    public class RecruiterCreateDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(150), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? Phone { get; set; }

        [Required, MaxLength(150)]
        public string CompanyName { get; set; } = string.Empty;
    }
}