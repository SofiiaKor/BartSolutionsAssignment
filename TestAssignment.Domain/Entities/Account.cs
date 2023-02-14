using System.Collections.Generic;

namespace TestAssignment.Domain.Entities
{
	public class Account
	{
		public string Name { get; }

		public List<Contact> Contacts { get; }

		public Account(string name)
		{
			Name = name;
			Contacts = new List<Contact>();
		}

		public void Update(Contact contact)
		{
			Contacts.Add(contact);
		}
	}
}
