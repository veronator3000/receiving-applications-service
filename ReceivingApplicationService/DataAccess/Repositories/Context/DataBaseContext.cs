using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Context;

public class DataBaseContext : DbContext
{
    public DbSet<Application> Applications => Set<Application>();

    public DataBaseContext (
        DbContextOptions<DataBaseContext> options
         ) : base(options) { }
}