using UP_API.Models;

namespace UP_API.DTO
{
    public record CreateApplicationDto(string FullName, string Email, string Phone, string ResumeText);
    public record UpdateStatusDto(ApplicationStatus Status);
    public record ApplicationDto(int Id, string FullName, string Email, string Phone, string ResumeText, DateTime CreatedAt, ApplicationStatus Status, int ApplicantId);
}
