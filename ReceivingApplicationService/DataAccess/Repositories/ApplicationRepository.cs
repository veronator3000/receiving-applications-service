using Abstractions.Repositories;
using DataAccess.Repositories.Context;
using Entities;
using HttpDto.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly DataBaseContext _context;

    public ApplicationRepository(DataBaseContext context)
    {
        _context = context;
    }
    public async Task CreateApplication(Application application)
    {
        _context.Applications.Add(application);
        await _context.SaveChangesAsync();
    }

    public async Task<Application?> GetApplicationById(Guid applicationId)
    {
        return await _context.Applications.FirstOrDefaultAsync(app => app.ApplicationId == applicationId)!;
    }

    public async Task<IEnumerable<Application>> GetDraftApplications()
    {
        return await _context.Applications.Where(app => app.IsDraft != null).ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetOnViewingApplications()
    {
        return await _context.Applications.Where(app => app.OnViewing != null).ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetApprovedApplications()
    {
        return await _context.Applications.Where(app => app.IsApproved != null).ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetAllApplications()
    {
        return await _context.Applications.ToListAsync();
    }

    public async Task UpdateApplication(Application application)
    {
        _context.Applications.Update(application);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteApplication(Guid applicationId)
    {
        var application = await _context.Applications.FindAsync(applicationId);
        if (application != null)
        {
            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();
        }
    }
}
