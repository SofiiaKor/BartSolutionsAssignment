using System.Collections.Generic;
using System.Threading.Tasks;
using TestAssignment.Application.Models;

namespace TestAssignment.Application.Interfaces
{
	public interface IAccountService
	{
		Task AddAsync(AddAccountRequest request);
	}
}
