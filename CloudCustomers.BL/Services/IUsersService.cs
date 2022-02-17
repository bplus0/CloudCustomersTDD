using CloudCustomers.BL.Models;

namespace CloudCustomers.BL.Services
{
	public interface IUsersService
	{
		Task<List<User>> GetAllUsers();
	}
}