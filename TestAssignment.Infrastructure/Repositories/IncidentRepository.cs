using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAssignment.Domain.Entities;
using TestAssignment.Domain.Interfaces;

namespace TestAssignment.Infrastructure.Repositories
{
	public class IncidentRepository : IIncidentRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public IncidentRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Incident incident)
		{
			await _dbContext.Incidents.AddAsync(incident);
			await _dbContext.SaveChangesAsync();
		}

		public Task<bool> ExistsAsync(string name)
		{
			return _dbContext.Incidents.AnyAsync(o => o.Name == name);
		}
	}
}
