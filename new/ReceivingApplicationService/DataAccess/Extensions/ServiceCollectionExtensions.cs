using Abstractions.Repositories;
using DataAccess.Repositories;
using DataAccess.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddScoped<IApplicationRepository, ApplicationRepository>();
        collection.AddScoped<IActivityRepository, ActivityRepository>();
        return collection;
    }
    
}