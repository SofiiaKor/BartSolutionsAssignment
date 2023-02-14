using System;
using System.Threading.Tasks;
using Mapster;
using TestAssignment.Application.Interfaces;
using TestAssignment.Application.Models;
using TestAssignment.Domain.Entities;
using TestAssignment.Domain.Interfaces;

namespace TestAssignment.Application.Services
{
	public class ContactService : IContactService
	{
		private readonly IContactRepository _contactRepository;

		public ContactService(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}

		public async Task AddAsync(AddContactRequest request)
		{
			var exists = await _contactRepository.ExistsAsync(request.Email);
			if (exists)
			{
				var contact = await _contactRepository.GetAsync(request.Email);
				contact.Update(request.FirstName, request.LastName);

				await _contactRepository.AddAsync(contact);
			}
			else
			{
				var contact = new Contact(request.FirstName, request.LastName, request.Email);

				await _contactRepository.AddAsync(contact);
			}
		}
	}
}
