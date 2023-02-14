using Microsoft.Extensions.DependencyInjection;
using TestAssignment.Application.Interfaces;
using TestAssignment.Application.Services;
using TestAssignment.Domain.Interfaces;
using TestAssignment.Infrastructure.Repositories;

namespace TestAssignment.Api.Extensions
{
	public static class ServicesExtension
	{
		public static IServiceCollection WithServices(this IServiceCollection services)
		{
			services.AddTransient<IContactService, ContactService>();
			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<IIncidentService, IncidentService>();

			services.AddTransient<IContactRepository, ContactRepository>();
			services.AddTransient<IAccountRepository, AccountRepository>();
			services.AddTransient<IIncidentRepository, IncidentRepository>();

			return services;
		}
	}
}
