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

        var adminId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        var baseDate = new DateTime(2025, 11, 21, 0, 0, 0, DateTimeKind.Utc);

        // Seed do usuário padrão: admin/admin123
        modelBuilder.Entity<User>().HasData(
            new 
            { 
                Id = adminId,
                Username = "admin",
                PasswordHash = "$2a$11$tZnbYY2mUoM.hIUhLJ2N3u.rmcTCtityrUfAQZ5TH0u5xjfxTQsBm",
                CreatedAt = baseDate,
                UpdatedAt = (DateTime?)baseDate
            }
        );

        // Seed de contatos vinculados ao usuário admin
        modelBuilder.Entity<Contact>().HasData(
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                UserId = adminId,
                Name = "João Silva",
                Email = "joao.silva@email.com",
                Phone = "11999999999",
                CreatedAt = baseDate.AddHours(1),
                UpdatedAt = (DateTime?)null
            },
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                UserId = adminId,
                Name = "Maria Oliveira",
                Email = "maria.oliveira@email.com",
                Phone = "11988888888",
                CreatedAt = baseDate.AddHours(2),
                UpdatedAt = (DateTime?)null
            },
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                UserId = adminId,
                Name = "Carlos Souza",
                Email = "carlos.souza@email.com",
                Phone = "11977777777",
                CreatedAt = baseDate.AddHours(3),
                UpdatedAt = (DateTime?)null
            },
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                UserId = adminId,
                Name = "Ana Santos",
                Email = "ana.santos@email.com",
                Phone = "11966666666",
                CreatedAt = baseDate.AddHours(4),
                UpdatedAt = (DateTime?)null
            },
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                UserId = adminId,
                Name = "Pedro Costa",
                Email = "pedro.costa@email.com",
                Phone = "11955555555",
                CreatedAt = baseDate.AddHours(5),
                UpdatedAt = (DateTime?)null
            },
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                UserId = adminId,
                Name = "Juliana Lima",
                Email = "juliana.lima@email.com",
                Phone = "11944444444",
                CreatedAt = baseDate.AddHours(6),
                UpdatedAt = (DateTime?)null
            },
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                UserId = adminId,
                Name = "Roberto Alves",
                Email = "roberto.alves@email.com",
                Phone = "11933333333",
                CreatedAt = baseDate.AddHours(7),
                UpdatedAt = (DateTime?)null
            },
            new
            {
                Id = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                UserId = adminId,
                Name = "Fernanda Rocha",
                Email = "fernanda.rocha@email.com",
                Phone = "11922222222",
                CreatedAt = baseDate.AddHours(8),
                UpdatedAt = (DateTime?)null
            }
        );
    }
}

