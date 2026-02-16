using System.Text.Json.Serialization;

namespace UP_API.Models
{
    public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class JobApplication
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ResumeText { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;

        public int ApplicantId { get; set; }
        public User? Applicant { get; set; }
    }
}
