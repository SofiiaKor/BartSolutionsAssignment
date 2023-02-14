using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAssignment.Application.Interfaces;
using TestAssignment.Application.Models;
using TestAssignment.Domain.Entities;
using TestAssignment.Domain.Interfaces;

namespace TestAssignment.Application.Services
{
	public class IncidentService : IIncidentService
	{
		private readonly IIncidentRepository _incidentRepository;

		private readonly IAccountRepository _accountRepository;

		private readonly IContactRepository _contactRepository;

		public IncidentService(IIncidentRepository incidentRepository, IAccountRepository accountRepository, IContactRepository contactRepository)
		{
			_incidentRepository = incidentRepository;
			_accountRepository = accountRepository;
			_contactRepository = contactRepository;
		}

		public async Task AddAsync(AddIncidentRequest request)
		{
			var exists = await _incidentRepository.ExistsAsync(request.IncidentName);
			if (exists)
				throw new Exception("Such incident already exists");

			var account = await _accountRepository.GetAsync(request.AccountName);
			if (account is null)
				throw new KeyNotFoundException("Such account doesn't exists");

			account.Update(await _contactRepository.GetAsync(request.Email));

			var incident = new Incident(request.IncidentName, request.Description, new List<Account> { account });

			await _incidentRepository.AddAsync(incident);
		}
	}
}
