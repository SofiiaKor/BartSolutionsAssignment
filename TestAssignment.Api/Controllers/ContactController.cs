using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAssignment.Application.Interfaces;
using TestAssignment.Application.Models;

namespace TestAssignment.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(AddContactRequest request)
		{
			await _contactService.AddAsync(request);

			return Ok("Contact added successfully.");
		}
	}
}
