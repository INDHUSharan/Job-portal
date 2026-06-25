using JobPortal.Application.Interfaces;
using JobPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobRepository _jobRepository;

    public JobsController(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    [HttpGet]
 
    public async Task<IActionResult> GetJobs()
    {
        var jobs = await _jobRepository.GetAllJobsAsync();

        return Ok(jobs);
    }

    [HttpPost]

    public async Task<IActionResult> AddJob(Job job)
    {
        await _jobRepository.AddJobAsync(job);
        return Ok("Job Added Successfully");
    }
}