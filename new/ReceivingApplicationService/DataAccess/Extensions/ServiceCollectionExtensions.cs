using Abstractions.Repositories;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureDataAccess(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddScoped<IApplicationRepository, ApplicationRepository>();
        collection.AddScoped<IActivityRepository, ActivityRepository>();
    }
}