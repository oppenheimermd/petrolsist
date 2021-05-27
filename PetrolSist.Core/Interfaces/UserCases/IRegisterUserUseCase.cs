
using PetrolSist.Core.DTO.UseCaseRequests;
using PetrolSist.Core.DTO.UseCaseResponses;

namespace PetrolSist.Core.Interfaces.UserCases
{
    public interface IRegisterUserUseCase : IUseCaseRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {
    }
}
