using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TestAssignment.Infrastructure;

namespace TestAssignment.Api.Extensions
{
	public static class EntityFrameworkExtension
	{
		public static IServiceCollection WithEntityFramework(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("DefaultConnection"),
				b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

			return services;
		}

		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestAssignment", Version = "v1" });
			});

			return services;
		}

		public static IApplicationBuilder MigrateDb(this IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
			if (serviceScope == null)
				return app;

			var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();

			return app;
		}


		public static IServiceCollection AddCustomMvc(this IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.Filters.Add(typeof(ExceptionHandlingFilter));
			}).AddNewtonsoftJson();

			return services;
		}
	}
}
