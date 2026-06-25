using JobPortal.Application.Interfaces;
using JobPortal.Domain.Entities;
using JobPortal.Infrastructure.Data;
using MongoDB.Driver;

namespace JobPortal.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly IMongoCollection<Job> _jobs;

    public JobRepository(MongoDbContext context)
    {
        _jobs = context.Database.GetCollection<Job>("Jobs");                  //_jobs variable Jobs collection-a hold pannudhu, JobPortalDb-la irukkura Jobs collection-a kudu.

    }

    public async Task<List<Job>> GetAllJobsAsync()
    {
        return await _jobs.Find(_ => true).ToListAsync();                   //Jobs collection-la irukkura ella jobs-um kudu
    }

    public async Task AddJobAsync(Job job)
    {
        await _jobs.InsertOneAsync(job);                                   //MongoDB-la oru new Job save panna use aagudhu.
    }
}