using CloudCustomers.BL.Models;

namespace CloudCustomers.BL.Services
{

	public class UsersService : IUsersService
	{
		private readonly HttpClient _httpClient;
		public UsersService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<User>> GetAllUsers()
		{
			var userresponse = await _httpClient.GetAsync("https://example.com");
			return new List<User>();
		}
	}
}
