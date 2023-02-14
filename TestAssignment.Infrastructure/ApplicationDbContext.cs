using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TestAssignment.Domain.Entities;

namespace TestAssignment.Infrastructure
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<Contact> Contacts { get; set; }

		public DbSet<Account> Accounts { get; set; }

		public DbSet<Incident> Incidents { get; set; }
	}
}
