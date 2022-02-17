using CloudCustomers.API.Controllers;
using CloudCustomers.BL.Models;
using CloudCustomers.BL.Services;
using CloudCustomers.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers
{
	public class TestUsersController
	{
		//standard paramater list unit test
		[Fact]
		public async Task Get_OnSuccess_ReturnsStatusCode200()
		{
			//Arrange
			//sut = situation under task
			var mockUsersService = new Mock<IUsersService>();
			mockUsersService
				.Setup(service => service
				.GetAllUsers())
				.ReturnsAsync(UsersFixture.GetTestUsers());

			var sut = new UsersController(mockUsersService.Object);

			//Act
			var result = (OkObjectResult)await sut.Get();

			//Assert
			result.StatusCode.Should().Be(200);
		}





		[Fact]
		public async Task Get_OnSucess_InvokesUserServiceExactlyOnce()
		{
			//Arrange
			var mockUsersService = new Mock<IUsersService>();
			mockUsersService
				.Setup(service => service
				.GetAllUsers())
				.ReturnsAsync(new List<User>());

			var sut = new UsersController(mockUsersService.Object);

			//Act
			var result = await sut.Get();

			//Assert
			mockUsersService.Verify(service =>
			service.GetAllUsers(),
				Times.Once());
		}




		[Fact]
		public async Task Get_OnSuccess_ReturnsListOfUsers()
		{
			//Arrange
			var mockUsersService = new Mock<IUsersService>();
			mockUsersService
				.Setup(service => service
				.GetAllUsers())
					.ReturnsAsync(UsersFixture.GetTestUsers());

			var sut = new UsersController(mockUsersService.Object);

			//Act
			var result = await sut.Get();

			//Assert
			result.Should().BeOfType<OkObjectResult>();
			var objectResult = (OkObjectResult)result;
			objectResult.Value.Should().BeOfType<List<User>>();
		}



		[Fact]
		public async Task Get_OnNoUsersFound_Returns404()
		{
			//Arrange
			var mockUsersService = new Mock<IUsersService>();
			mockUsersService
				.Setup(service => service
				.GetAllUsers())
				.ReturnsAsync(new List<User>());

			var sut = new UsersController(mockUsersService.Object);

			//Act
			var result = await sut.Get();

			//Assert
			result.Should().BeOfType<NotFoundResult>();

			var objectResult = (NotFoundResult)result;
			objectResult.StatusCode.Should().Be(404);
		}





		//[Theory]
		//[InlineData("foo",1)]
		//[InlineData("bar", 1)]
		//public void Test2(string input, int bar)
		//{

		//}
	}
}