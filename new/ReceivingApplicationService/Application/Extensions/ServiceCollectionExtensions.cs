using Application.Application;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IActivitiesService, ActivitiesService>();
        collection.AddScoped<IApplicationService, ApplicationService>();
        collection.AddScoped<IUserService, UsersService>();
        return collection;
    }
}