namespace TestAssignment.Domain.Entities
{
	public class Contact
	{
		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public string Email { get; }
		
		public Contact(string firstName, string lastName, string email)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}

		public void Update(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
}
