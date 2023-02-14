using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAssignment.Domain.Entities;

namespace TestAssignment.Infrastructure.EntityConfigurations
{
    public class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(t => t.Name);

            builder.HasMany(t => t.Contacts);
        }
    }
}