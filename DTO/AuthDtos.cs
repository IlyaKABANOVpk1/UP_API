using System.ComponentModel.DataAnnotations;

namespace UP_API.DTO
{
    public record RegisterDto(
        [Required, StringLength(20, MinimumLength = 3)] string Username,
        [Required, StringLength(100, MinimumLength = 6)] string Password
    );

    public record LoginDto(
        [Required] string Username,
        [Required] string Password
    );

    public record AuthResponseDto(string Token, string Role);
}
