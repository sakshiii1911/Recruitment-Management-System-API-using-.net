using System.ComponentModel.DataAnnotations;

namespace Recruitment_Management_System_API.DTOs
{
    public class JobCreateDto
    {
        [Required,MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        public string CompanyName { get; set; } = string.Empty;

        public int RecruiterId { get; set; }
    }
}
