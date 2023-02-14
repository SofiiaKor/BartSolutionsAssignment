using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAssignment.Domain.Entities;
using TestAssignment.Domain.Interfaces;

namespace TestAssignment.Infrastructure.Repositories
{
	public class ContactRepository : IContactRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public ContactRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Contact contact)
		{
			await _dbContext.Contacts.AddAsync(contact);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Contact> GetAsync(string email)
		{
			var contact = await _dbContext.Contacts.FirstOrDefaultAsync(o => o.Email == email);
			return contact;
		}

		public Task<bool> ExistsAsync(string email)
		{
			return _dbContext.Contacts.AnyAsync(o => o.Email == email);
		}
	}
}
