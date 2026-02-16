using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UP_API.DTO;
using UP_API.Models;
using UP_API.Services;

namespace UP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationService _appService;

        public ApplicationsController(IApplicationService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> Create(CreateApplicationDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _appService.CreateAsync(userId, dto);
            return Ok(result);
        }

        [HttpGet("my")]
        [Authorize(Roles = "Applicant")]
        public async Task<IActionResult> GetMyApplications()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _appService.GetMyApplicationsAsync(userId);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> UpdateStatus(int id, UpdateStatusDto dto)
        {
            var success = await _appService.UpdateStatusAsync(id, dto);
            if (!success) return NotFound();
            return Ok("Status updated.");
        }
    }
}
