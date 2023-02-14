using System.Threading.Tasks;
using TestAssignment.Domain.Entities;

namespace TestAssignment.Domain.Interfaces
{
	public interface IAccountRepository
	{
		Task AddAsync(Account account);

		Task<bool> ExistsAsync(string name);

		Task<Account> GetAsync(string name);
	}
}