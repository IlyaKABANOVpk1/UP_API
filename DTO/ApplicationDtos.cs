using System.ComponentModel.DataAnnotations;
using UP_API.Models;

namespace UP_API.DTO
{
    public record CreateApplicationDto(
        [Required] string FullName,
        [Required, EmailAddress] string Email,
        [Required, Phone] string Phone,
        [Required, StringLength(5000, MinimumLength = 10)] string ResumeText
    );

    public record UpdateStatusDto([Required] ApplicationStatus Status);

    public record ApplicationDto(int Id, string FullName, string Email, string Phone, string ResumeText, DateTime CreatedAt, ApplicationStatus Status, int ApplicantId);
}
