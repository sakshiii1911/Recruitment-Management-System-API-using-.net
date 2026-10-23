using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recruitment_Management_System_API.Data;
using Recruitment_Management_System_API.DTOs;
using Recruitment_Management_System_API.Entities;

namespace Recruitment_Management_System_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobResponseDto>>> GetJobs()
        {
            var jobs = await _context.Jobs
                .Select(j => new JobResponseDto
                {
                    Id = j.Id,
                    Title = j.Title,
                    Description = j.Description,
                    Location = j.Location,
                    Salary = j.Salary,
                    CompanyName = j.CompanyName,
                    CreatedDate = j.CreatedDate,
                    RecruiterId = j.RecruiterId
                })
                .ToListAsync();

            return Ok(jobs);
        }

        // GET: api/jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobResponseDto>> GetJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            var dto = new JobResponseDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Location = job.Location,
                Salary = job.Salary,
                CompanyName = job.CompanyName,
                CreatedDate = job.CreatedDate,
                RecruiterId = job.RecruiterId
            };

            return Ok(dto);
        }

        // POST: api/jobs
        [HttpPost]
        public async Task<ActionResult<JobResponseDto>> CreateJob(JobCreateDto dto)
        {
            var recruiterExists = await _context.Recruiters.AnyAsync(r => r.Id == dto.RecruiterId);

            if (!recruiterExists)
            {
                return BadRequest("Recruiter not found");
            }

            var job = new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                Salary = dto.Salary,
                CompanyName = dto.CompanyName,
                RecruiterId = dto.RecruiterId
            };

            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            var response = new JobResponseDto
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                Location = job.Location,
                Salary = job.Salary,
                CompanyName = job.CompanyName,
                CreatedDate = job.CreatedDate,
                RecruiterId = job.RecruiterId
            };

            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, response);
        }

        // PUT: api/jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJob(int id, JobCreateDto dto)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            job.Title = dto.Title;
            job.Description = dto.Description;
            job.Location = dto.Location;
            job.Salary = dto.Salary;
            job.CompanyName = dto.CompanyName;

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if(job == null)
            {
                return NotFound();
            }

             _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return NoContent();

        }

    }
}