using CloudCustomers.BL.Models;
using System.Collections.Generic;

namespace CloudCustomers.UnitTests.Fixtures
{
	public static class UsersFixture
	{

		public static List<User> GetTestUsers() => new()
		{

			new User
			{
				Name = "Benny",
				Email = "Ben@aol.com",
				Address = new Address
				{
					Street = "421 Driftwood ct",
					City = "Sioux City",
					ZipCode = "51104"
				}
			},

			new User
			{
				Name = "Jazzy",
				Email = "Jaz@aol.com",
				Address = new Address
				{
					Street = "109 S Crawford",
					City = "Carroll",
					ZipCode = "51309"
				}
			},

			new User
			{
				Name = "Molly",
				Email = "Molly@aol.com",
				Address = new Address
				{
					Street = "1234 fun st",
					City = "Wdsm",
					ZipCode = "12345"
				}
			},

		};


	}
}
