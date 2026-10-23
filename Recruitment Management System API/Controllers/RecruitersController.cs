using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recruitment_Management_System_API.Data;
using Recruitment_Management_System_API.DTOs;

namespace Recruitment_Management_System_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecruitersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecruitersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/recruiters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecruiterResponseDto>>> GetRecruiters()
        {
            var recruiters = await _context.Recruiters
                .Select(r => new RecruiterResponseDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Email = r.Email,
                    Phone = r.Phone,
                    CompanyName = r.CompanyName,
                    CreatedDate = r.CreatedDate
                })
                .ToListAsync();

            return Ok(recruiters);
        }

        // GET: api/recruiters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecruiterResponseDto>> GetRecruiter(int id)
        {
            var recruiter = await _context.Recruiters.FindAsync(id);

            if (recruiter == null)
            {
                return NotFound();
            }

            var dto = new RecruiterResponseDto
            {
                Id = recruiter.Id,
                Name = recruiter.Name,
                Email = recruiter.Email,
                Phone = recruiter.Phone,
                CompanyName = recruiter.CompanyName,
                CreatedDate = recruiter.CreatedDate
            };

            return Ok(dto);
        }
    }
}