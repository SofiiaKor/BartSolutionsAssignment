using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAssignment.Domain.Entities;
using TestAssignment.Domain.Interfaces;

namespace TestAssignment.Infrastructure.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public AccountRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Account account)
		{
			await _dbContext.Accounts.AddAsync(account);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Account> GetAsync(string name)
		{
			var account = await _dbContext.Accounts.FirstOrDefaultAsync(o => o.Name == name);
			return account;
		}

		public Task<bool> ExistsAsync(string name)
		{
			return _dbContext.Accounts.AnyAsync(o => o.Name == name);
		}
	}
}
