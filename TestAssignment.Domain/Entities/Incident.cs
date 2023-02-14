using System.Collections.Generic;

namespace TestAssignment.Domain.Entities
{
	public class Incident
	{
		public string Name { get; }

		public string Description { get; }

		public List<Account> Accounts { get; }

		public Incident()
		{
		}

		public Incident(string name, string description, List<Account> accounts = null)
		{
			Name = name;
			Description = description;
			Accounts = new List<Account>();
			Accounts = accounts;
		}
	}
}
