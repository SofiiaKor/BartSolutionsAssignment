using System.Threading.Tasks;
using TestAssignment.Domain.Entities;

namespace TestAssignment.Domain.Interfaces
{
	public interface IIncidentRepository
	{
		Task AddAsync(Incident incident);

		Task<bool> ExistsAsync(string name);
	}
}

