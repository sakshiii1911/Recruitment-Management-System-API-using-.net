namespace Recruitment_Management_System_API.Entities
{
    public class JobApplication
    {

        public int Id { get; set; }

        public ApplicationStatus Status { get; set; } = ApplicationStatus.Applied;
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;

        // Foreign key to Candidate
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; } = null!;

        // Foreign key to Job
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;
    }
}
