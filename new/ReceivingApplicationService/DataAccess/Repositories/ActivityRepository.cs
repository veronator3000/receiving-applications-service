using Abstractions.Repositories;
using DataAccess.Repositories.Context;
using Entities.ActivitySet;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly DataBaseContext _context;

    public ActivityRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ActivityEntity>> GetAllActivities()
    {
        return await _context.Activities.ToListAsync();
    }
}