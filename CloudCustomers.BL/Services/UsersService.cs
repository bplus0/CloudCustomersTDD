using CloudCustomers.BL.Config;
using CloudCustomers.BL.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace CloudCustomers.BL.Services
{

	public class UsersService : IUsersService
	{
		private readonly HttpClient _httpClient;
		private readonly UsersApiOptions _apiConfig;
		public UsersService(HttpClient httpClient, IOptions<UsersApiOptions> apiConfig)
		{
			_httpClient = httpClient;
			_apiConfig = apiConfig.Value;
		}

		public async Task<List<User>> GetAllUsers()
		{
			var userresponse = await _httpClient.GetAsync(_apiConfig.Endpoint);
			if (userresponse.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return new List<User>();
			}

			var responseContent = userresponse.Content;
			var allusers = await responseContent.ReadFromJsonAsync<List<User>>();
			return allusers.ToList();
		}
	}
}
