using Moq;
using PetrolSist.Core.Domain.Entities;
using PetrolSist.Core.DTO.GatewayResponses;
using PetrolSist.Core.DTO.UseCaseRequests;
using PetrolSist.Core.DTO.UseCaseResponses;
using PetrolSist.Core.Interfaces;
using PetrolSist.Core.Interfaces.Gateways.Repositories;
using PetrolSist.Core.UseCases;
using System.Threading.Tasks;
using Xunit;

namespace PetrolSist.Test.UseCases
{
    public class RegisterUserUseCaseUnitTests
    {
        [Fact]
        public async void Can_Register_User()
        {
            //  Arrange - Set up all conditions needed for testing (create any required objects,
            //  allocate any needed resources, and so on).
            //
            //  1.  We need to store the user data
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository
                .Setup(repo => repo.Create(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new CreateUserResponse("", true)));

            //  2.  Our actual use case
            var usecase = new RegisterUserUseCase(mockUserRepository.Object);

            //  3.  Our output zone - The mechanism by which we pass response data from the use case to a
            //  presenter for final preparation to deliver back to  the UI/Web page/API response
            var mocOutputZone = new Mock<IOutputZone<RegisterUserResponse>>();
            mocOutputZone.Setup(outputzone => outputzone.Handle(It.IsAny<RegisterUserResponse>()));

            //  Act - Invoke the method to be tested with possible parameters or values.

            //  4.  We need a request model to carry data into the use case from the
            //  upper layer(UI, Controllers etc)
            var response = await usecase.Handle(
                new RegisterUserRequest(
                    "myfirstname",
                    "mylastname",
                    "email@domain.com",
                    "myusername",
                    "ford",
                    "blue",
                    "somepassword"
                    ),
                mocOutputZone.Object
                );

            //  Assert - Verify that the tested method returns the output as expected.
            Assert.True(response);
        }
    }
}
