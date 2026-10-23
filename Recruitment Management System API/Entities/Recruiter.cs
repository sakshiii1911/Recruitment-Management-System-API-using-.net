using System.ComponentModel.DataAnnotations;

namespace Recruitment_Management_System_API.Entities
{
    public class Recruiter
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;


        [Required, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? Phone { get; set; }         // ? means optional (nullable)

        
        public string CompanyName { get; set; } = string.Empty;


        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation property: one recruiter has many jobs
        public ICollection<Job> Jobs { get; set; } = new List<Job>();

    }
}
