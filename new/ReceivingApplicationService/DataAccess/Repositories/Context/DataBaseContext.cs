using Entities;
using Entities.ActivitySet;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Context;

public class DataBaseContext : DbContext
{
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();

    public DataBaseContext(
        DbContextOptions<DataBaseContext> options
    ) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>().ToTable("Applications");
        base.OnModelCreating(modelBuilder);
    }
    
    
}