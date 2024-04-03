using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.ActivitySet;

namespace Abstractions.Repositories;

public interface IActivityRepository
{
    Task<IEnumerable<ActivityEntity>> GetAllActivities();
    Task AddActivity(ActivityEntity activityEntity);
    Task UpdateActivity(ActivityEntity activityEntity);
    Task DeleteActivity(int id);
}