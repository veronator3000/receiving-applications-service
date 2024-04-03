using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using HttpDto.Dtos;

namespace Abstractions.Repositories;

public interface IApplicationRepository
{
    Task<Application> CreateApplication(Application application);
    Task<Application?> GetApplicationById(Guid applicationId);
    Task<IEnumerable<Application>> GetDraftApplications();
    Task<IEnumerable<Application>> GetOnViewingApplications();
    Task<IEnumerable<Application>> GetApprovedApplications();
    Task<IEnumerable<Application>> GetAllApplications();
    Task<Application> UpdateApplication(Application application);
    Task DeleteApplication(Guid applicationId);
    Task<IEnumerable<Application>> GetApplicationsSubmittedAfterDate(DateTime submitted);
    Task<IEnumerable<Application>> GetApplicationsNotSubmittedAndOlderThanDate(DateTime submitted);
    Task<IEnumerable<Application>> GetApplicationsByUserId(Guid userId);

}