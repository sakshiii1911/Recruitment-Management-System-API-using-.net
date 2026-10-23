using System.ComponentModel.DataAnnotations;

namespace Recruitment_Management_System_API.Entities
{
    public class Job
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        
        public string Location { get; set; } = string.Empty;

        public decimal Salary { get; set; }

        public string CompanyName { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Foreign key: which recruiter created this job
        public int RecruiterId { get; set; }
        public Recruiter Recruiter { get; set; } = null!;   // navigation to the "one" side

        // One job receives many applications
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();

    }
}
