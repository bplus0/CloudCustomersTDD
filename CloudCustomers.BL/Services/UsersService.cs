using CloudCustomers.BL.Models;

namespace CloudCustomers.BL.Services
{
	public class UsersService : IUsersService
	{
		public UsersService()
		{

		}

		public Task<List<User>> GetAllUsers()
		{
			throw new NotImplementedException();
		}
	}
}
