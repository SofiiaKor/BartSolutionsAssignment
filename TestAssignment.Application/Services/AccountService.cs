using System;
using System.Threading.Tasks;
using TestAssignment.Application.Interfaces;
using TestAssignment.Application.Models;
using TestAssignment.Domain.Entities;
using TestAssignment.Domain.Interfaces;

namespace TestAssignment.Application.Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public async Task AddAsync(AddAccountRequest request)
		{
			var exists = await _accountRepository.ExistsAsync(request.Name);
			if (exists)
				throw new Exception("Such account already exists");

			var account = new Account(request.Name);

			await _accountRepository.AddAsync(account);
		}
	}
}
