using UP_API.DTO;

namespace UP_API.Services
{
    public interface IApplicationService
    {
        Task<ApplicationDto> CreateAsync(int applicantId, CreateApplicationDto dto);
        Task<IEnumerable<ApplicationDto>> GetAllAsync();
        Task<IEnumerable<ApplicationDto>> GetMyApplicationsAsync(int applicantId);
        Task<bool> UpdateStatusAsync(int id, UpdateStatusDto dto);
    }
}
