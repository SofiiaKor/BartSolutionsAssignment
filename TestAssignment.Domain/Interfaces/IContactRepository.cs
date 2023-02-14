using System.Threading.Tasks;
using TestAssignment.Domain.Entities;

namespace TestAssignment.Domain.Interfaces
{
	public interface IContactRepository
	{
		Task AddAsync(Contact contact);

		Task<bool> ExistsAsync(string email);

		Task<Contact> GetAsync(string email);

	}
}
