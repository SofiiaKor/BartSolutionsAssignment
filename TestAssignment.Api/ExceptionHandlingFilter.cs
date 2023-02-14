using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestAssignment.Api
{
	public class ExceptionHandlingFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;

			var responseCode = MapException(context.Exception);

			context.Result = new ObjectResult(null)
			{
				StatusCode = (int)responseCode
			};
		}

		private static HttpStatusCode MapException(Exception exception)
		{
			return exception switch
			{
				KeyNotFoundException => HttpStatusCode.NotFound,
				not null => HttpStatusCode.InternalServerError
			};
		}
	}
}
