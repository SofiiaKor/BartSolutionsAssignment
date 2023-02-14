using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAssignment.Domain.Entities;

namespace TestAssignment.Infrastructure.EntityConfigurations
{
    public class IncidentEntityConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(t => t.Name);

            builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
            builder.HasMany(t => t.Accounts);
        }
    }
}