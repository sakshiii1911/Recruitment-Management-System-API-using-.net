using System.ComponentModel.DataAnnotations;

namespace Recruitment_Management_System_API.Entities
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        public string? Phone { get; set; }

        public string? Skills { get; set; }
        public string? ResumeUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // One candidate can apply to many jobs
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();

    }
}
