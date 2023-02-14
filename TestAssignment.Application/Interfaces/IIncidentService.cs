using System.Threading.Tasks;
using TestAssignment.Application.Models;

namespace TestAssignment.Application.Interfaces
{
	public interface IIncidentService
	{
		Task AddAsync(AddIncidentRequest request);
	}
}
