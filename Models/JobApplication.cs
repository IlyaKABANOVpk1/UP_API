using System.ComponentModel.DataAnnotations;

namespace UP_API.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MaxLength(10000)]
        public string ResumeText { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        public int ApplicantId { get; set; }
        public User Applicant { get; set; } = null!;
    }

    public enum ApplicationStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}