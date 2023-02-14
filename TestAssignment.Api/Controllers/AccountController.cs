using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAssignment.Application.Interfaces;
using TestAssignment.Application.Models;

namespace TestAssignment.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(AddAccountRequest request)
		{
			await _accountService.AddAsync(request);

			return Ok("Account added successfully.");
		}
	}
}
