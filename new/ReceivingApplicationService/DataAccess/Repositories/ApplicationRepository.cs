using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public async Task<Application> CreateApplication(Application application)
    {
        application.IsDraft = DateTime.UtcNow;

        _context.Applications.Add(application);
        await _context.SaveChangesAsync();
        return application;
    }

    public async Task<Application?> GetApplicationById(Guid applicationId)
    {
        return await _context.Applications.FirstOrDefaultAsync(app => app.ApplicationId == applicationId);
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

    public async Task<Application> UpdateApplication(Application application)
    {
        _context.Applications.Update(application);
        await _context.SaveChangesAsync();
        return application;
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

    public async Task<IEnumerable<Application>> GetApplicationsSubmittedAfterDate(DateTime submitted)
    {
        return await _context.Applications.Where(app => app.OnViewing.HasValue && app.OnViewing > submitted).ToListAsync();
    }

    public async Task<IEnumerable<Application>> GetApplicationsNotSubmittedAndOlderThanDate(DateTime submitted)
    {
        return await _context.Applications
            .Where(app => app.IsDraft != null && app.OnViewing == null && app.IsDraft < submitted)
            .ToListAsync();
    }
    public async Task<IEnumerable<Application>> GetApplicationsByUserId(Guid userId)
    {
        return await _context.Applications.Where(app => app.AuthorId == userId).ToListAsync();
    }
}
