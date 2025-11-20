using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ContactAuditConfiguration : IEntityTypeConfiguration<ContactAudit>
{
    public void Configure(EntityTypeBuilder<ContactAudit> builder)
    {
        builder.ToTable("contact_audits");

        builder.HasKey(ca => ca.Id);

        builder.Property(ca => ca.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(ca => ca.ContactId)
            .HasColumnName("contact_id")
            .IsRequired();

        builder.Property(ca => ca.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(ca => ca.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(ca => ca.Email)
            .HasColumnName("email")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(ca => ca.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(ca => ca.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasIndex(ca => ca.ContactId)
            .HasDatabaseName("ix_contact_audits_contact_id");

        builder.HasIndex(ca => ca.UserId)
            .HasDatabaseName("ix_contact_audits_user_id");

        builder.HasIndex(ca => ca.CreatedAt)
            .HasDatabaseName("ix_contact_audits_created_at");
    }
}
