using Microsoft.EntityFrameworkCore;
using UP_API.Data;
using UP_API.DTO;
using UP_API.Models;

namespace UP_API.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly AppDbContext _context;

        public ApplicationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationDto> CreateAsync(int applicantId, CreateApplicationDto dto)
        {
            var app = new JobApplication
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                ResumeText = dto.ResumeText,
                ApplicantId = applicantId
            };

            _context.JobApplications.Add(app);
            await _context.SaveChangesAsync();

            return MapToDto(app);
        }

        public async Task<IEnumerable<ApplicationDto>> GetAllAsync()
        {
            var apps = await _context.JobApplications.ToListAsync();
            return apps.Select(MapToDto);
        }

        public async Task<IEnumerable<ApplicationDto>> GetMyApplicationsAsync(int applicantId)
        {
            var apps = await _context.JobApplications
                .Where(a => a.ApplicantId == applicantId)
                .ToListAsync();
            return apps.Select(MapToDto);
        }

        public async Task<bool> UpdateStatusAsync(int id, UpdateStatusDto dto)
        {
            var app = await _context.JobApplications.FindAsync(id);
            if (app == null) return false;

            app.Status = dto.Status;
            await _context.SaveChangesAsync();
            return true;
        }

        private static ApplicationDto MapToDto(JobApplication app)
        {
            return new ApplicationDto(app.Id, app.FullName, app.Email, app.Phone, app.ResumeText, app.CreatedAt, app.Status, app.ApplicantId);
        }
    }
}
