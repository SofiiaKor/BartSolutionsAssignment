using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAssignment.Application.Interfaces;
using TestAssignment.Application.Models;

namespace TestAssignment.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IncidentController : ControllerBase
	{
		private readonly IIncidentService _incidentService;

		public IncidentController(IIncidentService incidentService)
		{
			_incidentService = incidentService;
		}

		[HttpPost]
		public async Task<IActionResult> AddAsync(AddIncidentRequest request)
		{
			await _incidentService.AddAsync(request);

			return Ok("Incident added successfully.");
		}
	}
}
