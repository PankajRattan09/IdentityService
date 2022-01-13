using IdentityService.API.Controllers;
using IdentityService.API.Test.Entities;
using IdentityService.Application.Interfaces;
using IdentityService.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace IdentityService.API.Test.Controllers
{
    public class UsersControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IUserService> mockUserService;

        public UsersControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUserService = this.mockRepository.Create<IUserService>();
        }

        private UsersController CreateUsersController()
        {
            return new UsersController(
                this.mockUserService.Object);
        }

        

        [Theory]
        [MemberData("TestCases", MemberType = typeof(TestDataProviderForGetUserByUserId))]
        public async Task GetUserByUserId_StateUnderTest_ExpectedBehavior(string testcase, 
            MemberDataSerializer<UserDetailsViewModels> memberDataSerializer,
            MemberDataSerializer<UserDetailsViewModels> expected)
        {
            // Arrange
            var usersController = this.CreateUsersController();
            var memberobj = memberDataSerializer?.Object;

            var Expectedobj = expected.Object;

            this.mockUserService.Setup(i => i.GetUserById(testcase, true)).Returns(Task.FromResult(memberobj));

            // Act
            var result = await usersController.GetUserByUserId(testcase);

            // Assert
            Assert.IsType<OkObjectResult>(result);

            var OkResult = (UserDetailsViewModels)((ObjectResult)result).Value;

            Assert.Equal(Expectedobj.UserName, OkResult.UserName);
            Assert.Equal(Expectedobj.UserGuid, OkResult.UserGuid);
            Assert.Equal(Expectedobj.RoleName, OkResult.RoleName);
            Assert.Equal(Expectedobj.RoleID, OkResult.RoleID);
            Assert.Equal(Expectedobj.AplId, OkResult.AplId);
            Assert.Equal(Convert.ToInt32(Expectedobj.HasActiveRole), Convert.ToInt32(OkResult.HasActiveRole));

            this.mockRepository.VerifyAll();
        }


        [Theory]
        [MemberData("TestCases", MemberType = typeof(TestDataProviderForResponseTest))]
        public async Task GetUserByUserId_StateUnderTest_Responsetest(string testcase, 
            MemberDataSerializer<UserDetailsViewModels> memberDataSerializer,
            int expected)
        {
            // Arrange
            var usersController = this.CreateUsersController();
            var memberobj = memberDataSerializer?.Object;

            this.mockUserService.Setup(i => i.GetUserById(testcase, true)).Returns(Task.FromResult(memberobj));

            // Act
            var result = await usersController.GetUserByUserId(testcase);

            // Assert
            var statusCodeResult = (IStatusCodeActionResult)result;

            Assert.Equal(expected, statusCodeResult.StatusCode);
        }


        [Theory]
        [MemberData("TestCases", MemberType = typeof(TestDataProviderForGetUserById))]
        public async Task GetUserById_StateUnderTest_ExpectedBehavior(string testcase,
            MemberDataSerializer<UserDetailsViewModels> memberDataSerializer,
            string expected)
        {
            // Arrange
            var usersController = this.CreateUsersController();

            var memberobj = memberDataSerializer?.Object;

            this.mockUserService.Setup(i => i.GetUserById(testcase, false)).Returns(Task.FromResult(memberobj));

            // Act
            var result = await usersController.GetUserById(testcase);

            // Assert
            Assert.IsType<OkObjectResult>(result);

            var OkResult = (string)((ObjectResult)result).Value;

            Assert.Equal(expected, OkResult);

            this.mockRepository.VerifyAll();
        }
    }
}
