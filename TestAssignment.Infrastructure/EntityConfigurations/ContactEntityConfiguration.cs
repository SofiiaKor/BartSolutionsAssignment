using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAssignment.Domain.Entities;

namespace TestAssignment.Infrastructure.EntityConfigurations
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(t => t.Email);

            builder.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(t => t.LastName).IsRequired().HasMaxLength(50);
        }
    }
}