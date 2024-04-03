using Entities;
using Entities.ActivitySet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories.Context;

public class DataBaseContext : DbContext
{
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<ActivityEntity> Activities => Set<ActivityEntity>();

    public DataBaseContext()
    {
        
    }
    public DataBaseContext(
        DbContextOptions<DataBaseContext> options
    ) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>().ToTable("Applications");
        modelBuilder.Entity<ActivityEntity>().ToTable("Activities");
        modelBuilder.Entity<ActivityEntity>().HasData(
            new ActivityEntity { Id = 1, Type = ActivityType.Presentation, Description = "Доклад, 35-45 минут" },
            new ActivityEntity { Id = 2, Type = ActivityType.Workshop, Description = "Мастеркласс, 1-2 часа" },
            new ActivityEntity { Id = 3, Type = ActivityType.Discussion, Description = "Дискуссия / круглый стол, 40-50 минут" }
        );
        base.OnModelCreating(modelBuilder);
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
    // {
    //     modelBuilder.UseNpgsql(
    //         "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=123;sslMode=disable");
    // }

    
}