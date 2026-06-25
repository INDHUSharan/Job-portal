using JobPortal.Domain.Entities;

namespace JobPortal.Application.Interfaces;

public interface IJobRepository
{
    Task<List<Job>> GetAllJobsAsync(); //Database-la irukkura ella jobs-um eduthu kudu.
    Task AddJobAsync(Job job); //Database-la pudhu job save pannu
}