using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<ContactAudit> ContactAudits => Set<ContactAudit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Seed do usuário padrão: admin/admin123
        modelBuilder.Entity<User>().HasData(
            new 
            { 
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Username = "admin",
                PasswordHash = "$2a$11$tZnbYY2mUoM.hIUhLJ2N3u.rmcTCtityrUfAQZ5TH0u5xjfxTQsBm",
                CreatedAt = new DateTime(2025, 11, 21, 0, 0, 0, DateTimeKind.Utc),
                UpdatedAt = new DateTime(2025, 11, 21, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}

